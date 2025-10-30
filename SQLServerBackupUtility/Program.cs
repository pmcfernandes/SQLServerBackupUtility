using SQLServerBackupUtility.Helpers;

namespace SQLServerBackupUtility
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Initialize application configuration
            ApplicationConfiguration.Initialize();

            // Command-line: run scheduler non-interactively
            // Usage: SQLServerBackupUtility.exe --run-scheduler [path-to-appstate.json]
            if (args != null && args.Length >0)
            {
                try
                {
                    var cmd = args[0].Trim().ToLowerInvariant();
                    if (cmd == "--run-scheduler" || cmd == "/run-scheduler")
                    {
                        string stateFile = "appstate.ssb";
                        if (args.Length >1 && !string.IsNullOrWhiteSpace(args[1]))
                        {
                            stateFile = args[1];
                        }

                        // Run scheduler and return exit code
                        int rc = SchedulerRunner.RunFromStateFile(stateFile);
                        Environment.Exit(rc);
                        return; // not reached, but explicit
                    }
                }
                catch (Exception ex)
                {
                    // If invoked non-interactively, write to Console and exit with error code
                    try { Console.Error.WriteLine("Scheduler run failed: " + ex.Message); } catch { }
                    Environment.Exit(1);
                    return;
                }
            }

            // Normal GUI startup
            Application.Run(new MainForm());
        }
    }
}