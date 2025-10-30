using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SQLServerBackupUtility
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void lnkAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://impedro.com",
                    UseShellExecute = true
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
