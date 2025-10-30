using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace SQLServerBackupUtility.Helpers
{
    /// <summary>
    /// Helper to create, delete and query Windows Scheduled Tasks using the schtasks.exe command-line tool.
    /// This avoids adding external COM references. It composes proper schtasks arguments from a ScheduleEntry.
    /// </summary>
    public static class SchedulerTaskManager
    {
        public struct Result
        {
            public bool Success { get; set; }
            public int ExitCode { get; set; }
            public string Output { get; set; }
        }

        /// <summary>
        /// Create or update a scheduled task for the given schedule entry. The task will run the specified exePath
        /// with the --run-scheduler "stateFile" argument.
        /// </summary>
        public static Result CreateOrUpdateTask(ScheduleEntry entry, string exePath, string stateFile)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            if (string.IsNullOrEmpty(exePath)) throw new ArgumentNullException(nameof(exePath));
            if (string.IsNullOrEmpty(stateFile)) throw new ArgumentNullException(nameof(stateFile));

            // Task name should be a valid name for schtasks; keep it simple
            string taskName = MakeTaskName(entry.Name);

            // Build schtasks arguments
            var args = new StringBuilder();
            args.Append("/Create ");
            args.Append("/F "); // force overwrite if exists
            args.AppendFormat("/TN \"{0}\" ", taskName);

            // Action (command)
            var quotedExe = QuoteIfNeeded(exePath);
            var quotedState = QuoteIfNeeded(stateFile);
            var action = $"\"{exePath}\" --run-scheduler {quotedState}";
            args.AppendFormat("/TR \"{0}\" ", action);

            // Schedule type and timing
            var sc = entry.Recurrence?.Trim() ?? string.Empty;
            if (sc.Equals("One Time", StringComparison.OrdinalIgnoreCase) || sc.Equals("OneTime", StringComparison.OrdinalIgnoreCase) || sc.Equals("Once", StringComparison.OrdinalIgnoreCase))
            {
                args.Append("/SC ONCE ");
                // Start date and time
                args.AppendFormat(CultureInfo.InvariantCulture, "/ST {0:HH:mm} ", entry.StartDateTime);
                args.AppendFormat(CultureInfo.InvariantCulture, "/SD {0:yyyy/MM/dd} ", entry.StartDateTime);
            }
            else if (sc.Equals("Daily", StringComparison.OrdinalIgnoreCase))
            {
                args.Append("/SC DAILY ");
                args.AppendFormat(CultureInfo.InvariantCulture, "/ST {0:HH:mm} ", entry.StartDateTime);
                if (entry.Interval > 1)
                    args.AppendFormat("/MO {0} ", Math.Max(1, entry.Interval));
            }
            else if (sc.Equals("Weekly", StringComparison.OrdinalIgnoreCase))
            {
                args.Append("/SC WEEKLY ");
                args.AppendFormat(CultureInfo.InvariantCulture, "/ST {0:HH:mm} ", entry.StartDateTime);
                if (entry.Interval > 1)
                    args.AppendFormat("/MO {0} ", Math.Max(1, entry.Interval));

                // Days of week mapping: expect e.g. Mon,Tue
                if (!string.IsNullOrEmpty(entry.DaysOfWeek))
                {
                    var days = entry.DaysOfWeek.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var mapped = new StringBuilder();
                    foreach (var d in days)
                    {
                        var t = MapDayNameToSchtasks(d.Trim());
                        if (!string.IsNullOrEmpty(t))
                        {
                            if (mapped.Length > 0) mapped.Append(',');
                            mapped.Append(t);
                        }
                    }
                    if (mapped.Length > 0)
                        args.AppendFormat("/D {0} ", mapped.ToString());
                }
            }
            else if (sc.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
            {
                args.Append("/SC MONTHLY ");
                args.AppendFormat(CultureInfo.InvariantCulture, "/ST {0:HH:mm} ", entry.StartDateTime);
                if (entry.Interval > 1)
                    args.AppendFormat("/MO {0} ", Math.Max(1, entry.Interval));
                if (entry.DayOfMonth >= 1 && entry.DayOfMonth <= 31)
                {
                    args.AppendFormat("/D {0} ", entry.DayOfMonth);
                }
            }
            else
            {
                // default: daily
                args.Append("/SC DAILY ");
                args.AppendFormat(CultureInfo.InvariantCulture, "/ST {0:HH:mm} ", entry.StartDateTime);
            }

            // Run as user
            if (entry.RunAsCurrentUser)
            {
                // use system account if desired; to run as currently logged on user, use /RU <username>
                // leave out /RU to use the current user? schtasks requires /RU; we'll use the current user
                args.AppendFormat("/RU \"{0}\" ", Environment.UserName);
            }
            else
            {
                if (!string.IsNullOrEmpty(entry.UserName))
                {
                    args.AppendFormat("/RU \"{0}\" ", entry.UserName);
                    // if password provided, pass it; otherwise use blank (may fail)
                    args.AppendFormat("/RP \"{0}\" ", entry.Password ?? string.Empty);
                }
            }

            // Run whether user is logged on or not
            args.Append("/RL HIGHEST ");

            return RunSchtasks(args.ToString());
        }

        public static Result DeleteTask(string taskName)
        {
            if (string.IsNullOrEmpty(taskName)) throw new ArgumentNullException(nameof(taskName));
            string args = $"/Delete /F /TN \"{MakeTaskName(taskName)}\"";
            return RunSchtasks(args);
        }

        private static Result RunSchtasks(string arguments)
        {
            try
            {
                var psi = new ProcessStartInfo("schtasks.exe", arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                using (var p = Process.Start(psi))
                {
                    var outStr = p.StandardOutput.ReadToEnd();
                    var errStr = p.StandardError.ReadToEnd();
                    p.WaitForExit();
                    var combined = (outStr + "\n" + errStr).Trim();
                    return new Result { Success = p.ExitCode == 0, ExitCode = p.ExitCode, Output = combined };
                }
            }
            catch (Exception ex)
            {
                return new Result { Success = false, ExitCode = -1, Output = ex.ToString() };
            }
        }

        private static string MapDayNameToSchtasks(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            var s = name.Trim().ToLowerInvariant();
            switch (s)
            {
                case "mon": case "monday": return "MON";
                case "tue": case "tuesday": return "TUE";
                case "wed": case "wednesday": return "WED";
                case "thu": case "thursday": return "THU";
                case "fri": case "friday": return "FRI";
                case "sat": case "saturday": return "SAT";
                case "sun": case "sunday": return "SUN";
            }
            return string.Empty;
        }

        private static string MakeTaskName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) name = "SQLServerBackupUtility_ScheduledBackup";
            // remove invalid chars for task name
            var sb = new StringBuilder();
            foreach (var c in name)
            {
                if (char.IsLetterOrDigit(c) || c == '_' || c == '-') sb.Append(c);
                else sb.Append('_');
            }
            return sb.ToString();
        }

        private static string QuoteIfNeeded(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "\"\"";
            if (s.Contains(' ')) return "\"" + s + "\"";
            return s;
        }
    }
}
