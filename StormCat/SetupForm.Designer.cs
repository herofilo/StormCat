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
            this.pbSelectUserDataFolder = new System.Windows.Forms.Button();
            this.pbSelectInstallFolder = new System.Windows.Forms.Button();
            this.tbMoviestormUserDataPath = new System.Windows.Forms.TextBox();
            this.tbMoviestormInstallPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPathsDefaults = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSave
            // 
            this.pbSave.Location = new System.Drawing.Point(399, 146);
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
            this.pbCancel.Location = new System.Drawing.Point(489, 146);
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
            // folderBrowser
            // 
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 181);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.Text = "Application Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}