namespace SQLServerBackupUtility
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblConnectionString = new Label();
            txtConnectionString = new TextBox();
            btnBuildConn = new Button();
            btnConnect = new Button();
            lstDatabases = new CheckedListBox();
            lblDatabases = new Label();
            txtBackupFolder = new TextBox();
            btnBrowse = new Button();
            btnBackupSelected = new Button();
            btnBackupAll = new Button();
            btnSchedule = new Button();
            toolStrip1 = new ToolStrip();
            tsbNewState = new ToolStripButton();
            tsbLoadState = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tsbSaveAs = new ToolStripButton();
            tsbAbout = new ToolStripButton();
            folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblConnectionString
            // 
            lblConnectionString.AutoSize = true;
            lblConnectionString.Location = new Point(12, 43);
            lblConnectionString.Name = "lblConnectionString";
            lblConnectionString.Size = new Size(105, 15);
            lblConnectionString.TabIndex = 0;
            lblConnectionString.Text = "Connection string:";
            // 
            // txtConnectionString
            // 
            txtConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConnectionString.Location = new Point(136, 40);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(450, 23);
            txtConnectionString.TabIndex = 1;
            txtConnectionString.Text = "Server=.\\SQLEXPRESS;Integrated Security=true;Database=master;";
            // 
            // btnBuildConn
            // 
            btnBuildConn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuildConn.Location = new Point(592, 39);
            btnBuildConn.Name = "btnBuildConn";
            btnBuildConn.Size = new Size(50, 25);
            btnBuildConn.TabIndex = 2;
            btnBuildConn.Text = "Build";
            btnBuildConn.UseVisualStyleBackColor = true;
            btnBuildConn.Click += btnBuildConn_Click;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnect.Location = new Point(648, 39);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(140, 25);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Load databases";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lstDatabases
            // 
            lstDatabases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstDatabases.FormattingEnabled = true;
            lstDatabases.Location = new Point(12, 105);
            lstDatabases.Name = "lstDatabases";
            lstDatabases.Size = new Size(776, 256);
            lstDatabases.TabIndex = 4;
            // 
            // lblDatabases
            // 
            lblDatabases.AutoSize = true;
            lblDatabases.Location = new Point(12, 87);
            lblDatabases.Name = "lblDatabases";
            lblDatabases.Size = new Size(63, 15);
            lblDatabases.TabIndex = 5;
            lblDatabases.Text = "Databases:";
            // 
            // txtBackupFolder
            // 
            txtBackupFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBackupFolder.Location = new Point(12, 396);
            txtBackupFolder.Name = "txtBackupFolder";
            txtBackupFolder.Size = new Size(656, 23);
            txtBackupFolder.TabIndex = 6;
            // 
            // btnBrowse
            // 
            btnBrowse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBrowse.Location = new Point(674, 395);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(114, 25);
            btnBrowse.TabIndex = 7;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnBackupSelected
            // 
            btnBackupSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBackupSelected.Location = new Point(422, 436);
            btnBackupSelected.Name = "btnBackupSelected";
            btnBackupSelected.Size = new Size(180, 30);
            btnBackupSelected.TabIndex = 8;
            btnBackupSelected.Text = "Backup Selected";
            btnBackupSelected.UseVisualStyleBackColor = true;
            btnBackupSelected.Click += btnBackupSelected_Click;
            // 
            // btnBackupAll
            // 
            btnBackupAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBackupAll.Location = new Point(608, 436);
            btnBackupAll.Name = "btnBackupAll";
            btnBackupAll.Size = new Size(180, 30);
            btnBackupAll.TabIndex = 9;
            btnBackupAll.Text = "Backup All";
            btnBackupAll.UseVisualStyleBackColor = true;
            btnBackupAll.Click += btnBackupAll_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSchedule.Location = new Point(12, 436);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(120, 30);
            btnSchedule.TabIndex = 10;
            btnSchedule.Text = "Schedule...";
            btnSchedule.UseVisualStyleBackColor = true;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNewState, tsbLoadState, tsbSave, tsbSaveAs, toolStripSeparator1, tsbAbout });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 11;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewState
            // 
            tsbNewState.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNewState.Image = (Image)resources.GetObject("tsbNewState.Image");
            tsbNewState.ImageTransparentColor = Color.Magenta;
            tsbNewState.Name = "tsbNewState";
            tsbNewState.Size = new Size(23, 22);
            tsbNewState.ToolTipText = "New State";
            tsbNewState.Click += tsbNewState_Click;
            // 
            // tsbLoadState
            // 
            tsbLoadState.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbLoadState.Image = (Image)resources.GetObject("tsbLoadState.Image");
            tsbLoadState.ImageTransparentColor = Color.Magenta;
            tsbLoadState.Name = "tsbLoadState";
            tsbLoadState.Size = new Size(23, 22);
            tsbLoadState.ToolTipText = "Load";
            tsbLoadState.Click += tsbLoadState_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(23, 22);
            tsbSave.ToolTipText = "Save";
            tsbSave.Click += tsbSave_Click;
            // 
            // tsbSaveAs
            // 
            tsbSaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSaveAs.Image = (Image)resources.GetObject("tsbSaveAs.Image");
            tsbSaveAs.ImageTransparentColor = Color.Magenta;
            tsbSaveAs.Name = "tsbSaveAs";
            tsbSaveAs.Size = new Size(23, 22);
            tsbSaveAs.ToolTipText = "Save As";
            tsbSaveAs.Click += tsbSaveAs_Click;
            // 
            // tsbAbout
            // 
            tsbAbout.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAbout.Image = (Image)resources.GetObject("tsbAbout.Image");
            tsbAbout.ImageTransparentColor = Color.Magenta;
            tsbAbout.Name = "tsbAbout";
            tsbAbout.Size = new Size(23, 22);
            tsbAbout.ToolTipText = "About";
            tsbAbout.Click += tsbAbout_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog1.Title = "Load application state";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileName = "appstate.json";
            saveFileDialog1.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save application state";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 479);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 17);
            toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 501);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(btnBackupAll);
            Controls.Add(btnSchedule);
            Controls.Add(btnBackupSelected);
            Controls.Add(btnBrowse);
            Controls.Add(txtBackupFolder);
            Controls.Add(lblDatabases);
            Controls.Add(lstDatabases);
            Controls.Add(btnConnect);
            Controls.Add(btnBuildConn);
            Controls.Add(txtConnectionString);
            Controls.Add(lblConnectionString);
            Name = "frmMain";
            Text = "SQL Server Backup Utility";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConnectionString;
        private TextBox txtConnectionString;
        private Button btnBuildConn;
        private Button btnConnect;
        private CheckedListBox lstDatabases;
        private Label lblDatabases;
        private TextBox txtBackupFolder;
        private Button btnBrowse;
        private Button btnBackupSelected;
        private Button btnBackupAll;
        private Button btnSchedule;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbLoadState;
        private ToolStripButton tsbNewState;
        private ToolStripButton tsbSave;
        private ToolStripButton tsbSaveAs;
        private ToolStripButton tsbAbout;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSeparator toolStripSeparator1;
    }
}
