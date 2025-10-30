using System.Text;

namespace SQLServerBackupUtility.Helpers
{
    public static class Logger
    {
        private static readonly string LogFile = Path.Combine(AppContext.BaseDirectory, "scheduler.log");
        private static readonly object Sync = new object();

        public static void Log(string message)
        {
            try
            {
                var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
              
                lock (Sync)
                {
                    File.AppendAllText(LogFile, line, Encoding.UTF8);
                }
            }
            catch
            {
            }
        }

        public static void LogException(Exception ex, string context = null)
        {
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {context}");
                sb.AppendLine(ex.ToString());
                sb.AppendLine();

                lock (Sync)
                {
                    File.AppendAllText(LogFile, sb.ToString(), Encoding.UTF8);
                }
            }
            catch
            {
            }
        }
    }
}