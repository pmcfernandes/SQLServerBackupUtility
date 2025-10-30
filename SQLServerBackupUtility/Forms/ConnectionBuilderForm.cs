using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SQLServerBackupUtility
{
    public partial class ConnectionBuilderForm : Form
    {
        public string ConnectionString { get; private set; }

        public ConnectionBuilderForm()
        {
            InitializeComponent();
            rbWindows.Checked = true;
            UpdateAuthControls();
        }

        public ConnectionBuilderForm(string existing) : this()
        {
            if (!string.IsNullOrEmpty(existing))
            {
                try
                {
                    var builder = new SqlConnectionStringBuilder(existing);
                    txtServer.Text = builder.DataSource;
                    txtDatabase.Text = builder.InitialCatalog;
                    chkEncrypt.Checked = builder.ContainsKey("Encrypt") && Convert.ToBoolean(builder["Encrypt"]);
                    chkTrust.Checked = builder.ContainsKey("TrustServerCertificate") && Convert.ToBoolean(builder["TrustServerCertificate"]);

                    if (builder.IntegratedSecurity)
                    {
                        rbWindows.Checked = true;
                        txtUser.Enabled = false;
                        txtPassword.Enabled = false;
                    }
                    else
                    {
                        rbSql.Checked = true;
                        txtUser.Enabled = true;
                        txtPassword.Enabled = true;
                        txtUser.Text = builder.UserID;
                        txtPassword.Text = builder.Password;
                    }
                }
                catch
                {
                    // ignore parse errors
                }
            }
        }

        private void AuthTypeChanged(object sender, EventArgs e)
        {
            UpdateAuthControls();
        }

        private void UpdateAuthControls()
        {
            bool sqlAuth = rbSql.Checked;
            txtUser.Enabled = sqlAuth;
            txtPassword.Enabled = sqlAuth;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var sb = new SqlConnectionStringBuilder();
            sb.DataSource = txtServer.Text.Trim();
            sb.InitialCatalog = txtDatabase.Text.Trim();
            sb.Encrypt = chkEncrypt.Checked;
            sb.TrustServerCertificate = chkTrust.Checked;

            if (rbWindows.Checked)
            {
                sb.IntegratedSecurity = true;
            }
            else
            {
                sb.IntegratedSecurity = false;
                sb.UserID = txtUser.Text.Trim();
                sb.Password = txtPassword.Text;
            }

            ConnectionString = sb.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            var sb = new SqlConnectionStringBuilder();
            sb.DataSource = txtServer.Text.Trim();
            sb.InitialCatalog = txtDatabase.Text.Trim();
            sb.Encrypt = chkEncrypt.Checked;
            sb.TrustServerCertificate = chkTrust.Checked;
            if (rbWindows.Checked)
                sb.IntegratedSecurity = true;
            else
            {
                sb.IntegratedSecurity = false;
                sb.UserID = txtUser.Text.Trim();
                sb.Password = txtPassword.Text;
            }

            var connStr = sb.ToString();
            btnTest.Enabled = false;
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    MessageBox.Show("Connection succeeded.", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTest.Enabled = true;
            }
        }
    }
}