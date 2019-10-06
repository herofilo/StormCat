namespace StormCat
{
    partial class CatalogueIndexOpsForm
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
            this.lblCurrentCat = new System.Windows.Forms.Label();
            this.lblNewCat = new System.Windows.Forms.Label();
            this.tbCurrentCat = new System.Windows.Forms.TextBox();
            this.tbNewCat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.pbOk = new System.Windows.Forms.Button();
            this.pbCancel = new System.Windows.Forms.Button();
            this.ContextHelp = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lblCurrentCat
            // 
            this.lblCurrentCat.AutoSize = true;
            this.lblCurrentCat.Location = new System.Drawing.Point(12, 19);
            this.lblCurrentCat.Name = "lblCurrentCat";
            this.lblCurrentCat.Size = new System.Drawing.Size(95, 13);
            this.lblCurrentCat.TabIndex = 0;
            this.lblCurrentCat.Text = "Current Catalogue:";
            // 
            // lblNewCat
            // 
            this.lblNewCat.AutoSize = true;
            this.lblNewCat.Location = new System.Drawing.Point(12, 56);
            this.lblNewCat.Name = "lblNewCat";
            this.lblNewCat.Size = new System.Drawing.Size(83, 13);
            this.lblNewCat.TabIndex = 1;
            this.lblNewCat.Text = "New Catalogue:";
            // 
            // tbCurrentCat
            // 
            this.tbCurrentCat.Location = new System.Drawing.Point(113, 19);
            this.tbCurrentCat.Name = "tbCurrentCat";
            this.tbCurrentCat.ReadOnly = true;
            this.tbCurrentCat.Size = new System.Drawing.Size(314, 20);
            this.tbCurrentCat.TabIndex = 2;
            // 
            // tbNewCat
            // 
            this.tbNewCat.Location = new System.Drawing.Point(113, 53);
            this.tbNewCat.Name = "tbNewCat";
            this.tbNewCat.Size = new System.Drawing.Size(314, 20);
            this.tbNewCat.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(81, 92);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(468, 20);
            this.tbDescription.TabIndex = 5;
            // 
            // pbOk
            // 
            this.pbOk.Location = new System.Drawing.Point(485, 14);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(75, 23);
            this.pbOk.TabIndex = 6;
            this.pbOk.Text = "OK";
            this.pbOk.UseVisualStyleBackColor = true;
            this.pbOk.Click += new System.EventHandler(this.pbOk_Click);
            // 
            // pbCancel
            // 
            this.pbCancel.Location = new System.Drawing.Point(485, 51);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(75, 23);
            this.pbCancel.TabIndex = 7;
            this.pbCancel.Text = "Cancel";
            this.pbCancel.UseVisualStyleBackColor = true;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // CatalogueIndexOpsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 136);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNewCat);
            this.Controls.Add(this.tbCurrentCat);
            this.Controls.Add(this.lblNewCat);
            this.Controls.Add(this.lblCurrentCat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ContextHelp.SetHelpKeyword(this, "350");
            this.ContextHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TopicId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatalogueIndexOpsForm";
            this.ContextHelp.SetShowHelp(this, true);
            this.Text = "CatalogueIndexOpsForm";
            this.Load += new System.EventHandler(this.CatalogueIndexOpsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentCat;
        private System.Windows.Forms.Label lblNewCat;
        private System.Windows.Forms.TextBox tbCurrentCat;
        private System.Windows.Forms.TextBox tbNewCat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button pbOk;
        private System.Windows.Forms.Button pbCancel;
        private System.Windows.Forms.HelpProvider ContextHelp;
    }
}