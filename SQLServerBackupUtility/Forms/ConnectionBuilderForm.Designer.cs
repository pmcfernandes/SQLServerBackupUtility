namespace SQLServerBackupUtility
{
 partial class ConnectionBuilderForm
 {
 private System.ComponentModel.IContainer components = null;
 protected override void Dispose(bool disposing)
 {
 if (disposing && (components != null))
 {
 components.Dispose();
 }
 base.Dispose(disposing);
 }

        private void InitializeComponent()
        {
            lblServer = new Label();
            txtServer = new TextBox();
            lblAuth = new Label();
            rbWindows = new RadioButton();
            rbSql = new RadioButton();
            lblUser = new Label();
            txtUser = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblDatabase = new Label();
            txtDatabase = new TextBox();
            chkEncrypt = new CheckBox();
            chkTrust = new CheckBox();
            btnTest = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(12, 9);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(42, 15);
            lblServer.TabIndex = 0;
            lblServer.Text = "Server:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(113, 6);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(259, 23);
            txtServer.TabIndex = 1;
            // 
            // lblAuth
            // 
            lblAuth.AutoSize = true;
            lblAuth.Location = new Point(12, 42);
            lblAuth.Name = "lblAuth";
            lblAuth.Size = new Size(89, 15);
            lblAuth.TabIndex = 2;
            lblAuth.Text = "Authentication:";
            // 
            // rbWindows
            // 
            rbWindows.AutoSize = true;
            rbWindows.Location = new Point(113, 45);
            rbWindows.Name = "rbWindows";
            rbWindows.Size = new Size(156, 19);
            rbWindows.TabIndex = 3;
            rbWindows.TabStop = true;
            rbWindows.Text = "Windows Authentication";
            rbWindows.UseVisualStyleBackColor = true;
            rbWindows.CheckedChanged += AuthTypeChanged;
            // 
            // rbSql
            // 
            rbSql.AutoSize = true;
            rbSql.Location = new Point(113, 70);
            rbSql.Name = "rbSql";
            rbSql.Size = new Size(163, 19);
            rbSql.TabIndex = 4;
            rbSql.TabStop = true;
            rbSql.Text = "SQL Server Authentication";
            rbSql.UseVisualStyleBackColor = true;
            rbSql.CheckedChanged += AuthTypeChanged;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(12, 98);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(63, 15);
            lblUser.TabIndex = 5;
            lblUser.Text = "Username:";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(113, 95);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(259, 23);
            txtUser.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 131);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(113, 128);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(259, 23);
            txtPassword.TabIndex = 8;
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Location = new Point(12, 164);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(58, 15);
            lblDatabase.TabIndex = 9;
            lblDatabase.Text = "Database:";
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(113, 161);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(259, 23);
            txtDatabase.TabIndex = 10;
            // 
            // chkEncrypt
            // 
            chkEncrypt.AutoSize = true;
            chkEncrypt.Location = new Point(113, 194);
            chkEncrypt.Name = "chkEncrypt";
            chkEncrypt.Size = new Size(66, 19);
            chkEncrypt.TabIndex = 11;
            chkEncrypt.Text = "Encrypt";
            chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // chkTrust
            // 
            chkTrust.AutoSize = true;
            chkTrust.Location = new Point(200, 194);
            chkTrust.Name = "chkTrust";
            chkTrust.Size = new Size(144, 19);
            chkTrust.TabIndex = 12;
            chkTrust.Text = "Trust Server Certificate";
            chkTrust.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(12, 229);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(94, 25);
            btnTest.TabIndex = 13;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(216, 229);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 25);
            btnOK.TabIndex = 14;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(297, 229);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConnectionBuilderForm
            // 
            AcceptButton = btnOK;
            CancelButton = btnCancel;
            ClientSize = new Size(384, 266);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnTest);
            Controls.Add(chkTrust);
            Controls.Add(chkEncrypt);
            Controls.Add(txtDatabase);
            Controls.Add(lblDatabase);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUser);
            Controls.Add(lblUser);
            Controls.Add(rbSql);
            Controls.Add(rbWindows);
            Controls.Add(lblAuth);
            Controls.Add(txtServer);
            Controls.Add(lblServer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConnectionBuilderForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Build connection string";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblServer;
 private System.Windows.Forms.TextBox txtServer;
 private System.Windows.Forms.Label lblAuth;
 private System.Windows.Forms.RadioButton rbWindows;
 private System.Windows.Forms.RadioButton rbSql;
 private System.Windows.Forms.Label lblUser;
 private System.Windows.Forms.TextBox txtUser;
 private System.Windows.Forms.Label lblPassword;
 private System.Windows.Forms.TextBox txtPassword;
 private System.Windows.Forms.Label lblDatabase;
 private System.Windows.Forms.TextBox txtDatabase;
 private System.Windows.Forms.CheckBox chkEncrypt;
 private System.Windows.Forms.CheckBox chkTrust;
 private System.Windows.Forms.Button btnTest;
 private System.Windows.Forms.Button btnOK;
 private System.Windows.Forms.Button btnCancel;
 }
}
