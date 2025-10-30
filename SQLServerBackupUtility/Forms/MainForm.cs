using Microsoft.Data.SqlClient;
using SQLServerBackupUtility.Helpers;
using System.Reflection;
using System.Text.Json;

namespace SQLServerBackupUtility
{
    public partial class MainForm : Form
    {
        private  string StateFile = "";
        private AppState state = new AppState();

        public MainForm()
        {
            InitializeComponent();
            LoadStateFromDefault();
        }

        private void LoadStateFromDefault()
        {
            try
            {
                if (File.Exists(StateFile))
                {
                    LoadStateFromFile(StateFile);
                }
            }
            catch { }
        }

        private void LoadStateFromFile(string path)
        {
            try
            {
                var json = CryptoHelper.ReadPossiblyEncrypted(path);
                state = JsonSerializer.Deserialize<AppState>(json) ?? new AppState();
                txtConnectionString.Text = state.ConnectionString ?? txtConnectionString.Text;
                txtBackupFolder.Text = state.BackupFolder ?? txtBackupFolder.Text;

                btnConnect_Click(tsbLoadState, new EventArgs());
                toolStripStatusLabel1.Text = "Loaded " + path;
                StateFile = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load state: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void SaveStateToFile(string path)
        {
            try
            {
                state.SelectedDatabases = lstDatabases.CheckedItems.Cast<object>().Select(x => x.ToString()).ToList();
                state.ConnectionString = txtConnectionString.Text;
                state.BackupFolder = txtBackupFolder.Text;
                var json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
                CryptoHelper.WritePossiblyEncrypted(path, json);
                toolStripStatusLabel1.Text = "Saved " + path;
                StateFile = path;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save state: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void btnBuildConn_Click(object sender, EventArgs e)
        {
            using (var dlg = new ConnectionBuilderForm(txtConnectionString.Text))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    txtConnectionString.Text = dlg.ConnectionString;
                }
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string connStr = txtConnectionString.Text?.Trim() ?? string.Empty;
            if (!ValidateConnectionString(connStr, out string validationMessage))
            {
                MessageBox.Show(validationMessage, "Invalid connection string", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure TrustServerCertificate=True is present
            string effectiveConnStr = EnsureTrustServerCertificate(connStr);

            try
            {
                toolStripStatusLabel1.Text = "Loading databases...";
                lstDatabases.Items.Clear();

                using (var conn = new SqlConnection(effectiveConnStr))
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand("SELECT [name] FROM sys.databases WHERE database_id >4 ORDER BY name", conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            lstDatabases.Items.Add(reader.GetString(0), state.SelectedDatabases.Contains(reader.GetString(0)));
                        }
                    }
                }

                toolStripStatusLabel1.Text = "Databases loaded";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading databases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error";
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBackupFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void tsbNewState_Click(object sender, EventArgs e)
        {
            // Reset in-memory state and UI
            StateFile = "";

            state = new AppState();
            txtConnectionString.Text = "";
            txtBackupFolder.Text = "";
            lstDatabases.Items.Clear();
            toolStripStatusLabel1.Text = "New state";
        }

        private async Task BackupDatabasesWithLog(bool all)
        {
            var logForm = new LogForm();
            logForm.Show(this);
            logForm.AppendLine("Starting backup...");

            try
            {
                string connStr = txtConnectionString.Text?.Trim() ?? string.Empty;
                string folder = txtBackupFolder.Text?.Trim() ?? string.Empty;

                if (!ValidateConnectionString(connStr, out string connMsg))
                {
                    logForm.AppendLine("Invalid connection string: " + connMsg);
                    MessageBox.Show(connMsg, "Invalid connection string", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    logForm.AppendLine("Backup aborted.");
                    return;
                }

                if (!ValidateBackupFolder(folder, out string folderMsg))
                {
                    logForm.AppendLine("Invalid backup folder: " + folderMsg);
                    MessageBox.Show(folderMsg, "Invalid backup folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    logForm.AppendLine("Backup aborted.");
                    return;
                }

                string effectiveConnStr = EnsureTrustServerCertificate(connStr);

                var dbs = new System.Collections.Generic.List<string>();
                if (all)
                {
                    foreach (var item in lstDatabases.Items)
                        dbs.Add(item.ToString());
                }
                else
                {
                    foreach (var item in lstDatabases.CheckedItems)
                        dbs.Add(item.ToString());
                }

                using (var conn = new SqlConnection(effectiveConnStr))
                {
                    await conn.OpenAsync();
                    foreach (var dbNameRaw in dbs)
                    {
                        if (string.IsNullOrWhiteSpace(dbNameRaw)) continue;
                        logForm.AppendLine("Backing up " + dbNameRaw);
                        try
                        {
                            string dbNameEscaped = EscapeSqlIdentifier(dbNameRaw);
                            var (isDiff, targetPath) = BackupHelper.GetBackupTarget(folder, dbNameRaw);
                            string backupFileEscaped = EscapeSqlString(targetPath);
                            string sql;
                            if (isDiff)
                            {
                                sql = $"BACKUP DATABASE [{dbNameEscaped}] TO DISK = N'{backupFileEscaped}' WITH DIFFERENTIAL, NAME = N'{EscapeSqlString(dbNameRaw)} scheduled backup'";
                            }
                            else
                            {
                                sql = $"BACKUP DATABASE [{dbNameEscaped}] TO DISK = N'{backupFileEscaped}' WITH INIT, NAME = N'{EscapeSqlString(dbNameRaw)} scheduled backup'";
                            }
                            using (var cmd = new SqlCommand(sql, conn))
                            {
                                cmd.CommandTimeout =0;
                                await cmd.ExecuteNonQueryAsync();
                            }
                            logForm.AppendLine("Completed: " + dbNameRaw + (isDiff ? " (differential)" : " (full)"));
                        }
                        catch (Exception ex)
                        {
                            logForm.AppendLine("Error backing up " + dbNameRaw + ": " + ex.Message);
                        }
                    }
                }

                logForm.AppendLine("Backup(s) completed");
            }
            catch (Exception ex)
            {
                logForm.AppendLine("Unhandled error: " + ex.Message);
            }
            finally
            {
                // leave the log window open for user to inspect; they can close it when done
            }
        }

        private async void btnBackupSelected_Click(object sender, EventArgs e)
        {
            if (lstDatabases.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please check one or more databases to backup.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            await BackupDatabasesWithLog(false);
        }

        private async void btnBackupAll_Click(object sender, EventArgs e)
        {
            if (lstDatabases.Items.Count == 0)
            {
                MessageBox.Show("No databases loaded. Click 'Load databases' first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            await BackupDatabasesWithLog(true);
        }

        // Basic validation for a connection string: non-empty and contains a server/data source
        private static bool ValidateConnectionString(string connStr, out string message)
        {
            message = string.Empty;
            if (string.IsNullOrWhiteSpace(connStr))
            {
                message = "Connection string cannot be empty.";
                return false;
            }

            var lower = connStr.ToLowerInvariant();
            if (!lower.Contains("server=") && !lower.Contains("data source=") && !lower.Contains("address="))
            {
                message = "Connection string should include a server (Server= or Data Source=).";
                return false;
            }

            // Optionally ensure we have a Database or Initial Catalog; if not, warn but allow (will connect to default DB)
            if (!lower.Contains("database=") && !lower.Contains("initial catalog="))
            {
                message = "Connection string does not specify a database. The connection will use the default database if available.";
                // return false; // keep as a warning, not a hard failure
            }

            return true;
        }

        private static bool ValidateBackupFolder(string folder, out string message)
        {
            message = string.Empty;
            if (string.IsNullOrWhiteSpace(folder))
            {
                message = "Please select a backup folder.";
                return false;
            }

            try
            {
                string full = Path.GetFullPath(folder);
                if (!Directory.Exists(full))
                {
                    message = "The selected backup folder does not exist.";
                    return false;
                }

                // Try to create and delete a temporary file to verify write permission
                string testFile = Path.Combine(full, "__backup_write_test.tmp");
                try
                {
                    File.WriteAllText(testFile, "test");
                    File.Delete(testFile);
                }
                catch (Exception)
                {
                    message = "The application does not have write permission to the selected backup folder.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                message = "Invalid backup folder: " + ex.Message;
                return false;
            }
        }

        // Ensure connection string includes TrustServerCertificate=True; if not present, append it
        private static string EnsureTrustServerCertificate(string connStr)
        {
            if (string.IsNullOrWhiteSpace(connStr))
                return connStr;

            var lower = connStr.ToLowerInvariant();
            if (lower.Contains("trustservercertificate="))
                return connStr; // already present

            if (!connStr.TrimEnd().EndsWith(";"))
                return connStr + ";TrustServerCertificate=True;";

            return connStr + "TrustServerCertificate=True;";
        }

        // Escape single quotes for SQL string literals
        private static string EscapeSqlString(string s) => s?.Replace("'", "''") ?? string.Empty;

        // Escape ] for SQL bracketed identifiers by doubling ]
        private static string EscapeSqlIdentifier(string identifier) => identifier?.Replace("]", "]]") ?? string.Empty;


        private void btnSchedule_Click(object sender, EventArgs e)
        {
            using (var dlg = new SchedulerForm(state.Schedule))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    var entry = dlg.Result;
                    state.Schedule = entry;
                }
            }
        }

        private void tsbLoadState_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SQL Scheduled Backup State (*.ssb)|*.ssb|All Files (*.*)|*.*";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                LoadStateFromFile(openFileDialog1.FileName);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(StateFile))
            {
                tsbSaveAs_Click(sender, e);
                return;
            }

            SaveState();

            if (!string.IsNullOrEmpty(state.Schedule.Name))
            {
                var result = SchedulerTaskManager.CreateOrUpdateTask(state.Schedule, Environment.ProcessPath?.ToString(), saveFileDialog1.FileName);

                if (result.Success)
                {
                    MessageBox.Show("Scheduled task created/updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to create/update scheduled task: " + result.Output, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SQL Scheduled Backup State (*.ssb)|*.ssb|All Files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                SaveStateToFile(saveFileDialog1.FileName);

                if (!string.IsNullOrEmpty(state.Schedule.Name))
                {
                   var result = SchedulerTaskManager.CreateOrUpdateTask(state.Schedule, Environment.ProcessPath?.ToString(), saveFileDialog1.FileName);

                    if (result.Success)
                    {
                        MessageBox.Show("Scheduled task created/updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to create/update scheduled task: " + result.Output, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                
            }
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            using (var dlg = new AboutForm())
            {
                dlg.ShowDialog(this);
            }
        }

        private void SaveState()
        {
            SaveStateToFile(StateFile);
        }
    }
}