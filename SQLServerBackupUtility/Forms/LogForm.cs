using System;
using System.Windows.Forms;

namespace SQLServerBackupUtility
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void AppendLine(string line)
        {
            try
            {
                if (this.txtLog.InvokeRequired)
                {
                    this.txtLog.BeginInvoke(new Action(() => AppendLine(line)));
                    return;
                }
                this.txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {line}{Environment.NewLine}");
                this.txtLog.SelectionStart = this.txtLog.Text.Length;
                this.txtLog.ScrollToCaret();
            }
            catch { }
        }
    }
}