using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using MSAddonChecker.Configuration;
using MSAddonChecker.Domain;
using MSAddonChecker.Misc;
using MSAddonLib.Domain;
using MSAddonLib.Domain.Addon;
using MSAddonLib.Persistence;
using MSAddonLib.Persistence.AddonDB;
using MSAddonLib.Util;
using MSAddonLib.Util.Persistence;

namespace MSAddonChecker
{
    public partial class MainForm : Form
    {

        private string[] _arguments;

        private IReportWriter _checkingReportWriter;

        private IReportWriter _logReportWriter;

        private ApplicationConfiguration _applicationConfiguration = null;

        private MoviestormPaths _moviestormPaths = null;

        private string _currentAddonDatabaseFilename = AddonPackageSet.DefaultAddonPackageSetFileName;

        private AddonPackageSet _addonPackageSet = null;

        private DateTime _addonPackageSetTimeStamp = DateTime.Now;

        private AddonBasicInfoSet _addons = null;


        // ----------------------------------------------------------------------------------------------------------------------



        public MainForm(string[] pArgs)
        {
            _arguments = pArgs;
            InitializeComponent();
        }

        // -------------------------------------------------------------------------------------------------


        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = $@"StormCat     (version {Utils.GetExecutableVersion()})";

            InitializationChores();
        }


        private void InitializationChores()
        {
            _checkingReportWriter = new FormReportWriter(
                new object[] { tbOutput }
            );

            _logReportWriter = new FormReportWriter(
                new object[] { tbLog }
            );

            LoadConfiguration();

            string errorText;
            Utils.ResetTempFolder(out errorText);

            LoadAddonDatabase();

            ControlsInitialization();


            if (_arguments != null && _arguments.Length > 0)
            {
                if (PreScanArguments())
                    ProcessArguments(_arguments);
            }


        }

        private void LoadAddonDatabase()
        {
            string errorText;

            if (!File.Exists(AddonPackageSet.DefaultAddonPackageSetFileName))
            {
                InitializeAddonDatabase(true, "No default addon Database found");
                return;
            }

            tbLog.AppendText("Loading Addon Database...\n");
            _addonPackageSet = AddonPackageSet.Load(out errorText);
            if (_addonPackageSet == null)
            {
                tbLog.AppendText($"  ERROR: loading Addon Database: {errorText}\n");
                InitializeAddonDatabase(true, "Database couldn't be loaded");
                return;
            }
            

            tbLog.AppendText("   Addon Database successfully loaded:\n");
            tbLog.AppendText($"     Addons registered: {_addonPackageSet.Addons?.Count ?? 0}\n");
            tbLog.AppendText($"     Last updated: {_addonPackageSet.LastUpdate.ToString("s")}\n");

            _addonPackageSetTimeStamp = _addonPackageSet.LastUpdate;
            DiskEntityBase.AddonPackageSet = _addonPackageSet;
        }


        private void InitializeAddonDatabase(bool pAskInitialize, string pReason)
        {
            bool populateDatabase = true;
            if (pAskInitialize)
            {
                populateDatabase = MessageBox.Show($"{pReason}. Would you like to create and initialize it?",
                    "Initialize Database", MessageBoxButtons.YesNo) == DialogResult.Yes;
            }
            
            tbLog.AppendText("Initializing Addon Database...\n");
            _addonPackageSet = new AddonPackageSet(_moviestormPaths, null);
            DiskEntityBase.AddonPackageSet = _addonPackageSet;

            if (populateDatabase)
            {
                tbLog.AppendText("Populating Addon Database. It can take a while...\n");
                _addonPackageSet.InitializeDatabase();
            }

            tbLog.AppendText($"     Addons registered: {_addonPackageSet.Addons?.Count ?? 0}\n");
            tbLog.AppendText($"     Last updated: {_addonPackageSet.LastUpdate.ToString("s")}\n");

            string errorText;
            if (!_addonPackageSet.Save(out errorText))
                tbLog.AppendText($"  ERROR: Addon Database couldn't be saved: {errorText}\n");

            _addonPackageSetTimeStamp = _addonPackageSet.LastUpdate;
        }



        
        /// <summary>
        /// UI controls initialization
        /// </summary>
        private void ControlsInitialization()
        {
            tcMainForm.SelectedIndex = 0;

            lblAddonDbFilename.Text = _currentAddonDatabaseFilename;

            SetToolTips();

            cbAssetsToCheck.SelectedIndex = 0;

            cbascInstalled.SelectedIndex = cbascType.SelectedIndex = 0;

            AddonDatabaseInitialization();

            LoadAndSetOptions();
        }



        private void LoadConfiguration()
        {
            tbLog.AppendText("Loading/Initializing Configuration...\n");

            string errorText;
            if (File.Exists(ApplicationConfiguration.ConfigurationFilePath))
                _applicationConfiguration = ApplicationConfiguration.Load(out errorText);

            if (_applicationConfiguration != null)
            {
                _moviestormPaths = new MoviestormPaths(_applicationConfiguration.MoviestormInstallationPath,
                    _applicationConfiguration.MoviestormUserDataPath);
                return;
            }

            _moviestormPaths = AddonPersistenceUtils.GetMoviestormPaths(out errorText);
            if (_moviestormPaths != null)
            {
                _applicationConfiguration = new ApplicationConfiguration(_moviestormPaths.InstallationPath, _moviestormPaths.UserDataPath);
                _applicationConfiguration.Save(ApplicationConfiguration.ConfigurationFilePath, out errorText);
                return;
            }

            _checkingReportWriter.WriteReportLineFeed("  ERROR: Configuration couldn't be initialized!");
            if (!ApplicationSetup())
                this.Close();
        }


        private bool PreScanArguments()
        {
            List<string> arguments = new List<string>();
            bool firstOption = true;
            ProcessingFlags flags = ProcessingFlags.None;
            foreach (string argument in _arguments)
            {
                string lwrArgument = argument?.ToLower()?.Trim();
                
                if ((lwrArgument == "-onlyissues") || (lwrArgument == "-i"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    flags |= ProcessingFlags.JustReportIssues;
                    continue;
                }
                if ((lwrArgument == "-showcontents") || (lwrArgument == "-c"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    flags |= ProcessingFlags.ShowAddonContents;
                    continue;
                }
                if ((lwrArgument == "-listallanimations") || (lwrArgument == "-laa"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    flags |= ProcessingFlags.ListAllAnimationFiles;
                    continue;
                }
                if ((lwrArgument == "-listgestureanimations") || (lwrArgument == "-lga"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    flags |= ProcessingFlags.ListGestureGaitsAnimations;
                    continue;
                }
                if ((lwrArgument == "-listweirdgestures") || (lwrArgument == "-lwg"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    flags |= ProcessingFlags.ListWeirdGestureGaitsVerbs;
                    continue;
                }
                if ((lwrArgument == "-compactdupverbs") || (lwrArgument == "-cdv"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    flags |= ProcessingFlags.ListCompactDupVerbsByName;
                    continue;
                }
                if ((lwrArgument == "-correctdisguisedaddons") || (lwrArgument == "-cda"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    flags |= ProcessingFlags.CorrectDisguisedFiles;
                    continue;
                }
                if ((lwrArgument == "-correctdisguisedaddons+") || (lwrArgument == "-cda+"))
                {
                    firstOption = ResetOptionsConditionally(firstOption);
                    cbCorrectDisguisedAddonFiles.Checked = cbDeleteSourceArchive.Checked = true;
                    flags |= ProcessingFlags.CorrectDisguisedFiles | ProcessingFlags.CorrectDisguisedFilesDeleteSource;
                    continue;
                }

                arguments.Add(argument);
            }

            if(!firstOption) 
                SetOptions(flags);


            _arguments = arguments.ToArray();
            return _arguments.Length > 0;
        }

        private bool ResetOptionsConditionally(bool pFirstOption)
        {
            if (!pFirstOption)
                return false;

            ResetOptions();
            return false;
        }


        private void ResetOptions()
        {
            cbOnlyIssues.Checked = cbShowContents.Checked =
                cbCorrectDisguisedAddonFiles.Checked = cbDeleteSourceArchive.Checked = false;
            pnlDisplayContents.Visible = false;
            cbForceAllAnimationsDisplay.Checked = cbListGestureAnimations.Checked =
                cbListWeirdGestureGaitVerbs.Checked = cbCompactDupVerbsByName.Checked = false;
            cbAppendToDatabase.Checked = cbRefreshItemsInDatabase.Checked = false;
        }


        private void SetToolTips()
        {
            ToolTip formToolTip = new ToolTip();
            formToolTip.SetDefaults();

            // Sets up the ToolTip text for the Button and Checkbox.

            // formToolTip.SetToolTip(this, "Press F1 for help");

            formToolTip.SetToolTip(pbCheckInstalled, "Check every addon and/or official content pack already installed in the system (Warning: it can take a while)");
            formToolTip.SetToolTip(cbAssetsToCheck, "Select the assets to check");
            formToolTip.SetToolTip(cbOnlyIssues, "Just informs about any entity (file/folder) with some issue");
            formToolTip.SetToolTip(cbShowContents, "List detailed information about every valid entity (file/folder) found");
            formToolTip.SetToolTip(cbCorrectDisguisedAddonFiles, "Automatically correct any valid addon disguised as an archive file, creating the corresponding addon file");
            formToolTip.SetToolTip(cbDeleteSourceArchive, "Delete the source archive file if the addon correction has succeeded");

            formToolTip.SetToolTip(cbForceAllAnimationsDisplay, "List all animation files declared in the Manifest file of the addon, regardless they are referred to in the State Machine or Verbs file");
            formToolTip.SetToolTip(cbListGestureAnimations, "List gesture and gait animations files declared in the Manifest file of the addon, regardless they are referred to in the State Machine or Verbs file");
            formToolTip.SetToolTip(cbListWeirdGestureGaitVerbs, "List 'verbs' for improper gestures and gaits, ie those associated to props instead to puppets. They usually are spurious entries left by the developer of the addon.");

            formToolTip.SetToolTip(cbCompactDupVerbsByName, "Merge verbs with the same name in the menu, even the names of their animation files differ");

            formToolTip.SetToolTip(cbAppendToDatabase, "Append valid addons found to the database");
            formToolTip.SetToolTip(cbRefreshItemsInDatabase, "Forces update/refreshing of addons already registered in the database");

            formToolTip.SetToolTip(tbOutput, "Right-click for invoking the contextual menu");

            formToolTip.SetToolTip(pbSetup, "Application setup");
            formToolTip.SetToolTip(pbLoadDefaultOptions, "Load default options");
            formToolTip.SetToolTip(pbSaveDefaultOptions, "Save default options");

            // -----------------------------------------

            formToolTip.SetToolTip(pbClearAddonDatabase, "Clear content of the Addon database");
            formToolTip.SetToolTip(pbInitAddonDatabase, "Initialize Addon database with the addons currently installed");
            formToolTip.SetToolTip(pbLoadAddonDatabase, "Load Addon database from file");
            formToolTip.SetToolTip(pbSaveAddonDatabase, "Save current Addon database to file");
            formToolTip.SetToolTip(pbsResetAddonCriteria, "Reset Addon Search Criteria");
            formToolTip.SetToolTip(pbsResetAssetCriteria, "Reset Asset Search Criteria");
            formToolTip.SetToolTip(pbatClearAll, "Uncheck (deselect) every type of asset");
            formToolTip.SetToolTip(pbatSetAll, "Check (select) every type of asset");
            formToolTip.SetToolTip(pbsSearch, "Search assets according to the addon and asset criteria specified");

            formToolTip.SetToolTip(tbsAddonName, "Addon Name (ignores case and accepts regular expressions)");
            formToolTip.SetToolTip(tbsAddonPublisher, "Addon Publisher (ignores case and accepts regular expressions)");
            formToolTip.SetToolTip(tbsAddonLocation, "Addon location (ignores case)");
            formToolTip.SetToolTip(tbsAssetName, "Asset Name (ignores case and accepts regular expressions)");
            formToolTip.SetToolTip(tbsAssetTags, "List of Asset Tags, separated by blanks (ignores case)");
            formToolTip.SetToolTip(cbascInstalled, "Filter addons: installed/not installed/all");
            formToolTip.SetToolTip(cbascType, "Filter addons: official content packs/third party addons/both");

            formToolTip.SetToolTip(pbSetup1, "Application setup");
            formToolTip.SetToolTip(dgvAddons, "Drag and drop here: addon files, folders, and/or ZIP/RAR/7z archives for adding to the Database\nRight-click for options");
            formToolTip.SetToolTip(lblTipTable, "Drag and drop on the grid: addon files, folders, and/or ZIP/RAR/7z archives for adding to the Database\nRight-click for options");
            
        }

        // -----------------------------------------------------------------------------------


        private void ProcessArguments(string[] pArgs)
        {
            Cursor currentCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            ProcessingFlags processingFlags = GetProcessingFlags();

            try
            {
                _checkingReportWriter.ClearOutput();
                _checkingReportWriter.WriteReportLineFeed(
                    processingFlags.HasFlag(ProcessingFlags.ShowAddonContents)
                        ? "CHECKING (it can take a while)..."
                        : "CHECKING...");

                foreach (string argument in pArgs)
                {
                    IDiskEntity asset = DiskEntityHelper.GetEntity(argument, null, _checkingReportWriter);

                    if (asset == null)
                    {

                        continue;
                    }
                    asset.CheckEntity(processingFlags);
                }
                _checkingReportWriter.WriteReportLineFeed("\n*** PROCESSING FINISHED ****...");
            }
            catch (Exception exception)
            {
                _checkingReportWriter.WriteReportLineFeed($"\nEXCEPTION: {exception.Message}");
                _checkingReportWriter.WriteReportLineFeed(exception.StackTrace);
            }
            finally
            {
                Cursor = currentCursor;
            }

            if (processingFlags.HasFlag(ProcessingFlags.AppendToAddonPackageSet))
                AddonDatabaseInitialization();
        }



        private ProcessingFlags GetProcessingFlags()
        {
            ProcessingFlags processingFlags = ProcessingFlags.None;
            if (cbOnlyIssues.Checked)
                processingFlags |= ProcessingFlags.JustReportIssues;
            else
            {
                if (cbShowContents.Checked)
                    processingFlags |= ProcessingFlags.ShowAddonContents;
                if (cbListGestureAnimations.Checked)
                    processingFlags |= ProcessingFlags.ListGestureGaitsAnimations;
                if (cbForceAllAnimationsDisplay.Checked)
                    processingFlags |= ProcessingFlags.ListAllAnimationFiles;
                if (cbListWeirdGestureGaitVerbs.Checked)
                    processingFlags |= ProcessingFlags.ListWeirdGestureGaitsVerbs;
                if (cbCompactDupVerbsByName.Checked)
                    processingFlags |= ProcessingFlags.ListCompactDupVerbsByName;
                if (cbAppendToDatabase.Checked)
                {
                    processingFlags |= ProcessingFlags.AppendToAddonPackageSet;
                    if(cbRefreshItemsInDatabase.Checked)
                        processingFlags |= ProcessingFlags.AppendToAddonPackageSetForceRefresh;
                }
            }

            if (cbCorrectDisguisedAddonFiles.Checked)
            {
                processingFlags |= ProcessingFlags.CorrectDisguisedFiles;
                if (cbDeleteSourceArchive.Checked)
                    processingFlags |= ProcessingFlags.CorrectDisguisedFilesDeleteSource;
            }

            return processingFlags;
        }

        private void pDragFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pDragFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0)
                return;

            ProcessArguments(files);
        }


        // -------------------------------------------------------------------------------------------------

        private void cbOnlyIssues_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOnlyIssues.Checked)
            {
                cbShowContents.Enabled = pnlDisplayContents.Visible = false;
                cbAppendToDatabase.Enabled = cbRefreshItemsInDatabase.Enabled = false;
            }
            else
            {
                cbShowContents.Enabled = true;
                cbAppendToDatabase.Enabled = cbRefreshItemsInDatabase.Enabled = true;
                pnlDisplayContents.Visible = cbShowContents.Checked;
            }
        }


        // -----------------------------------------------------------------------------------------------------


        private void outputContextMenu_Opening(object sender, CancelEventArgs e)
        {
            cmiWordwrapOutput.Checked = tbOutput.WordWrap;

        }

        private void cmiClearOutput_Click(object sender, EventArgs e)
        {
            tbOutput.Clear();
        }

        private void cmiCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                string textforClipboard = tbOutput.Text.Replace(Environment.NewLine, "\n");
                Clipboard.Clear();
                Clipboard.SetText(textforClipboard);
                SystemSounds.Beep.Play();
            }
            catch { }

        }

        private void cmiWordwrapOutput_Click(object sender, EventArgs e)
        {
            tbOutput.WordWrap = !tbOutput.WordWrap;
        }

        private void cmiIncreaseFont_Click(object sender, EventArgs e)
        {
            try
            {
                float fontSize = tbOutput.Font.Size + (float)1.0;
                tbOutput.Font = new Font(tbOutput.Font.FontFamily, fontSize);
            }
            catch { }
        }


        private void cmiDecreaseFont_Click(object sender, EventArgs e)
        {
            try
            {
                float fontSize = tbOutput.Font.Size - (float)1.0;
                if (fontSize >= 6.0)
                    tbOutput.Font = new Font(tbOutput.Font.FontFamily, fontSize);
            }
            catch { }
        }


        // ---------------------------------------------------------------------------------------------------------------------------

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string errorText;
            if (_addonPackageSet != null)
            {
                if (_addonPackageSetTimeStamp < _addonPackageSet.LastUpdate)
                {
                    if (string.IsNullOrEmpty(_currentAddonDatabaseFilename))
                    {
                        sfdSaveAddonDb.InitialDirectory = Utils.GetExecutableDirectory();
                        sfdSaveAddonDb.FileName = AddonPackageSet.DefaultAddonPackageSetFileName;
                        if (sfdSaveAddonDb.ShowDialog(this) != DialogResult.Cancel)
                        {
                            _currentAddonDatabaseFilename = ShortenAddonFileName(sfdSaveAddonDb.FileName);
                            lblAddonDbFilename.Text = _currentAddonDatabaseFilename;
                        }
                    }

                    if (!string.IsNullOrEmpty(_currentAddonDatabaseFilename))
                    {
                        tbLog.AppendText("Saving Addon Database...\n");
                        tbLog.AppendText(_addonPackageSet.Save(out errorText, _currentAddonDatabaseFilename)
                            ? "   Addon Database successfully saved.\n"
                            : $"  ERROR: saving Addon Database: {errorText}\n");
                    }
                }
            }
            
            Utils.ResetTempFolder(out errorText);
        }


        // -----------------------------------------------------------------------------------------------------------------------------

        private void cbShowContents_Click(object sender, EventArgs e)
        {
            pnlDisplayContents.Visible = cbShowContents.Checked;
        }

        private void cbCorrectDisguisedAddonFiles_CheckedChanged(object sender, EventArgs e)
        {
            cbDeleteSourceArchive.Enabled = cbCorrectDisguisedAddonFiles.Checked;
        }


        // ------------------------------------------------------------------------------------------------------------------------------

        private void pbCheckInstalled_Click(object sender, EventArgs e)
        {
            ScanInstalledStuff();
        }


        private void ScanInstalledStuff()
        {
            if (_moviestormPaths == null)
            {
                string errorText;
                _moviestormPaths = AddonPersistenceUtils.GetMoviestormPaths(out errorText);
                if (_moviestormPaths == null)
                {
                    tbOutput.Clear();
                    tbOutput.AppendText(errorText + Environment.NewLine);
                    tbOutput.AppendText("Automatic check of installed assets disabled." + Environment.NewLine);
                    pbCheckInstalled.Enabled = cbAssetsToCheck.Enabled = false;
                    return;
                }
            }

            int assetsIndex = cbAssetsToCheck.SelectedIndex;
            List<string> files = new List<string>();

            if ((assetsIndex == 1) || (assetsIndex == 2))
            {
                foreach (string folder in Directory.EnumerateDirectories(_moviestormPaths.ContentPacksPath, "*",
                    SearchOption.TopDirectoryOnly))
                {
                    files.Add(folder);
                }
            }

            if ((assetsIndex == 0) || (assetsIndex == 2))
            {
                string moddersWorkshop = Path.Combine(_moviestormPaths.AddonsPath, "ModdersWorkshop").ToLower();
                foreach (string folder in Directory.EnumerateDirectories(_moviestormPaths.AddonsPath, "*",
                    SearchOption.TopDirectoryOnly))
                {
                    if (folder.ToLower() != moddersWorkshop)
                        files.Add(folder);
                }
            }

            if (files.Count == 0)
            {
                tbOutput.Clear();
                tbOutput.AppendText("No assets to scan");
                return;
            }

            ProcessArguments(files.ToArray());
        }


        // ------------------------------------------------------------------------------------------------

        private void pbSetup_Click(object sender, EventArgs e)
        {
            ApplicationSetup();

        }



        private bool ApplicationSetup()
        {
            SetupForm setupForm = new SetupForm(_applicationConfiguration);
            if (setupForm.ShowDialog(this) != DialogResult.OK)
                return false;

            _applicationConfiguration = setupForm.ApplicationConfiguration;
            _moviestormPaths = new MoviestormPaths(_applicationConfiguration.MoviestormInstallationPath, _applicationConfiguration.MoviestormUserDataPath);
            return true;
        }

        private void pbLoadDefaultOptions_Click(object sender, EventArgs e)
        {
            LoadAndSetOptions();
        }


        private void LoadAndSetOptions()
        {
            if (!File.Exists(ProcessingOptions.ConfigurationFilePath))
                return;

            string errorText;
            ProcessingOptions processingOptions = ProcessingOptions.Load(out errorText);
            if (processingOptions == null)
                return;

            ResetOptions();
            SetOptions(processingOptions.ProcessingFlags);

        }


        private void SetOptions(ProcessingFlags pFlags)
        {
            cbOnlyIssues.Checked = pFlags.HasFlag(ProcessingFlags.JustReportIssues);
            if (!cbOnlyIssues.Checked)
            {
                cbShowContents.Checked = pFlags.HasFlag(ProcessingFlags.ShowAddonContents);
                if (cbShowContents.Checked)
                {
                    pnlDisplayContents.Visible = true;
                    cbForceAllAnimationsDisplay.Checked = pFlags.HasFlag(ProcessingFlags.ListAllAnimationFiles);
                    cbListGestureAnimations.Checked = pFlags.HasFlag(ProcessingFlags.ListGestureGaitsAnimations);
                    cbListWeirdGestureGaitVerbs.Checked = pFlags.HasFlag(ProcessingFlags.ListWeirdGestureGaitsVerbs);
                    cbCompactDupVerbsByName.Checked = pFlags.HasFlag(ProcessingFlags.ListCompactDupVerbsByName);
                }

                cbAppendToDatabase.Checked = pFlags.HasFlag(ProcessingFlags.AppendToAddonPackageSet);
                cbRefreshItemsInDatabase.Checked = pFlags.HasFlag(ProcessingFlags.AppendToAddonPackageSetForceRefresh);
            }
            cbCorrectDisguisedAddonFiles.Checked = pFlags.HasFlag(ProcessingFlags.CorrectDisguisedFiles);
            if (cbCorrectDisguisedAddonFiles.Checked)
                cbDeleteSourceArchive.Checked = pFlags.HasFlag(ProcessingFlags.CorrectDisguisedFilesDeleteSource);
        }


        private void pbSaveDefaultOptions_Click(object sender, EventArgs e)
        {
            ProcessingFlags flags = GetProcessingFlags();

            ProcessingOptions options = new ProcessingOptions()
            {
                ProcessingFlags = flags
            };

            string errorText;
            if (!options.Save(ProcessingOptions.ConfigurationFilePath, out errorText))
            {
                MessageBox.Show(errorText, "Error saving processing options by default", MessageBoxButtons.OK);
            }

        }

        #region DatabaseTab
        // ---------------------------------------------------------------------------------------------------------------------------------------------------------

        private void AddonDatabaseInitialization()
        {
            AddonBasicInfoSet.MoviestormContentPackPath = _moviestormPaths.ContentPacksPath;

            dgvAddons.AutoGenerateColumns = false;
            _addons = new AddonBasicInfoSet(_addonPackageSet.Addons);

            BindingSource source = null;
            if ((_addons.Addons?.Count ?? 0) > 0)
            {
                var bindingList = new SortableBindingList<AddonBasicInfo>(_addons.Addons);
                source = new BindingSource(bindingList, null);
            }

            dgvAddons.DataSource = source;

            lblAddonCount.Text = $"Addon count: {_addons.Addons?.Count ?? 0}";
        }



        private void dgvAddons_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAddons.Columns["dgvAddonName"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAddons.Columns["dgvAddonPublisher"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAddons.Columns["dgvAddonLocation"].SortMode = DataGridViewColumnSortMode.Automatic;
        }


        private void cmAddonTable_Opening(object sender, CancelEventArgs e)
        {
            cmiDisplayReport.Enabled =
                cmiShowContents.Enabled = cmiRefreshAddon.Enabled = cmiDeleteAddon.Enabled = false;
            if ((_addons?.Addons == null) || (_addons.Addons.Count == 0))
            {
                e.Cancel = true;
                return;
            }
            int rowIndex = dgvAddons.CurrentCell.RowIndex;
            if (rowIndex < 0)
            {
                e.Cancel = true;
                return;
            }
            cmiDisplayReport.Enabled =
                cmiShowContents.Enabled = cmiRefreshAddon.Enabled = cmiDeleteAddon.Enabled = true;
        }


        private string GetSelectedAddonNameLocation(out string pLocation)
        {
            pLocation =(string)dgvAddons.SelectedRows[0].Cells["dgvAddonLocation"].Value;
            return (string)dgvAddons.SelectedRows[0].Cells["dgvAddonPublisher"].Value + "." + (string)dgvAddons.SelectedRows[0].Cells["dgvAddonName"].Value;
        }

        private void cmiDisplayReport_Click(object sender, EventArgs e)
        {
            string location;
            string name = GetSelectedAddonNameLocation(out location);

            AddonPackage package = _addonPackageSet.FindByLocation(location);
            if (package == null)
                return;

            AddonReportForm reportForm = new AddonReportForm(name, package.ToString());
            reportForm.Show(this);
        }

        private void cmiShowContents_Click(object sender, EventArgs e)
        {
            string location;
            string name = GetSelectedAddonNameLocation(out location);

            AddonPackage package = _addonPackageSet.FindByLocation(location);
            if (package == null)
                return;

            List<AssetSearchResultItem> assets = _addonPackageSet.SearchAsset(new List<AddonPackage>() {package}, null);


            AddonContentForm contentForm = new AddonContentForm(name, assets);
            contentForm.Show(this);

        }

        private void cmiRefreshAddon_Click(object sender, EventArgs e)
        {
            string location;
            string name = GetSelectedAddonNameLocation(out location);

            // Determine if inside an archive:
            int archiveIndex = location.LastIndexOf(("#"));
            if (archiveIndex > 0)
                location = location.Substring(0, archiveIndex);

            ProcessingFlags processingFlags = ProcessingFlags.AppendToAddonPackageSet |
                                              ProcessingFlags.AppendToAddonPackageSetForceRefresh;

            IDiskEntity asset = DiskEntityHelper.GetEntity(location, null, new NullReportWriter());

            if (asset == null)
            {
                return;
            }
            asset.CheckEntity(processingFlags);

            AddonDatabaseInitialization();
            tbLog.AppendText($"Addon '{name}' refreshed\n");
        }

        private void cmiDeleteAddon_Click(object sender, EventArgs e)
        {
            string location;
            string name = GetSelectedAddonNameLocation(out location);

            if (MessageBox.Show($"Delete addon {name} from Database. Please Confirm?", "Clear Addon Database",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            if (_addonPackageSet.DeleteByLocation(location))
            {
                AddonDatabaseInitialization();
                tbLog.AppendText($"Addon '{name}' deleted\n");
            }
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------------


        private void pbsResetAddonCriteria_Click(object sender, EventArgs e)
        {
            tbsAddonName.Text = tbsAddonPublisher.Text = tbsAddonLocation.Text = null;
            cbascInstalled.SelectedIndex = cbascType.SelectedIndex = 0;
        }


        private void pbatClearAll_Click(object sender, EventArgs e)
        {
            SelectAllAssetTypes(false);
        }

        private void pbatSetAll_Click(object sender, EventArgs e)
        {
            SelectAllAssetTypes(true);
        }


        private void SelectAllAssetTypes(bool pSelect)
        {
            cbatBodyPart.Checked = cbatDecal.Checked = cbatProp.Checked = cbatVerb.Checked =
            cbatMaterial.Checked =
                cbatSound.Checked = cbatFilter.Checked = cbatSky.Checked = cbatSfx.Checked = pSelect;
        }


        private void pbsResetAssetCriteria_Click(object sender, EventArgs e)
        {
            tbsAssetName.Text = tbsAssetTags.Text = null;
            SelectAllAssetTypes(true);
        }

        private void pbsSearch_Click(object sender, EventArgs e)
        {
            bool? installed = null;
            switch (cbascInstalled.SelectedIndex)
            {
                case 1: installed = true;
                    break;
                case 2: installed = false;
                    break;
            }

            bool? contentPack = null;
            switch (cbascType.SelectedIndex)
            {
                case 1:
                    installed = true;
                    break;
                case 2:
                    installed = false;
                    break;
            }

            AddonSearchCriteria addonSearchCriteria = new AddonSearchCriteria(tbsAssetName.Text, tbsAddonPublisher.Text, installed, contentPack, tbsAddonLocation.Text);

            AddonAssetType assetType = AddonAssetType.Null;
            if (cbatBodyPart.Checked) assetType |= AddonAssetType.BodyPart;
            if (cbatDecal.Checked) assetType |= AddonAssetType.Decal;
            if (cbatProp.Checked) assetType |= AddonAssetType.Prop;
            if (cbatVerb.Checked) assetType |= AddonAssetType.Verb;
            if (cbatMaterial.Checked) assetType |= AddonAssetType.Material;
            if (cbatSound.Checked) assetType |= AddonAssetType.Sound;
            if (cbatFilter.Checked) assetType |= AddonAssetType.Filter;
            if (cbatSky.Checked) assetType |= AddonAssetType.SkyTexture;
            if (cbatSfx.Checked) assetType |= AddonAssetType.SpecialEffect;

            AssetSearchCriteria assetSearchCriteria = new AssetSearchCriteria(tbsAssetName.Text, assetType, tbsAssetTags.Text);

            List<AssetSearchResultItem> searchOutput = _addonPackageSet.Search(addonSearchCriteria, assetSearchCriteria);

            AssetSearchResultForm resultForm = new AssetSearchResultForm(searchOutput);
            resultForm.Show(this);
        }

        private void dgvAddons_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        #endregion DatabaseTab

        private void pbClearAddonDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear Addon Database. Please Confirm?", "Clear Addon Database",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            tbLog.AppendText("Clearing Addon Database...\n");
            _addonPackageSet.Clear();
            AddonDatabaseInitialization();
            tbLog.AppendText("   Addon Database cleared.\n");
            _currentAddonDatabaseFilename = null;
            lblAddonDbFilename.Text = null;
        }



        private void pbInitAddonDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Initialize Addon Database. Please Confirm?", "Initialize Addon Database",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            tbLog.AppendText("Initializing Addon Database (it can take a while)...\n");
            _addonPackageSet.InitializeDatabase();

            AddonDatabaseInitialization();
            tbLog.AppendText("   Addon Database initialized\n");

        }



        private void pbLoadAddonDatabase_Click(object sender, EventArgs e)
        {
            ofdLoadAddonDb.InitialDirectory = Utils.GetExecutableDirectory();
            if (ofdLoadAddonDb.ShowDialog(this) != DialogResult.OK)
                return;

            string fileName = ofdLoadAddonDb.FileName;
            if (!File.Exists(fileName))
                return;

            string errorText;
            AddonPackageSet addonSet = AddonPackageSet.Load(out errorText, fileName);
            if (addonSet == null)
            {
                tbLog.AppendText($"ERROR trying to load Addon Database fron file: {errorText}");
                return;
            }

            _addonPackageSet = addonSet;
            _currentAddonDatabaseFilename = ShortenAddonFileName(fileName);
            lblAddonDbFilename.Text = _currentAddonDatabaseFilename;
            DiskEntityBase.AddonPackageSet = _addonPackageSet;
            AddonDatabaseInitialization();
            tbLog.AppendText($"Database loaded from file '{_currentAddonDatabaseFilename}'");
        }


        private void pbSaveAddonDatabase_Click(object sender, EventArgs e)
        {
            if (_addonPackageSet == null)
                return;

            sfdSaveAddonDb.InitialDirectory = Utils.GetExecutableDirectory();
            sfdSaveAddonDb.FileName = _currentAddonDatabaseFilename ?? AddonPackageSet.DefaultAddonPackageSetFileName;
            if (sfdSaveAddonDb.ShowDialog(this) != DialogResult.OK)
                return;

            string fileName = sfdSaveAddonDb.FileName;
            string errorText;

            if (!_addonPackageSet.Save(out errorText, fileName))
            {
                tbLog.AppendText($"ERROR trying to save Addon Database to file: {errorText}");
                return;
            }

            _currentAddonDatabaseFilename = ShortenAddonFileName(fileName);
            lblAddonDbFilename.Text = _currentAddonDatabaseFilename;
            tbLog.AppendText($"Database saved to file '{_currentAddonDatabaseFilename}'");
        }

        private string ShortenAddonFileName(string pFilename)
        {
            string folder = Path.GetDirectoryName(pFilename);
            if (string.IsNullOrEmpty(folder))
                return pFilename;

            return (folder.ToLower() == Utils.GetExecutableDirectory().ToLower())
                ? Path.GetFileName(pFilename)
                : pFilename;
        }




        private void dgvAddons_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }



        private void dgvAddons_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0)
                return;

           AppendAddonsToDatabase(files);
        }




        private void AppendAddonsToDatabase(string[] pArgs)
        {
            Cursor currentCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            ProcessingFlags processingFlags = ProcessingFlags.AppendToAddonPackageSet |
                                              ProcessingFlags.AppendToAddonPackageSetForceRefresh;

            try
            {
                _logReportWriter.ClearOutput();
                _logReportWriter.WriteReportLineFeed("Appending/updating Addons (it can take a while)");

                foreach (string argument in pArgs)
                {
                    IDiskEntity asset = DiskEntityHelper.GetEntity(argument, null, _logReportWriter);

                    if (asset == null)
                    {

                        continue;
                    }
                    asset.CheckEntity(processingFlags);
                }
                _logReportWriter.WriteReportLineFeed("\n*** OPERATION FINISHED ****...");
            }
            catch (Exception exception)
            {
                _logReportWriter.WriteReportLineFeed($"\nEXCEPTION: {exception.Message}");
                _logReportWriter.WriteReportLineFeed(exception.StackTrace);
            }
            finally
            {
                Cursor = currentCursor;
            }

            AddonDatabaseInitialization();
        }

        private void lblTipTable_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Drag and drop on the grid: addon files, folders, and/or ZIP/RAR/7z archives for adding to the Database\nRight-click for options");
        }

        private void cmiCredits_Click(object sender, EventArgs e)
        {
            CreditsForm creditsForm = new CreditsForm();
            creditsForm.ShowDialog(this);
        }
    }
}
