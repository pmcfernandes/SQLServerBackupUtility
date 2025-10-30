using SQLServerBackupUtility.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SQLServerBackupUtility
{
    public partial class SchedulerForm : Form
    {
        public ScheduleEntry Result { get; private set; }

        public SchedulerForm()
        {
            InitializeComponent();
            cmbRecurrence.Items.AddRange(new object[] { "One Time", "Daily", "Weekly", "Monthly" });
            cmbRecurrence.SelectedIndex = 0;
        }

        public SchedulerForm(ScheduleEntry existing) : this()
        {
            if (existing == null)
                return;

            txtName.Text = existing.Name ?? string.Empty;

            try
            {
                // Set date and time pickers
                dtpDate.Value = existing.StartDateTime.Date != DateTime.MinValue ? existing.StartDateTime.Date : DateTime.Today;
                // dtpTime expects a DateTime; use today's date with the stored time
                dtpTime.Value = DateTime.Today.Add(existing.StartDateTime.TimeOfDay);
            }
            catch { }

            // Recurrence
            if (!string.IsNullOrEmpty(existing.Recurrence))
            {
                var rec = existing.Recurrence;
                if (rec.Equals("One Time", StringComparison.OrdinalIgnoreCase) || rec.Equals("OneTime", StringComparison.OrdinalIgnoreCase))
                    cmbRecurrence.SelectedItem = "One Time";
                else if (rec.Equals("Daily", StringComparison.OrdinalIgnoreCase))
                    cmbRecurrence.SelectedItem = "Daily";
                else if (rec.Equals("Weekly", StringComparison.OrdinalIgnoreCase))
                    cmbRecurrence.SelectedItem = "Weekly";
                else if (rec.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
                    cmbRecurrence.SelectedItem = "Monthly";
            }

            nudInterval.Value = existing.Interval > 0 ? existing.Interval : nudInterval.Minimum;
            chkRunAs.Checked = existing.RunAsCurrentUser;
            txtUser.Enabled = !chkRunAs.Checked;
            txtUser.Text = existing.UserName ?? string.Empty;
            txtPassword.Enabled = !chkRunAs.Checked;
            txtPassword.Text = existing.Password ?? string.Empty;

            if (!string.IsNullOrEmpty(existing.DaysOfWeek))
            {
                var days = existing.DaysOfWeek.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
                foreach (var d in days)
                {
                    foreach (var c in pnlWeekly.Controls)
                    {
                        if (c is CheckBox cb && cb.Text.Equals(d, StringComparison.OrdinalIgnoreCase))
                        {
                            cb.Checked = true;
                            break;
                        }
                    }
                }
            }

            if (existing.DayOfMonth >= 1 && existing.DayOfMonth <= 31)
            {
                nudDayOfMonth.Value = existing.DayOfMonth;
            }
        }

        private void cmbRecurrence_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = cmbRecurrence.SelectedItem.ToString();
            pnlWeekly.Visible = sel == "Weekly";
            pnlMonthly.Visible = sel == "Monthly";
        }

        private void chkRunAs_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = !chkRunAs.Checked;
            txtPassword.Enabled = !chkRunAs.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var entry = new ScheduleEntry();
            entry.Name = txtName.Text.Trim();
            var date = dtpDate.Value.Date;
            var time = dtpTime.Value.TimeOfDay;
            entry.StartDateTime = date + time;
            entry.Recurrence = cmbRecurrence.SelectedItem.ToString();
            entry.Interval = (int)nudInterval.Value;
            entry.RunAsCurrentUser = chkRunAs.Checked;
            entry.UserName = txtUser.Text.Trim();
            entry.Password = txtPassword.Text; // consider secure handling
            if (cmbRecurrence.SelectedItem.ToString() == "Weekly")
            {
                var days = new System.Collections.Generic.List<string>();
                foreach (var c in pnlWeekly.Controls)
                {
                    if (c is CheckBox cb && cb.Checked)
                        days.Add(cb.Text);
                }
                entry.DaysOfWeek = string.Join(",", days);
            }
            if (cmbRecurrence.SelectedItem.ToString() == "Monthly")
            {
                entry.DayOfMonth = (int)nudDayOfMonth.Value;
            }
            Result = entry;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}