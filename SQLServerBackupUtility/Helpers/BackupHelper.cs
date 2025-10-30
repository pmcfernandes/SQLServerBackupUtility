using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SQLServerBackupUtility.Helpers
{
    internal static class BackupHelper
    {
        // Determine whether to perform a differential backup and the target file path
        public static (bool isDifferential, string targetPath) GetBackupTarget(string folder, string dbNameRaw)
        {
            string safeName = new string(dbNameRaw.ToCharArray());
            foreach (var c in Path.GetInvalidFileNameChars())
                safeName = safeName.Replace(c, '_');

            DateTime now = DateTime.Now;
            string datePart = now.ToString("yyyyMMdd");
            string baseFile = Path.Combine(folder, $"{safeName}_{datePart}.bak");

            // Find existing backups for this database
            string pattern = $"{safeName}_*.bak";
            string[] files;
            try
            {
                files = Directory.GetFiles(folder, pattern);
            }
            catch
            {
                files = Array.Empty<string>();
            }

            if (files.Length == 0)
            {
                // no previous backups -> full to baseFile
                return (false, baseFile);
            }

            // Check if any existing backup is in the current month (by parsing yyyyMMdd after the underscore)
            foreach (var f in files)
            {
                var name = Path.GetFileNameWithoutExtension(f);
                var m = Regex.Match(name, $"^{Regex.Escape(safeName)}_(\\d{{8}})");
                if (m.Success)
                {
                    if (DateTime.TryParseExact(m.Groups[1].Value, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime d))
                    {
                        if (d.Year == now.Year && d.Month == now.Month)
                        {
                            // there is a backup this month -> use differential to a diff file
                            string diffFile = Path.Combine(folder, $"{safeName}_{datePart}.bak");
                            return (true, diffFile);
                        }
                    }
                }
            }

            // No backups this month -> start new full
            return (false, baseFile);
        }
    }
}