namespace StormCat
{
    partial class AssetSearchResultForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetSearchResultForm));
            this.dgvAssets = new System.Windows.Forms.DataGridView();
            this.colAddonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddonPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetSubtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtraInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInstalled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colContentPack = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAssetTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiSaveToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdExportExcel = new System.Windows.Forms.SaveFileDialog();
            this.lblSummary = new System.Windows.Forms.Label();
            this.pbSaveToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).BeginInit();
            this.cmAssetTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAssets
            // 
            this.dgvAssets.AllowUserToAddRows = false;
            this.dgvAssets.AllowUserToDeleteRows = false;
            this.dgvAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAddonName,
            this.colAddonPublisher,
            this.colAssetType,
            this.colAssetSubtype,
            this.colName,
            this.colTags,
            this.colExtraInfo,
            this.colFree,
            this.colInstalled,
            this.colContentPack,
            this.colLocation});
            this.dgvAssets.ContextMenuStrip = this.cmAssetTable;
            this.dgvAssets.Location = new System.Drawing.Point(0, 38);
            this.dgvAssets.MultiSelect = false;
            this.dgvAssets.Name = "dgvAssets";
            this.dgvAssets.ReadOnly = true;
            this.dgvAssets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssets.Size = new System.Drawing.Size(860, 533);
            this.dgvAssets.TabIndex = 1;
            this.dgvAssets.DoubleClick += new System.EventHandler(this.dgvAssets_DoubleClick);
            // 
            // colAddonName
            // 
            this.colAddonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAddonName.DataPropertyName = "AddonName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAddonName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colAddonName.HeaderText = "Addon";
            this.colAddonName.Name = "colAddonName";
            this.colAddonName.ReadOnly = true;
            this.colAddonName.Width = 63;
            // 
            // colAddonPublisher
            // 
            this.colAddonPublisher.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAddonPublisher.DataPropertyName = "AddonPublisher";
            this.colAddonPublisher.HeaderText = "Publisher";
            this.colAddonPublisher.Name = "colAddonPublisher";
            this.colAddonPublisher.ReadOnly = true;
            this.colAddonPublisher.Width = 75;
            // 
            // colAssetType
            // 
            this.colAssetType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAssetType.DataPropertyName = "AssetType";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAssetType.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAssetType.HeaderText = "Asset Type";
            this.colAssetType.Name = "colAssetType";
            this.colAssetType.ReadOnly = true;
            this.colAssetType.Width = 85;
            // 
            // colAssetSubtype
            // 
            this.colAssetSubtype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAssetSubtype.DataPropertyName = "AssetSubType";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colAssetSubtype.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAssetSubtype.HeaderText = "Subtype";
            this.colAssetSubtype.Name = "colAssetSubtype";
            this.colAssetSubtype.ReadOnly = true;
            this.colAssetSubtype.Width = 71;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.DefaultCellStyle = dataGridViewCellStyle4;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 60;
            // 
            // colTags
            // 
            this.colTags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTags.DataPropertyName = "Tags";
            this.colTags.HeaderText = "Tags";
            this.colTags.Name = "colTags";
            this.colTags.ReadOnly = true;
            this.colTags.Width = 56;
            // 
            // colExtraInfo
            // 
            this.colExtraInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colExtraInfo.DataPropertyName = "ExtraInfo";
            this.colExtraInfo.HeaderText = "Extra Info";
            this.colExtraInfo.Name = "colExtraInfo";
            this.colExtraInfo.ReadOnly = true;
            this.colExtraInfo.Width = 77;
            // 
            // colFree
            // 
            this.colFree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colFree.DataPropertyName = "Free";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.NullValue = false;
            this.colFree.DefaultCellStyle = dataGridViewCellStyle5;
            this.colFree.HeaderText = "Free";
            this.colFree.Name = "colFree";
            this.colFree.ReadOnly = true;
            this.colFree.Width = 34;
            // 
            // colInstalled
            // 
            this.colInstalled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colInstalled.DataPropertyName = "Installed";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle6.NullValue = false;
            this.colInstalled.DefaultCellStyle = dataGridViewCellStyle6;
            this.colInstalled.HeaderText = "Installed";
            this.colInstalled.Name = "colInstalled";
            this.colInstalled.ReadOnly = true;
            this.colInstalled.Width = 52;
            // 
            // colContentPack
            // 
            this.colContentPack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colContentPack.DataPropertyName = "ContentPack";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle7.NullValue = false;
            this.colContentPack.DefaultCellStyle = dataGridViewCellStyle7;
            this.colContentPack.HeaderText = "Cont.Pack";
            this.colContentPack.Name = "colContentPack";
            this.colContentPack.ReadOnly = true;
            this.colContentPack.Width = 63;
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
            // cmAssetTable
            // 
            this.cmAssetTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiSaveToExcel});
            this.cmAssetTable.Name = "cmAssetTable";
            this.cmAssetTable.Size = new System.Drawing.Size(166, 26);
            this.cmAssetTable.Opening += new System.ComponentModel.CancelEventHandler(this.cmAssetTable_Opening);
            // 
            // cmiSaveToExcel
            // 
            this.cmiSaveToExcel.Name = "cmiSaveToExcel";
            this.cmiSaveToExcel.Size = new System.Drawing.Size(165, 22);
            this.cmiSaveToExcel.Text = "Save To Excel File";
            this.cmiSaveToExcel.Click += new System.EventHandler(this.cmiSaveToExcel_Click);
            // 
            // sfdExportExcel
            // 
            this.sfdExportExcel.DefaultExt = "*.xlsx";
            this.sfdExportExcel.FileName = "Asset_Search_Result.xlsx";
            this.sfdExportExcel.Filter = "Excel files|*.xlsx";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(12, 9);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(88, 13);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "Assets found: ";
            // 
            // pbSaveToExcel
            // 
            this.pbSaveToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSaveToExcel.Location = new System.Drawing.Point(743, 9);
            this.pbSaveToExcel.Name = "pbSaveToExcel";
            this.pbSaveToExcel.Size = new System.Drawing.Size(106, 23);
            this.pbSaveToExcel.TabIndex = 3;
            this.pbSaveToExcel.Text = "Save to Excel";
            this.pbSaveToExcel.UseVisualStyleBackColor = true;
            this.pbSaveToExcel.Click += new System.EventHandler(this.pbSaveToExcel_Click);
            // 
            // AssetSearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 573);
            this.Controls.Add(this.pbSaveToExcel);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.dgvAssets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AssetSearchResultForm";
            this.Text = "Assets Found";
            this.Load += new System.EventHandler(this.AssetSearchResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssets)).EndInit();
            this.cmAssetTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssets;
        private System.Windows.Forms.ContextMenuStrip cmAssetTable;
        private System.Windows.Forms.ToolStripMenuItem cmiSaveToExcel;
        private System.Windows.Forms.SaveFileDialog sfdExportExcel;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button pbSaveToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddonPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetSubtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExtraInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFree;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInstalled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colContentPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
    }
}