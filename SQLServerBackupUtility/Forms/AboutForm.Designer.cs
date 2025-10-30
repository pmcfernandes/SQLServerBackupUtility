namespace SQLServerBackupUtility
{
partial class AboutForm
{
private System.ComponentModel.IContainer components = null;
private System.Windows.Forms.Label lblTitle;
private System.Windows.Forms.Label lblVersion;
private System.Windows.Forms.Button btnOK;
private System.Windows.Forms.LinkLabel lnkAuthor;
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
            lblTitle = new Label();
            lblVersion = new Label();
            btnOK = new Button();
            lnkAuthor = new LinkLabel();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SQL Server Backup Utility";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(12, 39);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(72, 15);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Version:1.0.0";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(128, 123);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 25);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // lnkAuthor
            // 
            lnkAuthor.AutoSize = true;
            lnkAuthor.Location = new Point(12, 88);
            lnkAuthor.Name = "lnkAuthor";
            lnkAuthor.Size = new Size(119, 15);
            lnkAuthor.TabIndex = 3;
            lnkAuthor.TabStop = true;
            lnkAuthor.Text = "https://impedro.com";
            lnkAuthor.LinkClicked += lnkAuthor_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(138, 15);
            label1.TabIndex = 4;
            label1.Text = "Author: Pedro Fernandes";
            // 
            // AboutForm
            // 
            ClientSize = new Size(320, 160);
            Controls.Add(label1);
            Controls.Add(btnOK);
            Controls.Add(lblVersion);
            Controls.Add(lblTitle);
            Controls.Add(lnkAuthor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }
        private void btnOK_Click(object sender, System.EventArgs e)
{
this.Close();
        }

        private Label label1;
    }
}
