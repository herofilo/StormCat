namespace StormCat
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.pbSave = new System.Windows.Forms.Button();
            this.pbCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbPathsDefaults = new System.Windows.Forms.Button();
            this.pbSelectUserDataFolder = new System.Windows.Forms.Button();
            this.pbSelectInstallFolder = new System.Windows.Forms.Button();
            this.tbMoviestormUserDataPath = new System.Windows.Forms.TextBox();
            this.tbMoviestormInstallPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.gbDupCriteria = new System.Windows.Forms.GroupBox();
            this.pbDupCriteriaDefault = new System.Windows.Forms.Button();
            this.cbDupDetMeshSize = new System.Windows.Forms.CheckBox();
            this.cbDupDetAssetCount = new System.Windows.Forms.CheckBox();
            this.cbDupDetRecompilable = new System.Windows.Forms.CheckBox();
            this.cbDupDetLastPublished = new System.Windows.Forms.CheckBox();
            this.cbDupDetName = new System.Windows.Forms.CheckBox();
            this.ContextHelp = new System.Windows.Forms.HelpProvider();
            this.cbDupDetPublisher = new System.Windows.Forms.CheckBox();
            this.cbDupDetFileCount = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gbDupCriteria.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSave
            // 
            this.pbSave.Location = new System.Drawing.Point(491, 192);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(75, 23);
            this.pbSave.TabIndex = 0;
            this.pbSave.Text = "Save";
            this.pbSave.UseVisualStyleBackColor = true;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.pbCancel.Location = new System.Drawing.Point(491, 221);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(75, 23);
            this.pbCancel.TabIndex = 1;
            this.pbCancel.Text = "Cancel";
            this.pbCancel.UseVisualStyleBackColor = true;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbPathsDefaults);
            this.groupBox1.Controls.Add(this.pbSelectUserDataFolder);
            this.groupBox1.Controls.Add(this.pbSelectInstallFolder);
            this.groupBox1.Controls.Add(this.tbMoviestormUserDataPath);
            this.groupBox1.Controls.Add(this.tbMoviestormInstallPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 115);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Moviestorm Folders";
            // 
            // pbPathsDefaults
            // 
            this.pbPathsDefaults.Location = new System.Drawing.Point(477, 85);
            this.pbPathsDefaults.Name = "pbPathsDefaults";
            this.pbPathsDefaults.Size = new System.Drawing.Size(75, 23);
            this.pbPathsDefaults.TabIndex = 6;
            this.pbPathsDefaults.Text = "Defaults";
            this.pbPathsDefaults.UseVisualStyleBackColor = true;
            this.pbPathsDefaults.Click += new System.EventHandler(this.pbPathsDefaults_Click);
            // 
            // pbSelectUserDataFolder
            // 
            this.pbSelectUserDataFolder.Image = ((System.Drawing.Image)(resources.GetObject("pbSelectUserDataFolder.Image")));
            this.pbSelectUserDataFolder.Location = new System.Drawing.Point(521, 55);
            this.pbSelectUserDataFolder.Name = "pbSelectUserDataFolder";
            this.pbSelectUserDataFolder.Size = new System.Drawing.Size(31, 23);
            this.pbSelectUserDataFolder.TabIndex = 5;
            this.pbSelectUserDataFolder.UseVisualStyleBackColor = true;
            this.pbSelectUserDataFolder.Click += new System.EventHandler(this.pbSelectUserDataFolder_Click);
            // 
            // pbSelectInstallFolder
            // 
            this.pbSelectInstallFolder.Image = ((System.Drawing.Image)(resources.GetObject("pbSelectInstallFolder.Image")));
            this.pbSelectInstallFolder.Location = new System.Drawing.Point(521, 26);
            this.pbSelectInstallFolder.Name = "pbSelectInstallFolder";
            this.pbSelectInstallFolder.Size = new System.Drawing.Size(31, 23);
            this.pbSelectInstallFolder.TabIndex = 4;
            this.pbSelectInstallFolder.UseVisualStyleBackColor = true;
            this.pbSelectInstallFolder.Click += new System.EventHandler(this.pbSelectInstallFolder_Click);
            // 
            // tbMoviestormUserDataPath
            // 
            this.tbMoviestormUserDataPath.Location = new System.Drawing.Point(107, 53);
            this.tbMoviestormUserDataPath.Name = "tbMoviestormUserDataPath";
            this.tbMoviestormUserDataPath.ReadOnly = true;
            this.tbMoviestormUserDataPath.Size = new System.Drawing.Size(408, 20);
            this.tbMoviestormUserDataPath.TabIndex = 3;
            // 
            // tbMoviestormInstallPath
            // 
            this.tbMoviestormInstallPath.Location = new System.Drawing.Point(107, 23);
            this.tbMoviestormInstallPath.Name = "tbMoviestormInstallPath";
            this.tbMoviestormInstallPath.ReadOnly = true;
            this.tbMoviestormInstallPath.Size = new System.Drawing.Size(408, 20);
            this.tbMoviestormInstallPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Data Folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Installation Folder:";
            // 
            // folderBrowser
            // 
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // gbDupCriteria
            // 
            this.gbDupCriteria.Controls.Add(this.cbDupDetFileCount);
            this.gbDupCriteria.Controls.Add(this.cbDupDetPublisher);
            this.gbDupCriteria.Controls.Add(this.pbDupCriteriaDefault);
            this.gbDupCriteria.Controls.Add(this.cbDupDetMeshSize);
            this.gbDupCriteria.Controls.Add(this.cbDupDetAssetCount);
            this.gbDupCriteria.Controls.Add(this.cbDupDetRecompilable);
            this.gbDupCriteria.Controls.Add(this.cbDupDetLastPublished);
            this.gbDupCriteria.Controls.Add(this.cbDupDetName);
            this.gbDupCriteria.Location = new System.Drawing.Point(3, 133);
            this.gbDupCriteria.Name = "gbDupCriteria";
            this.gbDupCriteria.Size = new System.Drawing.Size(464, 92);
            this.gbDupCriteria.TabIndex = 3;
            this.gbDupCriteria.TabStop = false;
            this.gbDupCriteria.Text = "Duplicate Detection Criteria";
            // 
            // pbDupCriteriaDefault
            // 
            this.pbDupCriteriaDefault.Location = new System.Drawing.Point(383, 61);
            this.pbDupCriteriaDefault.Name = "pbDupCriteriaDefault";
            this.pbDupCriteriaDefault.Size = new System.Drawing.Size(75, 23);
            this.pbDupCriteriaDefault.TabIndex = 5;
            this.pbDupCriteriaDefault.Text = "Defaults";
            this.pbDupCriteriaDefault.UseVisualStyleBackColor = true;
            this.pbDupCriteriaDefault.Click += new System.EventHandler(this.pbDupCriteriaDefault_Click);
            // 
            // cbDupDetMeshSize
            // 
            this.cbDupDetMeshSize.AutoSize = true;
            this.cbDupDetMeshSize.Location = new System.Drawing.Point(347, 19);
            this.cbDupDetMeshSize.Name = "cbDupDetMeshSize";
            this.cbDupDetMeshSize.Size = new System.Drawing.Size(101, 17);
            this.cbDupDetMeshSize.TabIndex = 4;
            this.cbDupDetMeshSize.Text = "Mesh Data Size";
            this.cbDupDetMeshSize.UseVisualStyleBackColor = true;
            // 
            // cbDupDetAssetCount
            // 
            this.cbDupDetAssetCount.AutoSize = true;
            this.cbDupDetAssetCount.Location = new System.Drawing.Point(175, 42);
            this.cbDupDetAssetCount.Name = "cbDupDetAssetCount";
            this.cbDupDetAssetCount.Size = new System.Drawing.Size(83, 17);
            this.cbDupDetAssetCount.TabIndex = 3;
            this.cbDupDetAssetCount.Text = "Asset Count";
            this.cbDupDetAssetCount.UseVisualStyleBackColor = true;
            // 
            // cbDupDetRecompilable
            // 
            this.cbDupDetRecompilable.AutoSize = true;
            this.cbDupDetRecompilable.Checked = true;
            this.cbDupDetRecompilable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDupDetRecompilable.Enabled = false;
            this.cbDupDetRecompilable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDupDetRecompilable.Location = new System.Drawing.Point(9, 65);
            this.cbDupDetRecompilable.Name = "cbDupDetRecompilable";
            this.cbDupDetRecompilable.Size = new System.Drawing.Size(130, 17);
            this.cbDupDetRecompilable.TabIndex = 2;
            this.cbDupDetRecompilable.Text = "Recompilable Flag";
            this.cbDupDetRecompilable.UseVisualStyleBackColor = true;
            // 
            // cbDupDetLastPublished
            // 
            this.cbDupDetLastPublished.AutoSize = true;
            this.cbDupDetLastPublished.Checked = true;
            this.cbDupDetLastPublished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDupDetLastPublished.Location = new System.Drawing.Point(175, 19);
            this.cbDupDetLastPublished.Name = "cbDupDetLastPublished";
            this.cbDupDetLastPublished.Size = new System.Drawing.Size(140, 17);
            this.cbDupDetLastPublished.TabIndex = 1;
            this.cbDupDetLastPublished.Text = "Last Published Datetime";
            this.cbDupDetLastPublished.UseVisualStyleBackColor = true;
            // 
            // cbDupDetName
            // 
            this.cbDupDetName.AutoSize = true;
            this.cbDupDetName.Checked = true;
            this.cbDupDetName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDupDetName.Enabled = false;
            this.cbDupDetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDupDetName.Location = new System.Drawing.Point(9, 19);
            this.cbDupDetName.Name = "cbDupDetName";
            this.cbDupDetName.Size = new System.Drawing.Size(98, 17);
            this.cbDupDetName.TabIndex = 0;
            this.cbDupDetName.Text = "Addon Name";
            this.cbDupDetName.UseVisualStyleBackColor = true;
            // 
            // cbDupDetPublisher
            // 
            this.cbDupDetPublisher.AutoSize = true;
            this.cbDupDetPublisher.Checked = true;
            this.cbDupDetPublisher.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDupDetPublisher.Enabled = false;
            this.cbDupDetPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDupDetPublisher.Location = new System.Drawing.Point(9, 42);
            this.cbDupDetPublisher.Name = "cbDupDetPublisher";
            this.cbDupDetPublisher.Size = new System.Drawing.Size(78, 17);
            this.cbDupDetPublisher.TabIndex = 6;
            this.cbDupDetPublisher.Text = "Publisher";
            this.cbDupDetPublisher.UseVisualStyleBackColor = true;
            // 
            // cbDupDetFileCount
            // 
            this.cbDupDetFileCount.AutoSize = true;
            this.cbDupDetFileCount.Location = new System.Drawing.Point(175, 65);
            this.cbDupDetFileCount.Name = "cbDupDetFileCount";
            this.cbDupDetFileCount.Size = new System.Drawing.Size(100, 17);
            this.cbDupDetFileCount.TabIndex = 7;
            this.cbDupDetFileCount.Text = "Total File Count";
            this.cbDupDetFileCount.UseVisualStyleBackColor = true;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 256);
            this.Controls.Add(this.gbDupCriteria);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ContextHelp.SetHelpKeyword(this, "1000");
            this.ContextHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ContextHelp.SetShowHelp(this, true);
            this.Text = "Application Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDupCriteria.ResumeLayout(false);
            this.gbDupCriteria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pbSave;
        private System.Windows.Forms.Button pbCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMoviestormUserDataPath;
        private System.Windows.Forms.TextBox tbMoviestormInstallPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pbSelectUserDataFolder;
        private System.Windows.Forms.Button pbSelectInstallFolder;
        private System.Windows.Forms.Button pbPathsDefaults;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.GroupBox gbDupCriteria;
        private System.Windows.Forms.CheckBox cbDupDetName;
        private System.Windows.Forms.CheckBox cbDupDetRecompilable;
        private System.Windows.Forms.CheckBox cbDupDetLastPublished;
        private System.Windows.Forms.CheckBox cbDupDetMeshSize;
        private System.Windows.Forms.CheckBox cbDupDetAssetCount;
        private System.Windows.Forms.Button pbDupCriteriaDefault;
        private System.Windows.Forms.HelpProvider ContextHelp;
        private System.Windows.Forms.CheckBox cbDupDetPublisher;
        private System.Windows.Forms.CheckBox cbDupDetFileCount;
    }
}