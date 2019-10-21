namespace StormCat
{
    partial class CatalogueComparisonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogueComparisonForm));
            this.dgvComparison = new System.Windows.Forms.DataGridView();
            this.colAddonCatalogue0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddonCatalogue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSaveExcel = new System.Windows.Forms.Button();
            this.cbOnlyDelta = new System.Windows.Forms.CheckBox();
            this.sfdExportExcel = new System.Windows.Forms.SaveFileDialog();
            this.ContextHelp = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparison)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvComparison
            // 
            this.dgvComparison.AllowUserToAddRows = false;
            this.dgvComparison.AllowUserToDeleteRows = false;
            this.dgvComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComparison.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAddonCatalogue0,
            this.colAddonCatalogue1});
            this.dgvComparison.Location = new System.Drawing.Point(3, 50);
            this.dgvComparison.MultiSelect = false;
            this.dgvComparison.Name = "dgvComparison";
            this.dgvComparison.ReadOnly = true;
            this.dgvComparison.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComparison.Size = new System.Drawing.Size(656, 367);
            this.dgvComparison.TabIndex = 0;
            // 
            // colAddonCatalogue0
            // 
            this.colAddonCatalogue0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAddonCatalogue0.DataPropertyName = "AddonCatalogue0";
            this.colAddonCatalogue0.HeaderText = "AddonCatalogue0";
            this.colAddonCatalogue0.Name = "colAddonCatalogue0";
            this.colAddonCatalogue0.ReadOnly = true;
            this.colAddonCatalogue0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAddonCatalogue0.Width = 98;
            // 
            // colAddonCatalogue1
            // 
            this.colAddonCatalogue1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAddonCatalogue1.DataPropertyName = "AddonCatalogue1";
            this.colAddonCatalogue1.HeaderText = "AddonCatalogue1";
            this.colAddonCatalogue1.Name = "colAddonCatalogue1";
            this.colAddonCatalogue1.ReadOnly = true;
            this.colAddonCatalogue1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAddonCatalogue1.Width = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Addons in Catalogues:";
            // 
            // pbSaveExcel
            // 
            this.pbSaveExcel.Location = new System.Drawing.Point(563, 12);
            this.pbSaveExcel.Name = "pbSaveExcel";
            this.pbSaveExcel.Size = new System.Drawing.Size(86, 23);
            this.pbSaveExcel.TabIndex = 2;
            this.pbSaveExcel.Text = "Save to Excel";
            this.pbSaveExcel.UseVisualStyleBackColor = true;
            this.pbSaveExcel.Click += new System.EventHandler(this.pbSaveExcel_Click);
            // 
            // cbOnlyDelta
            // 
            this.cbOnlyDelta.AutoSize = true;
            this.cbOnlyDelta.Location = new System.Drawing.Point(255, 27);
            this.cbOnlyDelta.Name = "cbOnlyDelta";
            this.cbOnlyDelta.Size = new System.Drawing.Size(119, 17);
            this.cbOnlyDelta.TabIndex = 3;
            this.cbOnlyDelta.Text = "List only differences";
            this.cbOnlyDelta.UseVisualStyleBackColor = true;
            this.cbOnlyDelta.CheckedChanged += new System.EventHandler(this.cbOnlyDelta_CheckedChanged);
            // 
            // sfdExportExcel
            // 
            this.sfdExportExcel.DefaultExt = "*.xlsx";
            this.sfdExportExcel.FileName = "Catalogues_Comparison.xlsx";
            this.sfdExportExcel.Filter = "Excel files|*.xlsx";
            // 
            // CatalogueComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 421);
            this.Controls.Add(this.cbOnlyDelta);
            this.Controls.Add(this.pbSaveExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvComparison);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ContextHelp.SetHelpKeyword(this, "360");
            this.ContextHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CatalogueComparisonForm";
            this.ContextHelp.SetShowHelp(this, true);
            this.Text = "Comparison of Catalogues";
            this.Load += new System.EventHandler(this.CatalogueComparisonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparison)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComparison;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pbSaveExcel;
        private System.Windows.Forms.CheckBox cbOnlyDelta;
        private System.Windows.Forms.SaveFileDialog sfdExportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddonCatalogue0;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddonCatalogue1;
        private System.Windows.Forms.HelpProvider ContextHelp;
    }
}