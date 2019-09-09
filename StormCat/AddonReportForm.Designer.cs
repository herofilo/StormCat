namespace MSAddonChecker
{
    partial class AddonReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonReportForm));
            this.tbAddonSummary = new System.Windows.Forms.TextBox();
            this.outputContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiWordwrapOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiIncreaseFont = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDecreaseFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.outputContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAddonSummary
            // 
            this.tbAddonSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddonSummary.ContextMenuStrip = this.outputContextMenu;
            this.tbAddonSummary.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddonSummary.Location = new System.Drawing.Point(1, 5);
            this.tbAddonSummary.Multiline = true;
            this.tbAddonSummary.Name = "tbAddonSummary";
            this.tbAddonSummary.ReadOnly = true;
            this.tbAddonSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAddonSummary.Size = new System.Drawing.Size(791, 507);
            this.tbAddonSummary.TabIndex = 1;
            this.tbAddonSummary.WordWrap = false;
            // 
            // outputContextMenu
            // 
            this.outputContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiCopyToClipboard,
            this.toolStripSeparator1,
            this.cmiWordwrapOutput,
            this.cmiIncreaseFont,
            this.cmiDecreaseFont,
            this.toolStripSeparator2});
            this.outputContextMenu.Name = "outputContextMenu";
            this.outputContextMenu.Size = new System.Drawing.Size(172, 104);
            // 
            // cmiCopyToClipboard
            // 
            this.cmiCopyToClipboard.Name = "cmiCopyToClipboard";
            this.cmiCopyToClipboard.Size = new System.Drawing.Size(171, 22);
            this.cmiCopyToClipboard.Text = "Copy to Clipboard";
            this.cmiCopyToClipboard.Click += new System.EventHandler(this.cmiCopyToClipboard_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(168, 6);
            // 
            // cmiWordwrapOutput
            // 
            this.cmiWordwrapOutput.Checked = true;
            this.cmiWordwrapOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmiWordwrapOutput.Name = "cmiWordwrapOutput";
            this.cmiWordwrapOutput.Size = new System.Drawing.Size(171, 22);
            this.cmiWordwrapOutput.Text = "Wordwrap Output";
            this.cmiWordwrapOutput.Click += new System.EventHandler(this.cmiWordwrapOutput_Click);
            // 
            // cmiIncreaseFont
            // 
            this.cmiIncreaseFont.Name = "cmiIncreaseFont";
            this.cmiIncreaseFont.Size = new System.Drawing.Size(171, 22);
            this.cmiIncreaseFont.Text = "Larger Font Size";
            this.cmiIncreaseFont.Click += new System.EventHandler(this.cmiIncreaseFont_Click);
            // 
            // cmiDecreaseFont
            // 
            this.cmiDecreaseFont.Name = "cmiDecreaseFont";
            this.cmiDecreaseFont.Size = new System.Drawing.Size(171, 22);
            this.cmiDecreaseFont.Text = "Smaller Font Size";
            this.cmiDecreaseFont.Click += new System.EventHandler(this.cmiDecreaseFont_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // AddonReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 514);
            this.Controls.Add(this.tbAddonSummary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddonReportForm";
            this.Text = "AddonReportForm";
            this.Load += new System.EventHandler(this.AddonReportForm_Load);
            this.outputContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAddonSummary;
        private System.Windows.Forms.ContextMenuStrip outputContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmiCopyToClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmiWordwrapOutput;
        private System.Windows.Forms.ToolStripMenuItem cmiIncreaseFont;
        private System.Windows.Forms.ToolStripMenuItem cmiDecreaseFont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}