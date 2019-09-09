namespace MSAddonChecker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.outputContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiWordwrapOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiIncreaseFont = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDecreaseFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiClearOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.pDragFiles = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOnlyIssues = new System.Windows.Forms.CheckBox();
            this.cbShowContents = new System.Windows.Forms.CheckBox();
            this.cbForceAllAnimationsDisplay = new System.Windows.Forms.CheckBox();
            this.cbListGestureAnimations = new System.Windows.Forms.CheckBox();
            this.cbListWeirdGestureGaitVerbs = new System.Windows.Forms.CheckBox();
            this.pnlDisplayContents = new System.Windows.Forms.Panel();
            this.cbCompactDupVerbsByName = new System.Windows.Forms.CheckBox();
            this.cbCorrectDisguisedAddonFiles = new System.Windows.Forms.CheckBox();
            this.cbDeleteSourceArchive = new System.Windows.Forms.CheckBox();
            this.pbCheckInstalled = new System.Windows.Forms.Button();
            this.cbAssetsToCheck = new System.Windows.Forms.ComboBox();
            this.pbSetup = new System.Windows.Forms.Button();
            this.pbLoadDefaultOptions = new System.Windows.Forms.Button();
            this.pbSaveDefaultOptions = new System.Windows.Forms.Button();
            this.cbAppendToDatabase = new System.Windows.Forms.CheckBox();
            this.cbRefreshItemsInDatabase = new System.Windows.Forms.CheckBox();
            this.tcMainForm = new System.Windows.Forms.TabControl();
            this.tpDatabase = new System.Windows.Forms.TabPage();
            this.lblTipTable = new System.Windows.Forms.Label();
            this.lblAddonDbFilename = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbsAssetTags = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pbsSearch = new System.Windows.Forms.Button();
            this.pbsResetAssetCriteria = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbatClearAll = new System.Windows.Forms.Button();
            this.pbatSetAll = new System.Windows.Forms.Button();
            this.cbatSfx = new System.Windows.Forms.CheckBox();
            this.cbatSky = new System.Windows.Forms.CheckBox();
            this.cbatSound = new System.Windows.Forms.CheckBox();
            this.cbatFilter = new System.Windows.Forms.CheckBox();
            this.cbatMaterial = new System.Windows.Forms.CheckBox();
            this.cbatVerb = new System.Windows.Forms.CheckBox();
            this.cbatProp = new System.Windows.Forms.CheckBox();
            this.cbatDecal = new System.Windows.Forms.CheckBox();
            this.cbatBodyPart = new System.Windows.Forms.CheckBox();
            this.tbsAssetName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbsResetAddonCriteria = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbsAddonLocation = new System.Windows.Forms.TextBox();
            this.tbsAddonPublisher = new System.Windows.Forms.TextBox();
            this.tbsAddonName = new System.Windows.Forms.TextBox();
            this.cbascType = new System.Windows.Forms.ComboBox();
            this.cbascInstalled = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbSaveAddonDatabase = new System.Windows.Forms.Button();
            this.pbLoadAddonDatabase = new System.Windows.Forms.Button();
            this.pbInitAddonDatabase = new System.Windows.Forms.Button();
            this.pbClearAddonDatabase = new System.Windows.Forms.Button();
            this.pbSetup1 = new System.Windows.Forms.Button();
            this.dgvAddons = new System.Windows.Forms.DataGridView();
            this.dgvAddonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAddonPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAddonInstalled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvAddonFree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvAddonRecompilable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvAddonContentPack = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvAddonLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAddonTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiDisplayReport = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiShowContents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiRefreshAddon = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDeleteAddon = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAddonCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpChecking = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ofdLoadAddonDb = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveAddonDb = new System.Windows.Forms.SaveFileDialog();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiCredits = new System.Windows.Forms.ToolStripMenuItem();
            this.outputContextMenu.SuspendLayout();
            this.pDragFiles.SuspendLayout();
            this.pnlDisplayContents.SuspendLayout();
            this.tcMainForm.SuspendLayout();
            this.tpDatabase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).BeginInit();
            this.cmAddonTable.SuspendLayout();
            this.tpChecking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbOutput
            // 
            this.tbOutput.ContextMenuStrip = this.outputContextMenu;
            this.tbOutput.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(6, 191);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(998, 394);
            this.tbOutput.TabIndex = 0;
            this.tbOutput.WordWrap = false;
            // 
            // outputContextMenu
            // 
            this.outputContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiCopyToClipboard,
            this.toolStripSeparator1,
            this.cmiWordwrapOutput,
            this.cmiIncreaseFont,
            this.cmiDecreaseFont,
            this.toolStripSeparator2,
            this.cmiClearOutput});
            this.outputContextMenu.Name = "outputContextMenu";
            this.outputContextMenu.Size = new System.Drawing.Size(172, 126);
            this.outputContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.outputContextMenu_Opening);
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
            // cmiClearOutput
            // 
            this.cmiClearOutput.Name = "cmiClearOutput";
            this.cmiClearOutput.Size = new System.Drawing.Size(171, 22);
            this.cmiClearOutput.Text = "Clear Output";
            this.cmiClearOutput.Click += new System.EventHandler(this.cmiClearOutput_Click);
            // 
            // pDragFiles
            // 
            this.pDragFiles.AllowDrop = true;
            this.pDragFiles.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pDragFiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDragFiles.Controls.Add(this.label1);
            this.pDragFiles.Location = new System.Drawing.Point(6, 8);
            this.pDragFiles.Name = "pDragFiles";
            this.pDragFiles.Size = new System.Drawing.Size(807, 60);
            this.pDragFiles.TabIndex = 1;
            this.pDragFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.pDragFiles_DragDrop);
            this.pDragFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.pDragFiles_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag  and drop here for checking:  addon files, Sketchup files, folders, and/or Z" +
    "IP/RAR/7z archives in any combination";
            // 
            // cbOnlyIssues
            // 
            this.cbOnlyIssues.AutoSize = true;
            this.cbOnlyIssues.Location = new System.Drawing.Point(7, 80);
            this.cbOnlyIssues.Name = "cbOnlyIssues";
            this.cbOnlyIssues.Size = new System.Drawing.Size(113, 17);
            this.cbOnlyIssues.TabIndex = 2;
            this.cbOnlyIssues.Text = "Just Report Issues";
            this.cbOnlyIssues.UseVisualStyleBackColor = true;
            this.cbOnlyIssues.CheckedChanged += new System.EventHandler(this.cbOnlyIssues_CheckedChanged);
            // 
            // cbShowContents
            // 
            this.cbShowContents.AutoSize = true;
            this.cbShowContents.Checked = true;
            this.cbShowContents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowContents.Location = new System.Drawing.Point(137, 80);
            this.cbShowContents.Name = "cbShowContents";
            this.cbShowContents.Size = new System.Drawing.Size(155, 17);
            this.cbShowContents.TabIndex = 3;
            this.cbShowContents.Text = "Detailed Info about Addons";
            this.cbShowContents.UseVisualStyleBackColor = true;
            this.cbShowContents.Click += new System.EventHandler(this.cbShowContents_Click);
            // 
            // cbForceAllAnimationsDisplay
            // 
            this.cbForceAllAnimationsDisplay.AutoSize = true;
            this.cbForceAllAnimationsDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbForceAllAnimationsDisplay.Location = new System.Drawing.Point(10, 3);
            this.cbForceAllAnimationsDisplay.Name = "cbForceAllAnimationsDisplay";
            this.cbForceAllAnimationsDisplay.Size = new System.Drawing.Size(129, 17);
            this.cbForceAllAnimationsDisplay.TabIndex = 4;
            this.cbForceAllAnimationsDisplay.Text = "List All Animation Files";
            this.cbForceAllAnimationsDisplay.UseVisualStyleBackColor = true;
            // 
            // cbListGestureAnimations
            // 
            this.cbListGestureAnimations.AutoSize = true;
            this.cbListGestureAnimations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListGestureAnimations.Location = new System.Drawing.Point(10, 26);
            this.cbListGestureAnimations.Name = "cbListGestureAnimations";
            this.cbListGestureAnimations.Size = new System.Drawing.Size(254, 17);
            this.cbListGestureAnimations.TabIndex = 5;
            this.cbListGestureAnimations.Text = "List Gesture/Gaits Animations Files for Bodyparts";
            this.cbListGestureAnimations.UseVisualStyleBackColor = true;
            // 
            // cbListWeirdGestureGaitVerbs
            // 
            this.cbListWeirdGestureGaitVerbs.AutoSize = true;
            this.cbListWeirdGestureGaitVerbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListWeirdGestureGaitVerbs.Location = new System.Drawing.Point(10, 49);
            this.cbListWeirdGestureGaitVerbs.Name = "cbListWeirdGestureGaitVerbs";
            this.cbListWeirdGestureGaitVerbs.Size = new System.Drawing.Size(231, 17);
            this.cbListWeirdGestureGaitVerbs.TabIndex = 6;
            this.cbListWeirdGestureGaitVerbs.Text = "List Improper Gesture/Gait Verbs (for Props)";
            this.cbListWeirdGestureGaitVerbs.UseVisualStyleBackColor = true;
            // 
            // pnlDisplayContents
            // 
            this.pnlDisplayContents.Controls.Add(this.cbCompactDupVerbsByName);
            this.pnlDisplayContents.Controls.Add(this.cbForceAllAnimationsDisplay);
            this.pnlDisplayContents.Controls.Add(this.cbListGestureAnimations);
            this.pnlDisplayContents.Controls.Add(this.cbListWeirdGestureGaitVerbs);
            this.pnlDisplayContents.Location = new System.Drawing.Point(349, 72);
            this.pnlDisplayContents.Name = "pnlDisplayContents";
            this.pnlDisplayContents.Size = new System.Drawing.Size(597, 76);
            this.pnlDisplayContents.TabIndex = 7;
            // 
            // cbCompactDupVerbsByName
            // 
            this.cbCompactDupVerbsByName.AutoSize = true;
            this.cbCompactDupVerbsByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCompactDupVerbsByName.Location = new System.Drawing.Point(295, 3);
            this.cbCompactDupVerbsByName.Name = "cbCompactDupVerbsByName";
            this.cbCompactDupVerbsByName.Size = new System.Drawing.Size(155, 17);
            this.cbCompactDupVerbsByName.TabIndex = 7;
            this.cbCompactDupVerbsByName.Text = "Merge Dup Verbs By Name";
            this.cbCompactDupVerbsByName.UseVisualStyleBackColor = true;
            // 
            // cbCorrectDisguisedAddonFiles
            // 
            this.cbCorrectDisguisedAddonFiles.AutoSize = true;
            this.cbCorrectDisguisedAddonFiles.Location = new System.Drawing.Point(137, 145);
            this.cbCorrectDisguisedAddonFiles.Name = "cbCorrectDisguisedAddonFiles";
            this.cbCorrectDisguisedAddonFiles.Size = new System.Drawing.Size(206, 17);
            this.cbCorrectDisguisedAddonFiles.TabIndex = 8;
            this.cbCorrectDisguisedAddonFiles.Text = "Correct Addons Disguised as Archives";
            this.cbCorrectDisguisedAddonFiles.UseVisualStyleBackColor = true;
            this.cbCorrectDisguisedAddonFiles.CheckedChanged += new System.EventHandler(this.cbCorrectDisguisedAddonFiles_CheckedChanged);
            // 
            // cbDeleteSourceArchive
            // 
            this.cbDeleteSourceArchive.AutoSize = true;
            this.cbDeleteSourceArchive.Enabled = false;
            this.cbDeleteSourceArchive.Location = new System.Drawing.Point(155, 168);
            this.cbDeleteSourceArchive.Name = "cbDeleteSourceArchive";
            this.cbDeleteSourceArchive.Size = new System.Drawing.Size(197, 17);
            this.cbDeleteSourceArchive.TabIndex = 9;
            this.cbDeleteSourceArchive.Text = "Delete Archive if correction succeds";
            this.cbDeleteSourceArchive.UseVisualStyleBackColor = true;
            // 
            // pbCheckInstalled
            // 
            this.pbCheckInstalled.Location = new System.Drawing.Point(819, 16);
            this.pbCheckInstalled.Name = "pbCheckInstalled";
            this.pbCheckInstalled.Size = new System.Drawing.Size(118, 23);
            this.pbCheckInstalled.TabIndex = 10;
            this.pbCheckInstalled.Text = "Check Installed";
            this.pbCheckInstalled.UseVisualStyleBackColor = true;
            this.pbCheckInstalled.Click += new System.EventHandler(this.pbCheckInstalled_Click);
            // 
            // cbAssetsToCheck
            // 
            this.cbAssetsToCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssetsToCheck.FormattingEnabled = true;
            this.cbAssetsToCheck.Items.AddRange(new object[] {
            "User Addons",
            "Content packs",
            "Everything"});
            this.cbAssetsToCheck.Location = new System.Drawing.Point(819, 45);
            this.cbAssetsToCheck.Name = "cbAssetsToCheck";
            this.cbAssetsToCheck.Size = new System.Drawing.Size(121, 21);
            this.cbAssetsToCheck.TabIndex = 1;
            // 
            // pbSetup
            // 
            this.pbSetup.Image = ((System.Drawing.Image)(resources.GetObject("pbSetup.Image")));
            this.pbSetup.Location = new System.Drawing.Point(969, 16);
            this.pbSetup.Name = "pbSetup";
            this.pbSetup.Size = new System.Drawing.Size(35, 29);
            this.pbSetup.TabIndex = 11;
            this.pbSetup.UseVisualStyleBackColor = true;
            this.pbSetup.Click += new System.EventHandler(this.pbSetup_Click);
            // 
            // pbLoadDefaultOptions
            // 
            this.pbLoadDefaultOptions.Image = ((System.Drawing.Image)(resources.GetObject("pbLoadDefaultOptions.Image")));
            this.pbLoadDefaultOptions.Location = new System.Drawing.Point(969, 76);
            this.pbLoadDefaultOptions.Name = "pbLoadDefaultOptions";
            this.pbLoadDefaultOptions.Size = new System.Drawing.Size(35, 23);
            this.pbLoadDefaultOptions.TabIndex = 12;
            this.pbLoadDefaultOptions.UseVisualStyleBackColor = true;
            this.pbLoadDefaultOptions.Click += new System.EventHandler(this.pbLoadDefaultOptions_Click);
            // 
            // pbSaveDefaultOptions
            // 
            this.pbSaveDefaultOptions.Image = ((System.Drawing.Image)(resources.GetObject("pbSaveDefaultOptions.Image")));
            this.pbSaveDefaultOptions.Location = new System.Drawing.Point(969, 105);
            this.pbSaveDefaultOptions.Name = "pbSaveDefaultOptions";
            this.pbSaveDefaultOptions.Size = new System.Drawing.Size(35, 23);
            this.pbSaveDefaultOptions.TabIndex = 13;
            this.pbSaveDefaultOptions.UseVisualStyleBackColor = true;
            this.pbSaveDefaultOptions.Click += new System.EventHandler(this.pbSaveDefaultOptions_Click);
            // 
            // cbAppendToDatabase
            // 
            this.cbAppendToDatabase.AutoSize = true;
            this.cbAppendToDatabase.Location = new System.Drawing.Point(137, 103);
            this.cbAppendToDatabase.Name = "cbAppendToDatabase";
            this.cbAppendToDatabase.Size = new System.Drawing.Size(124, 17);
            this.cbAppendToDatabase.TabIndex = 14;
            this.cbAppendToDatabase.Text = "Append to Database";
            this.cbAppendToDatabase.UseVisualStyleBackColor = true;
            // 
            // cbRefreshItemsInDatabase
            // 
            this.cbRefreshItemsInDatabase.AutoSize = true;
            this.cbRefreshItemsInDatabase.Location = new System.Drawing.Point(155, 122);
            this.cbRefreshItemsInDatabase.Name = "cbRefreshItemsInDatabase";
            this.cbRefreshItemsInDatabase.Size = new System.Drawing.Size(151, 17);
            this.cbRefreshItemsInDatabase.TabIndex = 15;
            this.cbRefreshItemsInDatabase.Text = "Refresh Items in Database";
            this.cbRefreshItemsInDatabase.UseVisualStyleBackColor = true;
            // 
            // tcMainForm
            // 
            this.tcMainForm.Controls.Add(this.tpDatabase);
            this.tcMainForm.Controls.Add(this.tpChecking);
            this.tcMainForm.Location = new System.Drawing.Point(3, 2);
            this.tcMainForm.Name = "tcMainForm";
            this.tcMainForm.SelectedIndex = 0;
            this.tcMainForm.Size = new System.Drawing.Size(1020, 618);
            this.tcMainForm.TabIndex = 16;
            // 
            // tpDatabase
            // 
            this.tpDatabase.Controls.Add(this.lblTipTable);
            this.tpDatabase.Controls.Add(this.lblAddonDbFilename);
            this.tpDatabase.Controls.Add(this.panel1);
            this.tpDatabase.Controls.Add(this.pbSaveAddonDatabase);
            this.tpDatabase.Controls.Add(this.pbLoadAddonDatabase);
            this.tpDatabase.Controls.Add(this.pbInitAddonDatabase);
            this.tpDatabase.Controls.Add(this.pbClearAddonDatabase);
            this.tpDatabase.Controls.Add(this.pbSetup1);
            this.tpDatabase.Controls.Add(this.dgvAddons);
            this.tpDatabase.Controls.Add(this.lblAddonCount);
            this.tpDatabase.Controls.Add(this.label2);
            this.tpDatabase.Location = new System.Drawing.Point(4, 22);
            this.tpDatabase.Name = "tpDatabase";
            this.tpDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tpDatabase.Size = new System.Drawing.Size(1012, 592);
            this.tpDatabase.TabIndex = 1;
            this.tpDatabase.Text = "Database";
            this.tpDatabase.UseVisualStyleBackColor = true;
            // 
            // lblTipTable
            // 
            this.lblTipTable.AutoSize = true;
            this.lblTipTable.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipTable.ForeColor = System.Drawing.Color.Green;
            this.lblTipTable.Location = new System.Drawing.Point(916, 210);
            this.lblTipTable.Name = "lblTipTable";
            this.lblTipTable.Size = new System.Drawing.Size(51, 25);
            this.lblTipTable.TabIndex = 19;
            this.lblTipTable.Text = "< ?";
            this.lblTipTable.Click += new System.EventHandler(this.lblTipTable_Click);
            // 
            // lblAddonDbFilename
            // 
            this.lblAddonDbFilename.AutoSize = true;
            this.lblAddonDbFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddonDbFilename.Location = new System.Drawing.Point(111, 3);
            this.lblAddonDbFilename.Name = "lblAddonDbFilename";
            this.lblAddonDbFilename.Size = new System.Drawing.Size(14, 13);
            this.lblAddonDbFilename.TabIndex = 18;
            this.lblAddonDbFilename.Text = "?";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbLog);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(5, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 308);
            this.panel1.TabIndex = 17;
            // 
            // tbLog
            // 
            this.tbLog.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog.Location = new System.Drawing.Point(3, 176);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(994, 129);
            this.tbLog.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbsAssetTags);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.pbsSearch);
            this.groupBox2.Controls.Add(this.pbsResetAssetCriteria);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.tbsAssetName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(510, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asset Search Criteria";
            // 
            // tbsAssetTags
            // 
            this.tbsAssetTags.Location = new System.Drawing.Point(52, 142);
            this.tbsAssetTags.Name = "tbsAssetTags";
            this.tbsAssetTags.Size = new System.Drawing.Size(313, 20);
            this.tbsAssetTags.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tags:";
            // 
            // pbsSearch
            // 
            this.pbsSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbsSearch.Location = new System.Drawing.Point(406, 16);
            this.pbsSearch.Name = "pbsSearch";
            this.pbsSearch.Size = new System.Drawing.Size(75, 23);
            this.pbsSearch.TabIndex = 10;
            this.pbsSearch.Text = "Search";
            this.pbsSearch.UseVisualStyleBackColor = true;
            this.pbsSearch.Click += new System.EventHandler(this.pbsSearch_Click);
            // 
            // pbsResetAssetCriteria
            // 
            this.pbsResetAssetCriteria.Location = new System.Drawing.Point(406, 135);
            this.pbsResetAssetCriteria.Name = "pbsResetAssetCriteria";
            this.pbsResetAssetCriteria.Size = new System.Drawing.Size(75, 23);
            this.pbsResetAssetCriteria.TabIndex = 9;
            this.pbsResetAssetCriteria.Text = "Reset";
            this.pbsResetAssetCriteria.UseVisualStyleBackColor = true;
            this.pbsResetAssetCriteria.Click += new System.EventHandler(this.pbsResetAssetCriteria_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbatClearAll);
            this.groupBox3.Controls.Add(this.pbatSetAll);
            this.groupBox3.Controls.Add(this.cbatSfx);
            this.groupBox3.Controls.Add(this.cbatSky);
            this.groupBox3.Controls.Add(this.cbatSound);
            this.groupBox3.Controls.Add(this.cbatFilter);
            this.groupBox3.Controls.Add(this.cbatMaterial);
            this.groupBox3.Controls.Add(this.cbatVerb);
            this.groupBox3.Controls.Add(this.cbatProp);
            this.groupBox3.Controls.Add(this.cbatDecal);
            this.groupBox3.Controls.Add(this.cbatBodyPart);
            this.groupBox3.Location = new System.Drawing.Point(9, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 93);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asset Type";
            // 
            // pbatClearAll
            // 
            this.pbatClearAll.Location = new System.Drawing.Point(275, 45);
            this.pbatClearAll.Name = "pbatClearAll";
            this.pbatClearAll.Size = new System.Drawing.Size(75, 23);
            this.pbatClearAll.TabIndex = 10;
            this.pbatClearAll.Text = "Clear All";
            this.pbatClearAll.UseVisualStyleBackColor = true;
            this.pbatClearAll.Click += new System.EventHandler(this.pbatClearAll_Click);
            // 
            // pbatSetAll
            // 
            this.pbatSetAll.Location = new System.Drawing.Point(275, 16);
            this.pbatSetAll.Name = "pbatSetAll";
            this.pbatSetAll.Size = new System.Drawing.Size(75, 23);
            this.pbatSetAll.TabIndex = 9;
            this.pbatSetAll.Text = "Set All";
            this.pbatSetAll.UseVisualStyleBackColor = true;
            this.pbatSetAll.Click += new System.EventHandler(this.pbatSetAll_Click);
            // 
            // cbatSfx
            // 
            this.cbatSfx.AutoSize = true;
            this.cbatSfx.Checked = true;
            this.cbatSfx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatSfx.Location = new System.Drawing.Point(101, 66);
            this.cbatSfx.Name = "cbatSfx";
            this.cbatSfx.Size = new System.Drawing.Size(77, 17);
            this.cbatSfx.TabIndex = 8;
            this.cbatSfx.Text = "Special FX";
            this.cbatSfx.UseVisualStyleBackColor = true;
            // 
            // cbatSky
            // 
            this.cbatSky.AutoSize = true;
            this.cbatSky.Checked = true;
            this.cbatSky.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatSky.Location = new System.Drawing.Point(6, 66);
            this.cbatSky.Name = "cbatSky";
            this.cbatSky.Size = new System.Drawing.Size(79, 17);
            this.cbatSky.TabIndex = 7;
            this.cbatSky.Text = "Sky texture";
            this.cbatSky.UseVisualStyleBackColor = true;
            // 
            // cbatSound
            // 
            this.cbatSound.AutoSize = true;
            this.cbatSound.Checked = true;
            this.cbatSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatSound.Location = new System.Drawing.Point(80, 42);
            this.cbatSound.Name = "cbatSound";
            this.cbatSound.Size = new System.Drawing.Size(57, 17);
            this.cbatSound.TabIndex = 6;
            this.cbatSound.Text = "Sound";
            this.cbatSound.UseVisualStyleBackColor = true;
            // 
            // cbatFilter
            // 
            this.cbatFilter.AutoSize = true;
            this.cbatFilter.Checked = true;
            this.cbatFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatFilter.Location = new System.Drawing.Point(150, 42);
            this.cbatFilter.Name = "cbatFilter";
            this.cbatFilter.Size = new System.Drawing.Size(48, 17);
            this.cbatFilter.TabIndex = 5;
            this.cbatFilter.Text = "Filter";
            this.cbatFilter.UseVisualStyleBackColor = true;
            // 
            // cbatMaterial
            // 
            this.cbatMaterial.AutoSize = true;
            this.cbatMaterial.Checked = true;
            this.cbatMaterial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatMaterial.Location = new System.Drawing.Point(6, 43);
            this.cbatMaterial.Name = "cbatMaterial";
            this.cbatMaterial.Size = new System.Drawing.Size(63, 17);
            this.cbatMaterial.TabIndex = 4;
            this.cbatMaterial.Text = "Material";
            this.cbatMaterial.UseVisualStyleBackColor = true;
            // 
            // cbatVerb
            // 
            this.cbatVerb.AutoSize = true;
            this.cbatVerb.Checked = true;
            this.cbatVerb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatVerb.Location = new System.Drawing.Point(213, 19);
            this.cbatVerb.Name = "cbatVerb";
            this.cbatVerb.Size = new System.Drawing.Size(48, 17);
            this.cbatVerb.TabIndex = 3;
            this.cbatVerb.Text = "Verb";
            this.cbatVerb.UseVisualStyleBackColor = true;
            // 
            // cbatProp
            // 
            this.cbatProp.AutoSize = true;
            this.cbatProp.Checked = true;
            this.cbatProp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatProp.Location = new System.Drawing.Point(150, 19);
            this.cbatProp.Name = "cbatProp";
            this.cbatProp.Size = new System.Drawing.Size(48, 17);
            this.cbatProp.TabIndex = 2;
            this.cbatProp.Text = "Prop";
            this.cbatProp.UseVisualStyleBackColor = true;
            // 
            // cbatDecal
            // 
            this.cbatDecal.AutoSize = true;
            this.cbatDecal.Checked = true;
            this.cbatDecal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatDecal.Location = new System.Drawing.Point(80, 19);
            this.cbatDecal.Name = "cbatDecal";
            this.cbatDecal.Size = new System.Drawing.Size(54, 17);
            this.cbatDecal.TabIndex = 1;
            this.cbatDecal.Text = "Decal";
            this.cbatDecal.UseVisualStyleBackColor = true;
            // 
            // cbatBodyPart
            // 
            this.cbatBodyPart.AutoSize = true;
            this.cbatBodyPart.Checked = true;
            this.cbatBodyPart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbatBodyPart.Location = new System.Drawing.Point(6, 19);
            this.cbatBodyPart.Name = "cbatBodyPart";
            this.cbatBodyPart.Size = new System.Drawing.Size(68, 17);
            this.cbatBodyPart.TabIndex = 0;
            this.cbatBodyPart.Text = "Bodypart";
            this.cbatBodyPart.UseVisualStyleBackColor = true;
            // 
            // tbsAssetName
            // 
            this.tbsAssetName.Location = new System.Drawing.Point(47, 13);
            this.tbsAssetName.Name = "tbsAssetName";
            this.tbsAssetName.Size = new System.Drawing.Size(318, 20);
            this.tbsAssetName.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbsResetAddonCriteria);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbsAddonLocation);
            this.groupBox1.Controls.Add(this.tbsAddonPublisher);
            this.groupBox1.Controls.Add(this.tbsAddonName);
            this.groupBox1.Controls.Add(this.cbascType);
            this.groupBox1.Controls.Add(this.cbascInstalled);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Addon Search Criteria";
            // 
            // pbsResetAddonCriteria
            // 
            this.pbsResetAddonCriteria.Location = new System.Drawing.Point(408, 100);
            this.pbsResetAddonCriteria.Name = "pbsResetAddonCriteria";
            this.pbsResetAddonCriteria.Size = new System.Drawing.Size(75, 23);
            this.pbsResetAddonCriteria.TabIndex = 10;
            this.pbsResetAddonCriteria.Text = "Reset";
            this.pbsResetAddonCriteria.UseVisualStyleBackColor = true;
            this.pbsResetAddonCriteria.Click += new System.EventHandler(this.pbsResetAddonCriteria_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Installed:";
            // 
            // tbsAddonLocation
            // 
            this.tbsAddonLocation.Location = new System.Drawing.Point(63, 37);
            this.tbsAddonLocation.Name = "tbsAddonLocation";
            this.tbsAddonLocation.Size = new System.Drawing.Size(431, 20);
            this.tbsAddonLocation.TabIndex = 7;
            // 
            // tbsAddonPublisher
            // 
            this.tbsAddonPublisher.Location = new System.Drawing.Point(319, 13);
            this.tbsAddonPublisher.Name = "tbsAddonPublisher";
            this.tbsAddonPublisher.Size = new System.Drawing.Size(175, 20);
            this.tbsAddonPublisher.TabIndex = 6;
            // 
            // tbsAddonName
            // 
            this.tbsAddonName.Location = new System.Drawing.Point(47, 13);
            this.tbsAddonName.Name = "tbsAddonName";
            this.tbsAddonName.Size = new System.Drawing.Size(196, 20);
            this.tbsAddonName.TabIndex = 5;
            // 
            // cbascType
            // 
            this.cbascType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbascType.FormattingEnabled = true;
            this.cbascType.Items.AddRange(new object[] {
            "Any",
            "Official Content Packs only",
            "Third-Party only"});
            this.cbascType.Location = new System.Drawing.Point(318, 63);
            this.cbascType.Name = "cbascType";
            this.cbascType.Size = new System.Drawing.Size(176, 21);
            this.cbascType.TabIndex = 4;
            // 
            // cbascInstalled
            // 
            this.cbascInstalled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbascInstalled.FormattingEnabled = true;
            this.cbascInstalled.Items.AddRange(new object[] {
            "Any",
            "Installed only",
            "Not installed only"});
            this.cbascInstalled.Location = new System.Drawing.Point(63, 63);
            this.cbascInstalled.Name = "cbascInstalled";
            this.cbascInstalled.Size = new System.Drawing.Size(160, 21);
            this.cbascInstalled.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Location:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Publisher:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // pbSaveAddonDatabase
            // 
            this.pbSaveAddonDatabase.Location = new System.Drawing.Point(921, 149);
            this.pbSaveAddonDatabase.Name = "pbSaveAddonDatabase";
            this.pbSaveAddonDatabase.Size = new System.Drawing.Size(75, 23);
            this.pbSaveAddonDatabase.TabIndex = 16;
            this.pbSaveAddonDatabase.Text = "Save";
            this.pbSaveAddonDatabase.UseVisualStyleBackColor = true;
            this.pbSaveAddonDatabase.Click += new System.EventHandler(this.pbSaveAddonDatabase_Click);
            // 
            // pbLoadAddonDatabase
            // 
            this.pbLoadAddonDatabase.Location = new System.Drawing.Point(921, 120);
            this.pbLoadAddonDatabase.Name = "pbLoadAddonDatabase";
            this.pbLoadAddonDatabase.Size = new System.Drawing.Size(75, 23);
            this.pbLoadAddonDatabase.TabIndex = 15;
            this.pbLoadAddonDatabase.Text = "Load";
            this.pbLoadAddonDatabase.UseVisualStyleBackColor = true;
            this.pbLoadAddonDatabase.Click += new System.EventHandler(this.pbLoadAddonDatabase_Click);
            // 
            // pbInitAddonDatabase
            // 
            this.pbInitAddonDatabase.Location = new System.Drawing.Point(921, 81);
            this.pbInitAddonDatabase.Name = "pbInitAddonDatabase";
            this.pbInitAddonDatabase.Size = new System.Drawing.Size(75, 23);
            this.pbInitAddonDatabase.TabIndex = 14;
            this.pbInitAddonDatabase.Text = "Initialize";
            this.pbInitAddonDatabase.UseVisualStyleBackColor = true;
            this.pbInitAddonDatabase.Click += new System.EventHandler(this.pbInitAddonDatabase_Click);
            // 
            // pbClearAddonDatabase
            // 
            this.pbClearAddonDatabase.Location = new System.Drawing.Point(921, 52);
            this.pbClearAddonDatabase.Name = "pbClearAddonDatabase";
            this.pbClearAddonDatabase.Size = new System.Drawing.Size(75, 23);
            this.pbClearAddonDatabase.TabIndex = 13;
            this.pbClearAddonDatabase.Text = "Clear";
            this.pbClearAddonDatabase.UseVisualStyleBackColor = true;
            this.pbClearAddonDatabase.Click += new System.EventHandler(this.pbClearAddonDatabase_Click);
            // 
            // pbSetup1
            // 
            this.pbSetup1.Image = ((System.Drawing.Image)(resources.GetObject("pbSetup1.Image")));
            this.pbSetup1.Location = new System.Drawing.Point(970, 6);
            this.pbSetup1.Name = "pbSetup1";
            this.pbSetup1.Size = new System.Drawing.Size(35, 29);
            this.pbSetup1.TabIndex = 12;
            this.pbSetup1.UseVisualStyleBackColor = true;
            this.pbSetup1.Click += new System.EventHandler(this.pbSetup_Click);
            // 
            // dgvAddons
            // 
            this.dgvAddons.AllowDrop = true;
            this.dgvAddons.AllowUserToAddRows = false;
            this.dgvAddons.AllowUserToDeleteRows = false;
            this.dgvAddons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvAddonName,
            this.dgvAddonPublisher,
            this.dgvAddonInstalled,
            this.dgvAddonFree,
            this.dgvAddonRecompilable,
            this.dgvAddonContentPack,
            this.dgvAddonLocation});
            this.dgvAddons.ContextMenuStrip = this.cmAddonTable;
            this.dgvAddons.Location = new System.Drawing.Point(6, 19);
            this.dgvAddons.MultiSelect = false;
            this.dgvAddons.Name = "dgvAddons";
            this.dgvAddons.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAddons.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAddons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddons.Size = new System.Drawing.Size(909, 227);
            this.dgvAddons.TabIndex = 2;
            this.dgvAddons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddons_CellClick);
            this.dgvAddons.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAddons_DataBindingComplete);
            this.dgvAddons.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvAddons_DragDrop);
            this.dgvAddons.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvAddons_DragEnter);
            // 
            // dgvAddonName
            // 
            this.dgvAddonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvAddonName.DataPropertyName = "Name";
            this.dgvAddonName.HeaderText = "Name";
            this.dgvAddonName.Name = "dgvAddonName";
            this.dgvAddonName.ReadOnly = true;
            this.dgvAddonName.Width = 60;
            // 
            // dgvAddonPublisher
            // 
            this.dgvAddonPublisher.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvAddonPublisher.DataPropertyName = "Publisher";
            this.dgvAddonPublisher.HeaderText = "Publisher";
            this.dgvAddonPublisher.Name = "dgvAddonPublisher";
            this.dgvAddonPublisher.ReadOnly = true;
            this.dgvAddonPublisher.Width = 75;
            // 
            // dgvAddonInstalled
            // 
            this.dgvAddonInstalled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvAddonInstalled.DataPropertyName = "Installed";
            this.dgvAddonInstalled.HeaderText = "Installed";
            this.dgvAddonInstalled.Name = "dgvAddonInstalled";
            this.dgvAddonInstalled.ReadOnly = true;
            this.dgvAddonInstalled.Width = 52;
            // 
            // dgvAddonFree
            // 
            this.dgvAddonFree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvAddonFree.DataPropertyName = "Free";
            this.dgvAddonFree.HeaderText = "Free";
            this.dgvAddonFree.Name = "dgvAddonFree";
            this.dgvAddonFree.ReadOnly = true;
            this.dgvAddonFree.Width = 34;
            // 
            // dgvAddonRecompilable
            // 
            this.dgvAddonRecompilable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvAddonRecompilable.DataPropertyName = "Recompilable";
            this.dgvAddonRecompilable.HeaderText = "Recompilable";
            this.dgvAddonRecompilable.Name = "dgvAddonRecompilable";
            this.dgvAddonRecompilable.ReadOnly = true;
            this.dgvAddonRecompilable.Width = 77;
            // 
            // dgvAddonContentPack
            // 
            this.dgvAddonContentPack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvAddonContentPack.DataPropertyName = "ContentPack";
            this.dgvAddonContentPack.HeaderText = "Content Pack";
            this.dgvAddonContentPack.Name = "dgvAddonContentPack";
            this.dgvAddonContentPack.ReadOnly = true;
            this.dgvAddonContentPack.Width = 78;
            // 
            // dgvAddonLocation
            // 
            this.dgvAddonLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvAddonLocation.DataPropertyName = "Location";
            this.dgvAddonLocation.HeaderText = "Location";
            this.dgvAddonLocation.Name = "dgvAddonLocation";
            this.dgvAddonLocation.ReadOnly = true;
            this.dgvAddonLocation.Width = 73;
            // 
            // cmAddonTable
            // 
            this.cmAddonTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiDisplayReport,
            this.cmiShowContents,
            this.toolStripSeparator3,
            this.cmiRefreshAddon,
            this.cmiDeleteAddon,
            this.toolStripSeparator4,
            this.cmiCredits});
            this.cmAddonTable.Name = "cmAddonTable";
            this.cmAddonTable.Size = new System.Drawing.Size(296, 126);
            this.cmAddonTable.Opening += new System.ComponentModel.CancelEventHandler(this.cmAddonTable_Opening);
            // 
            // cmiDisplayReport
            // 
            this.cmiDisplayReport.Name = "cmiDisplayReport";
            this.cmiDisplayReport.Size = new System.Drawing.Size(295, 22);
            this.cmiDisplayReport.Text = "Display report for selected addon";
            this.cmiDisplayReport.Click += new System.EventHandler(this.cmiDisplayReport_Click);
            // 
            // cmiShowContents
            // 
            this.cmiShowContents.Name = "cmiShowContents";
            this.cmiShowContents.Size = new System.Drawing.Size(295, 22);
            this.cmiShowContents.Text = "List (table) of contents for selected Addon";
            this.cmiShowContents.Click += new System.EventHandler(this.cmiShowContents_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(292, 6);
            // 
            // cmiRefreshAddon
            // 
            this.cmiRefreshAddon.Name = "cmiRefreshAddon";
            this.cmiRefreshAddon.Size = new System.Drawing.Size(295, 22);
            this.cmiRefreshAddon.Text = "Refresh selected Addon";
            this.cmiRefreshAddon.Click += new System.EventHandler(this.cmiRefreshAddon_Click);
            // 
            // cmiDeleteAddon
            // 
            this.cmiDeleteAddon.Name = "cmiDeleteAddon";
            this.cmiDeleteAddon.Size = new System.Drawing.Size(295, 22);
            this.cmiDeleteAddon.Text = "Delete selected Addon";
            this.cmiDeleteAddon.Click += new System.EventHandler(this.cmiDeleteAddon_Click);
            // 
            // lblAddonCount
            // 
            this.lblAddonCount.AutoSize = true;
            this.lblAddonCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddonCount.Location = new System.Drawing.Point(23, 249);
            this.lblAddonCount.Name = "lblAddonCount";
            this.lblAddonCount.Size = new System.Drawing.Size(51, 13);
            this.lblAddonCount.TabIndex = 1;
            this.lblAddonCount.Text = "Total: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Addon Database: ";
            // 
            // tpChecking
            // 
            this.tpChecking.Controls.Add(this.pbCheckInstalled);
            this.tpChecking.Controls.Add(this.cbRefreshItemsInDatabase);
            this.tpChecking.Controls.Add(this.tbOutput);
            this.tpChecking.Controls.Add(this.pDragFiles);
            this.tpChecking.Controls.Add(this.cbAppendToDatabase);
            this.tpChecking.Controls.Add(this.cbAssetsToCheck);
            this.tpChecking.Controls.Add(this.pbSetup);
            this.tpChecking.Controls.Add(this.cbDeleteSourceArchive);
            this.tpChecking.Controls.Add(this.pbSaveDefaultOptions);
            this.tpChecking.Controls.Add(this.cbCorrectDisguisedAddonFiles);
            this.tpChecking.Controls.Add(this.pbLoadDefaultOptions);
            this.tpChecking.Controls.Add(this.cbShowContents);
            this.tpChecking.Controls.Add(this.cbOnlyIssues);
            this.tpChecking.Controls.Add(this.pnlDisplayContents);
            this.tpChecking.Location = new System.Drawing.Point(4, 22);
            this.tpChecking.Name = "tpChecking";
            this.tpChecking.Padding = new System.Windows.Forms.Padding(3);
            this.tpChecking.Size = new System.Drawing.Size(1012, 592);
            this.tpChecking.TabIndex = 0;
            this.tpChecking.Text = "Checking";
            this.tpChecking.UseVisualStyleBackColor = true;
            // 
            // ofdLoadAddonDb
            // 
            this.ofdLoadAddonDb.DefaultExt = "scat";
            this.ofdLoadAddonDb.Filter = "Asset database|*.scat";
            // 
            // sfdSaveAddonDb
            // 
            this.sfdSaveAddonDb.DefaultExt = "scat";
            this.sfdSaveAddonDb.Filter = "Asset database|*.scat";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(292, 6);
            // 
            // cmiCredits
            // 
            this.cmiCredits.Name = "cmiCredits";
            this.cmiCredits.Size = new System.Drawing.Size(295, 22);
            this.cmiCredits.Text = "Credits";
            this.cmiCredits.Click += new System.EventHandler(this.cmiCredits_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 622);
            this.Controls.Add(this.tcMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "StormCat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.outputContextMenu.ResumeLayout(false);
            this.pDragFiles.ResumeLayout(false);
            this.pDragFiles.PerformLayout();
            this.pnlDisplayContents.ResumeLayout(false);
            this.pnlDisplayContents.PerformLayout();
            this.tcMainForm.ResumeLayout(false);
            this.tpDatabase.ResumeLayout(false);
            this.tpDatabase.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).EndInit();
            this.cmAddonTable.ResumeLayout(false);
            this.tpChecking.ResumeLayout(false);
            this.tpChecking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Panel pDragFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbOnlyIssues;
        private System.Windows.Forms.CheckBox cbShowContents;
        private System.Windows.Forms.ContextMenuStrip outputContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmiCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem cmiClearOutput;
        private System.Windows.Forms.ToolStripMenuItem cmiWordwrapOutput;
        private System.Windows.Forms.ToolStripMenuItem cmiIncreaseFont;
        private System.Windows.Forms.ToolStripMenuItem cmiDecreaseFont;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox cbForceAllAnimationsDisplay;
        private System.Windows.Forms.CheckBox cbListGestureAnimations;
        private System.Windows.Forms.CheckBox cbListWeirdGestureGaitVerbs;
        private System.Windows.Forms.Panel pnlDisplayContents;
        private System.Windows.Forms.CheckBox cbCorrectDisguisedAddonFiles;
        private System.Windows.Forms.CheckBox cbCompactDupVerbsByName;
        private System.Windows.Forms.CheckBox cbDeleteSourceArchive;
        private System.Windows.Forms.Button pbCheckInstalled;
        private System.Windows.Forms.ComboBox cbAssetsToCheck;
        private System.Windows.Forms.Button pbSetup;
        private System.Windows.Forms.Button pbLoadDefaultOptions;
        private System.Windows.Forms.Button pbSaveDefaultOptions;
        private System.Windows.Forms.CheckBox cbAppendToDatabase;
        private System.Windows.Forms.CheckBox cbRefreshItemsInDatabase;
        private System.Windows.Forms.TabControl tcMainForm;
        private System.Windows.Forms.TabPage tpChecking;
        private System.Windows.Forms.TabPage tpDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAddons;
        private System.Windows.Forms.Label lblAddonCount;
        private System.Windows.Forms.Button pbSetup1;
        private System.Windows.Forms.Button pbSaveAddonDatabase;
        private System.Windows.Forms.Button pbLoadAddonDatabase;
        private System.Windows.Forms.Button pbInitAddonDatabase;
        private System.Windows.Forms.Button pbClearAddonDatabase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip cmAddonTable;
        private System.Windows.Forms.ToolStripMenuItem cmiDisplayReport;
        private System.Windows.Forms.ToolStripMenuItem cmiShowContents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmiRefreshAddon;
        private System.Windows.Forms.ToolStripMenuItem cmiDeleteAddon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbsAddonLocation;
        private System.Windows.Forms.TextBox tbsAddonPublisher;
        private System.Windows.Forms.TextBox tbsAddonName;
        private System.Windows.Forms.ComboBox cbascType;
        private System.Windows.Forms.ComboBox cbascInstalled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button pbatClearAll;
        private System.Windows.Forms.Button pbatSetAll;
        private System.Windows.Forms.CheckBox cbatSfx;
        private System.Windows.Forms.CheckBox cbatSky;
        private System.Windows.Forms.CheckBox cbatSound;
        private System.Windows.Forms.CheckBox cbatFilter;
        private System.Windows.Forms.CheckBox cbatMaterial;
        private System.Windows.Forms.CheckBox cbatVerb;
        private System.Windows.Forms.CheckBox cbatProp;
        private System.Windows.Forms.CheckBox cbatDecal;
        private System.Windows.Forms.CheckBox cbatBodyPart;
        private System.Windows.Forms.TextBox tbsAssetName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button pbsSearch;
        private System.Windows.Forms.Button pbsResetAssetCriteria;
        private System.Windows.Forms.Button pbsResetAddonCriteria;
        private System.Windows.Forms.TextBox tbsAssetTags;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAddonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAddonPublisher;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvAddonInstalled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvAddonFree;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvAddonRecompilable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvAddonContentPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAddonLocation;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label lblAddonDbFilename;
        private System.Windows.Forms.OpenFileDialog ofdLoadAddonDb;
        private System.Windows.Forms.SaveFileDialog sfdSaveAddonDb;
        private System.Windows.Forms.Label lblTipTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmiCredits;
    }
}

