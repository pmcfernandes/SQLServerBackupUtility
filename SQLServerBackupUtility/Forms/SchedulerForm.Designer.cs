namespace SQLServerBackupUtility
{
    partial class SchedulerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblTime = new Label();
            dtpTime = new DateTimePicker();
            lblRecurrence = new Label();
            cmbRecurrence = new ComboBox();
            lblInterval = new Label();
            nudInterval = new NumericUpDown();
            pnlWeekly = new Panel();
            chkMon = new CheckBox();
            chkTue = new CheckBox();
            chkWed = new CheckBox();
            chkThu = new CheckBox();
            chkFri = new CheckBox();
            chkSat = new CheckBox();
            chkSun = new CheckBox();
            pnlMonthly = new Panel();
            lblDayOfMonth = new Label();
            nudDayOfMonth = new NumericUpDown();
            chkRunAs = new CheckBox();
            txtUser = new TextBox();
            lblUser = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudInterval).BeginInit();
            pnlWeekly.SuspendLayout();
            pnlMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDayOfMonth).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 19);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Location = new Point(90, 16);
            txtName.Name = "txtName";
            txtName.Size = new Size(240, 23);
            txtName.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 52);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(90, 48);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(240, 23);
            dtpDate.TabIndex = 3;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(12, 85);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(37, 15);
            lblTime.TabIndex = 4;
            lblTime.Text = "Time:";
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(90, 81);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(120, 23);
            dtpTime.TabIndex = 5;
            // 
            // lblRecurrence
            // 
            lblRecurrence.AutoSize = true;
            lblRecurrence.Location = new Point(12, 118);
            lblRecurrence.Name = "lblRecurrence";
            lblRecurrence.Size = new Size(69, 15);
            lblRecurrence.TabIndex = 6;
            lblRecurrence.Text = "Recurrence:";
            // 
            // cmbRecurrence
            // 
            cmbRecurrence.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRecurrence.FormattingEnabled = true;
            cmbRecurrence.Location = new Point(90, 114);
            cmbRecurrence.Name = "cmbRecurrence";
            cmbRecurrence.Size = new Size(120, 23);
            cmbRecurrence.TabIndex = 7;
            cmbRecurrence.SelectedIndexChanged += cmbRecurrence_SelectedIndexChanged;
            // 
            // lblInterval
            // 
            lblInterval.AutoSize = true;
            lblInterval.Location = new Point(12, 151);
            lblInterval.Name = "lblInterval";
            lblInterval.Size = new Size(49, 15);
            lblInterval.TabIndex = 8;
            lblInterval.Text = "Interval:";
            // 
            // nudInterval
            // 
            nudInterval.Location = new Point(90, 147);
            nudInterval.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            nudInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudInterval.Name = "nudInterval";
            nudInterval.Size = new Size(60, 23);
            nudInterval.TabIndex = 9;
            nudInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // pnlWeekly
            // 
            pnlWeekly.Controls.Add(chkMon);
            pnlWeekly.Controls.Add(chkTue);
            pnlWeekly.Controls.Add(chkWed);
            pnlWeekly.Controls.Add(chkThu);
            pnlWeekly.Controls.Add(chkFri);
            pnlWeekly.Controls.Add(chkSat);
            pnlWeekly.Controls.Add(chkSun);
            pnlWeekly.Location = new Point(90, 180);
            pnlWeekly.Name = "pnlWeekly";
            pnlWeekly.Size = new Size(240, 56);
            pnlWeekly.TabIndex = 10;
            pnlWeekly.Visible = false;
            // 
            // chkMon
            // 
            chkMon.AutoSize = true;
            chkMon.Location = new Point(0, 8);
            chkMon.Name = "chkMon";
            chkMon.Size = new Size(51, 19);
            chkMon.TabIndex = 0;
            chkMon.Text = "Mon";
            chkMon.UseVisualStyleBackColor = true;
            // 
            // chkTue
            // 
            chkTue.AutoSize = true;
            chkTue.Location = new Point(54, 8);
            chkTue.Name = "chkTue";
            chkTue.Size = new Size(46, 19);
            chkTue.TabIndex = 1;
            chkTue.Text = "Tue";
            chkTue.UseVisualStyleBackColor = true;
            // 
            // chkWed
            // 
            chkWed.AutoSize = true;
            chkWed.Location = new Point(104, 8);
            chkWed.Name = "chkWed";
            chkWed.Size = new Size(50, 19);
            chkWed.TabIndex = 2;
            chkWed.Text = "Wed";
            chkWed.UseVisualStyleBackColor = true;
            // 
            // chkThu
            // 
            chkThu.AutoSize = true;
            chkThu.Location = new Point(156, 8);
            chkThu.Name = "chkThu";
            chkThu.Size = new Size(47, 19);
            chkThu.TabIndex = 3;
            chkThu.Text = "Thu";
            chkThu.UseVisualStyleBackColor = true;
            // 
            // chkFri
            // 
            chkFri.AutoSize = true;
            chkFri.Location = new Point(203, 8);
            chkFri.Name = "chkFri";
            chkFri.Size = new Size(39, 19);
            chkFri.TabIndex = 4;
            chkFri.Text = "Fri";
            chkFri.UseVisualStyleBackColor = true;
            // 
            // chkSat
            // 
            chkSat.AutoSize = true;
            chkSat.Location = new Point(0, 32);
            chkSat.Name = "chkSat";
            chkSat.Size = new Size(42, 19);
            chkSat.TabIndex = 5;
            chkSat.Text = "Sat";
            chkSat.UseVisualStyleBackColor = true;
            // 
            // chkSun
            // 
            chkSun.AutoSize = true;
            chkSun.Location = new Point(54, 32);
            chkSun.Name = "chkSun";
            chkSun.Size = new Size(46, 19);
            chkSun.TabIndex = 6;
            chkSun.Text = "Sun";
            chkSun.UseVisualStyleBackColor = true;
            // 
            // pnlMonthly
            // 
            pnlMonthly.Controls.Add(lblDayOfMonth);
            pnlMonthly.Controls.Add(nudDayOfMonth);
            pnlMonthly.Location = new Point(87, 180);
            pnlMonthly.Name = "pnlMonthly";
            pnlMonthly.Size = new Size(240, 40);
            pnlMonthly.TabIndex = 11;
            pnlMonthly.Visible = false;
            // 
            // lblDayOfMonth
            // 
            lblDayOfMonth.AutoSize = true;
            lblDayOfMonth.Location = new Point(0, 8);
            lblDayOfMonth.Name = "lblDayOfMonth";
            lblDayOfMonth.Size = new Size(83, 15);
            lblDayOfMonth.TabIndex = 0;
            lblDayOfMonth.Text = "Day of month:";
            // 
            // nudDayOfMonth
            // 
            nudDayOfMonth.Location = new Point(96, 6);
            nudDayOfMonth.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            nudDayOfMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDayOfMonth.Name = "nudDayOfMonth";
            nudDayOfMonth.Size = new Size(60, 23);
            nudDayOfMonth.TabIndex = 1;
            nudDayOfMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkRunAs
            // 
            chkRunAs.AutoSize = true;
            chkRunAs.Checked = true;
            chkRunAs.CheckState = CheckState.Checked;
            chkRunAs.Location = new Point(12, 259);
            chkRunAs.Name = "chkRunAs";
            chkRunAs.Size = new Size(127, 19);
            chkRunAs.TabIndex = 12;
            chkRunAs.Text = "Run as current user";
            chkRunAs.UseVisualStyleBackColor = true;
            chkRunAs.CheckedChanged += chkRunAs_CheckedChanged;
            // 
            // txtUser
            // 
            txtUser.Enabled = false;
            txtUser.Location = new Point(90, 284);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(240, 23);
            txtUser.TabIndex = 13;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(12, 287);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(33, 15);
            lblUser.TabIndex = 14;
            lblUser.Text = "User:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 317);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 15;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(90, 314);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(240, 23);
            txtPassword.TabIndex = 16;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(176, 362);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 25);
            btnOK.TabIndex = 17;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(257, 362);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // SchedulerForm
            // 
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            ClientSize = new Size(344, 398);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lblUser);
            Controls.Add(txtUser);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(chkRunAs);
            Controls.Add(pnlMonthly);
            Controls.Add(pnlWeekly);
            Controls.Add(nudInterval);
            Controls.Add(lblInterval);
            Controls.Add(cmbRecurrence);
            Controls.Add(lblRecurrence);
            Controls.Add(dtpTime);
            Controls.Add(lblTime);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SchedulerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Schedule Task";
            ((System.ComponentModel.ISupportInitialize)nudInterval).EndInit();
            pnlWeekly.ResumeLayout(false);
            pnlWeekly.PerformLayout();
            pnlMonthly.ResumeLayout(false);
            pnlMonthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDayOfMonth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblRecurrence;
        private System.Windows.Forms.ComboBox cmbRecurrence;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Panel pnlWeekly;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.CheckBox chkThu;
        private System.Windows.Forms.CheckBox chkFri;
        private System.Windows.Forms.CheckBox chkSat;
        private System.Windows.Forms.CheckBox chkSun;
        private System.Windows.Forms.Panel pnlMonthly;
        private System.Windows.Forms.Label lblDayOfMonth;
        private System.Windows.Forms.NumericUpDown nudDayOfMonth;
        private System.Windows.Forms.CheckBox chkRunAs;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}