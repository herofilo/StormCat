namespace StormCat
{
    partial class CompareByFingerprintForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareByFingerprintForm));
            this.ContextHelp = new System.Windows.Forms.HelpProvider();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvComparison = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFingerprint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAddonTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiDisplayAddonReport = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiListAddonContents = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparison)).BeginInit();
            this.cmAddonTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Addons compared:";
            // 
            // dgvComparison
            // 
            this.dgvComparison.AllowUserToAddRows = false;
            this.dgvComparison.AllowUserToDeleteRows = false;
            this.dgvComparison.AllowUserToOrderColumns = true;
            this.dgvComparison.AllowUserToResizeColumns = false;
            this.dgvComparison.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComparison.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPublisher,
            this.colPublished,
            this.colFingerprint,
            this.colLocation});
            this.dgvComparison.ContextMenuStrip = this.cmAddonTable;
            this.dgvComparison.Location = new System.Drawing.Point(6, 25);
            this.dgvComparison.MultiSelect = false;
            this.dgvComparison.Name = "dgvComparison";
            this.dgvComparison.ReadOnly = true;
            this.dgvComparison.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComparison.Size = new System.Drawing.Size(616, 233);
            this.dgvComparison.TabIndex = 3;
            this.dgvComparison.DoubleClick += new System.EventHandler(this.dgvComparison_DoubleClick);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 60;
            // 
            // colPublisher
            // 
            this.colPublisher.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPublisher.DataPropertyName = "Publisher";
            this.colPublisher.HeaderText = "Publisher";
            this.colPublisher.Name = "colPublisher";
            this.colPublisher.ReadOnly = true;
            this.colPublisher.Width = 75;
            // 
            // colPublished
            // 
            this.colPublished.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPublished.DataPropertyName = "LastCompiled";
            this.colPublished.HeaderText = "Published";
            this.colPublished.Name = "colPublished";
            this.colPublished.ReadOnly = true;
            this.colPublished.Width = 78;
            // 
            // colFingerprint
            // 
            this.colFingerprint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFingerprint.DataPropertyName = "FingerPrint";
            this.colFingerprint.HeaderText = "Fingerprint";
            this.colFingerprint.Name = "colFingerprint";
            this.colFingerprint.ReadOnly = true;
            this.colFingerprint.Width = 81;
            // 
            // colLocation
            // 
            this.colLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLocation.DataPropertyName = "Location";
            this.colLocation.HeaderText = "Location";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 73;
            // 
            // cmAddonTable
            // 
            this.cmAddonTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiDisplayAddonReport,
            this.cmiListAddonContents});
            this.cmAddonTable.Name = "cmAssetTable";
            this.cmAddonTable.Size = new System.Drawing.Size(252, 48);
            // 
            // cmiDisplayAddonReport
            // 
            this.cmiDisplayAddonReport.Name = "cmiDisplayAddonReport";
            this.cmiDisplayAddonReport.Size = new System.Drawing.Size(251, 22);
            this.cmiDisplayAddonReport.Text = "Display Report for the Addon";
            this.cmiDisplayAddonReport.Click += new System.EventHandler(this.cmiDisplayAddonReport_Click);
            // 
            // cmiListAddonContents
            // 
            this.cmiListAddonContents.Name = "cmiListAddonContents";
            this.cmiListAddonContents.Size = new System.Drawing.Size(251, 22);
            this.cmiListAddonContents.Text = "List (table) contents of the Addon";
            this.cmiListAddonContents.Click += new System.EventHandler(this.cmiListAddonContents_Click);
            // 
            // CompareByFingerprintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 262);
            this.Controls.Add(this.dgvComparison);
            this.Controls.Add(this.label1);
            this.ContextHelp.SetHelpKeyword(this, "170");
            this.ContextHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CompareByFingerprintForm";
            this.ContextHelp.SetShowHelp(this, true);
            this.Text = "Compare Addons by Fingerprint";
            this.Load += new System.EventHandler(this.CompareByFingerprintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparison)).EndInit();
            this.cmAddonTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider ContextHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvComparison;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublished;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFingerprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.ContextMenuStrip cmAddonTable;
        private System.Windows.Forms.ToolStripMenuItem cmiDisplayAddonReport;
        private System.Windows.Forms.ToolStripMenuItem cmiListAddonContents;
    }
}