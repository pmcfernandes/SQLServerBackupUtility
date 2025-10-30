using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SQLServerBackupUtility.Helpers
{
    public static class SchedulerRunner
    {
        public static async Task<int> RunFromStateFileAsync(string stateFile)
        {
            try
            {
                Logger.Log($"Scheduler run started, stateFile={stateFile}");
                if (!File.Exists(stateFile))
                {
                    Logger.Log($"State file not found: {stateFile}");
                    return 2;
                }

                var json = CryptoHelper.ReadPossiblyEncrypted(stateFile);
                var state = JsonSerializer.Deserialize<AppState>(json);
                if (state == null)
                {
                    Logger.Log("State deserialized to null");
                    return 3;
                }
                if (string.IsNullOrWhiteSpace(state.ConnectionString) || string.IsNullOrWhiteSpace(state.BackupFolder))
                {
                    Logger.Log("Connection string or backup folder missing");
                    return 4;
                }
                if (state.SelectedDatabases == null || state.SelectedDatabases.Count == 0)
                {
                    Logger.Log("No selected databases to backup");
                    return 5;
                }

                string effectiveConnStr = state.ConnectionString;
                if (!effectiveConnStr.ToLowerInvariant().Contains("trustservercertificate="))
                    effectiveConnStr = effectiveConnStr.TrimEnd() + ";TrustServerCertificate=True;";

                try
                {
                    using (var conn = new SqlConnection(effectiveConnStr))
                    {
                        await conn.OpenAsync();
                        foreach (var dbNameRaw in state.SelectedDatabases)
                        {
                            if (string.IsNullOrWhiteSpace(dbNameRaw)) continue;
                            try
                            {
                                string dbNameEscaped = dbNameRaw.Replace("]", "]]");
                                // Determine backup type and target
                                var (isDiff, targetPath) = BackupHelper.GetBackupTarget(state.BackupFolder, dbNameRaw);
                                string backupFileEscaped = targetPath.Replace("'", "''");
                                string sql;
                                if (isDiff)
                                {
                                    // For differential backups, append to the file (do not use INIT)
                                    sql = $"BACKUP DATABASE [{dbNameEscaped}] TO DISK = N'{backupFileEscaped}' WITH DIFFERENTIAL, NAME = N'{dbNameRaw} scheduled backup'";
                                }
                                else
                                {
                                    // Full backups overwrite the target file
                                    sql = $"BACKUP DATABASE [{dbNameEscaped}] TO DISK = N'{backupFileEscaped}' WITH INIT, NAME = N'{dbNameRaw} scheduled backup'";
                                }

                                Logger.Log($"Backing up {dbNameRaw} to {targetPath} (diff={isDiff})");
                                using (var cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.CommandTimeout = 0;
                                    await cmd.ExecuteNonQueryAsync();
                                }
                                Logger.Log($"Backup completed for {dbNameRaw}");
                            }
                            catch (Exception exDb)
                            {
                                Logger.LogException(exDb, $"Error backing up {dbNameRaw}");
                            }
                        }
                    }
                }
                catch (Exception exConn)
                {
                    Logger.LogException(exConn, "Error opening SQL connection or running backups");
                    return 6;
                }

                // update last run timestamp in file
                if (state.Schedule != null)
                {
                    state.Schedule.LastRun = DateTime.Now;
                    var outJson = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
                    CryptoHelper.WritePossiblyEncrypted(stateFile, outJson);
                }

                Logger.Log("Scheduler run completed successfully");
                return 0;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, "Scheduler run failed");
                return 1;
            }
        }

        public static int RunFromStateFile(string stateFile)
        {
            return RunFromStateFileAsync(stateFile).GetAwaiter().GetResult();
        }
    }
}