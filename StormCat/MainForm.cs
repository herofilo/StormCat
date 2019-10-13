using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Internal;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using StormCat.Configuration;
using StormCat.Domain;
using StormCat.Misc;
using MSAddonLib.Domain;
using MSAddonLib.Domain.Addon;
using MSAddonLib.Persistence;
using MSAddonLib.Persistence.AddonDB;
using MSAddonLib.Util;
using MSAddonLib.Util.Persistence;
using StormCat.Persistence;

namespace StormCat
{
    public partial class MainForm : Form
    {

        private string[] _arguments;

        private IReportWriter _checkingReportWriter;

        private IReportWriter _logReportWriter;

        private ApplicationConfiguration _applicationConfiguration = null;

        private MoviestormPaths _moviestormPaths = null;

        private CataloguesIndex _cataloguesIndex = null;

        private string _currentAddonDatabaseName = Path.GetFileNameWithoutExtension(AddonPackageSet.DefaultAddonPackageSetFileName);

        private AddonPackageSet _addonPackageSet = null;

        private DateTime _addonPackageSetTimeStamp = DateTime.Now;

        private AddonBasicInfoSet _addons = null;

        // ...........................

        private bool _isChildProcess = false;

        private string _childCatalogue = null;

        private List<TabPage> _childHiddenPages = null;

        private ToolTip formToolTip;


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

            HelpSystemSetup();



            PreScanCmdLineArguments();
            if (_isChildProcess)
            {
                if (_childCatalogue == null)
                {
                    Close();
                    return;
                }

                ChildControlInitialization();
            }

            LoadConfiguration();

            string errorText;
            Utils.ResetTempFolder(out errorText);

            if(!_isChildProcess)
                LoadCataloguesInfo();

            LoadAddonDatabase();

            if (!_isChildProcess)
            {
                RefreshCatalogueIndexTable(_cataloguesIndex.DefaultAddonDatabase);

                ControlsInitialization();


                if (_arguments != null && _arguments.Length > 0)
                {
                    if (ScanCmdLineArguments())
                    {
                        tcMainForm.SelectedTab = tpChecking;
                        ProcessArguments(_arguments);
                    }
                }
            }
            else
            {
                RefreshCatalogueAddonTable();
            }
        }

        private void HelpSystemSetup()
        {
            ContextHelp.HelpNamespace = Globals.HelpFilename;
            ContextHelp.SetHelpNavigator(this, HelpNavigator.TopicId);
            // ContextHelp.SetHelpNavigator(tpDatabase, HelpNavigator.TopicId);
            // ContextHelp.SetHelpNavigator(tpSearchAssets, HelpNavigator.TopicId);
        }


        private void PreScanCmdLineArguments()
        {
            if ((_arguments == null) || (_arguments.Length == 0))
                return;

            const string childOption = "-child:";

            foreach (string argument in _arguments)
            {
                string lwrArgument = argument?.ToLower()?.Trim();
                if (string.IsNullOrEmpty(lwrArgument))
                    continue;
                if (!lwrArgument.StartsWith(childOption) || (lwrArgument.Length <= childOption.Length))
                    continue;

                _isChildProcess = true;
                string catalogue = argument.Substring(childOption.Length);
                if (File.Exists(catalogue + AddonPackageSet.AddonPackageSetFileExtension))
                    _childCatalogue = catalogue;
                break;
            }

            if(_isChildProcess)
                _arguments = null;
        }


        private void LoadCataloguesInfo()
        {
            if (_childCatalogue != null)
                return;

            string errorText;
            if (!File.Exists(CataloguesIndex.CataloguesIndexFilePath))
            {
                _cataloguesIndex = CataloguesIndex.Initialize(_moviestormPaths, out errorText);
                if (_cataloguesIndex == null)
                {
                    tbLog.AppendText($"ERROR: initializing catalogues information: {errorText}\n");
                    return;
                }
            }
            else
            {
                _cataloguesIndex = CataloguesIndex.Load(out errorText);
                if (_cataloguesIndex == null)
                {
                    tbLog.AppendText($"ERROR: loading catalogues information: {errorText}\n");
                    return;
                }
            }
        }




        private void LoadAddonDatabase()
        {
            if (_childCatalogue != null)
            {
                LoadChildAddonDatabase();
                return;
            }

            string errorText;

            string defaultCatalogue = _cataloguesIndex?.DefaultAddonDatabaseFilename ??
                                      AddonPackageSet.DefaultAddonPackageSetFileName;

            string defaultCatalogueName = Path.GetFileNameWithoutExtension(defaultCatalogue);

            _currentAddonDatabaseName = defaultCatalogueName;

            if (!File.Exists(defaultCatalogue))
            {
                InitializeAddonDatabase(true, $"No default addon Catalogue ({defaultCatalogueName}) found");
                return;
            }

            tbLog.AppendText($"Loading default Addon Catalogue ({defaultCatalogueName})...\n");
            _addonPackageSet = AddonPackageSet.Load(out errorText, defaultCatalogue);
            if (_addonPackageSet == null)
            {
                tbLog.AppendText($"  ERROR: loading Addon Catalogue: {errorText}\n");
                InitializeAddonDatabase(true, "Catalogue couldn't be loaded");
                return;
            }


            tbLog.AppendText($"   Addon Catalogue '{defaultCatalogueName}' successfully loaded:\n");
            tbLog.AppendText($"     Addons registered: {_addonPackageSet.Addons?.Count ?? 0}\n");
            tbLog.AppendText($"     Last updated: {_addonPackageSet.LastUpdate.ToString("s")}\n");

            _addonPackageSetTimeStamp = _addonPackageSet.LastUpdate;
            DiskEntityBase.AddonPackageSet = _addonPackageSet;
        }


        private void LoadChildAddonDatabase()
        {
            _currentAddonDatabaseName = _childCatalogue;
            string catalogueFilename = _childCatalogue + AddonPackageSet.AddonPackageSetFileExtension;

            string errorText;
            tbLog.AppendText($"Loading default Addon Catalogue ({_currentAddonDatabaseName})...\n");
            _addonPackageSet = AddonPackageSet.Load(out errorText, catalogueFilename);
            if (_addonPackageSet == null)
            {
                tbLog.AppendText($"  ERROR: loading Addon Catalogue: {errorText}\n");
                InitializeAddonDatabase(true, "Catalogue couldn't be loaded");
                return;
            }


            tbLog.AppendText($"   Addon Catalogue '{_currentAddonDatabaseName}' successfully loaded:\n");
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
                    "Initialize Catalogue", MessageBoxButtons.YesNo) == DialogResult.Yes;
            }

            tbLog.AppendText("Initializing Addon Catalogue...\n");
            _addonPackageSet = new AddonPackageSet(_moviestormPaths, null);
            DiskEntityBase.AddonPackageSet = _addonPackageSet;

            if (populateDatabase)
            {
                tbLog.AppendText("Populating Addon Catalogue. It can take a while...\n");
                _addonPackageSet.InitializeDatabase();
            }

            tbLog.AppendText($"     Addons registered: {_addonPackageSet.Addons?.Count ?? 0}\n");
            tbLog.AppendText($"     Last updated: {_addonPackageSet.LastUpdate.ToString("s")}\n");

            string errorText;
            if (!_addonPackageSet.Save(out errorText))
                tbLog.AppendText($"  ERROR: Addon Catalogue couldn't be saved: {errorText}\n");

            _addonPackageSetTimeStamp = _addonPackageSet.LastUpdate;
        }




        /// <summary>
        /// UI controls initialization
        /// </summary>
        private void ControlsInitialization()
        {
            tcMainForm.SelectedTab = tpDatabase;

            lblAddonDbFilename.Text = _currentAddonDatabaseName;

            SetToolTips();

            cbAssetsToCheck.SelectedIndex = 0;

            cbascInstalled.SelectedIndex = cbascType.SelectedIndex = 0;

            RefreshCatalogueAddonTable();

            LoadAndSetOptions();
        }


        private void ChildControlInitialization()
        {
            tcMainForm.SelectedTab = tpDatabase;

            lblAddonDbFilename.Text = _childCatalogue;

            SetToolTips();

            pbSetup1.Enabled = false;

            _childHiddenPages = new List<TabPage>();

            tcMainForm.TabPages.Remove(tpCatalogueManagement);
            _childHiddenPages.Add(tpCatalogueManagement);

            tcMainForm.TabPages.Remove(tpChecking);
            _childHiddenPages.Add(tpChecking);
        }


        private void LoadConfiguration()
        {
            tbLog.AppendText("Loading/Initializing Configuration...\n");

            string errorText;
            if (File.Exists(ApplicationConfiguration.ConfigurationFilePath) || File.Exists(ApplicationConfiguration.OldConfigurarionFilePath))
                _applicationConfiguration = ApplicationConfiguration.Load(out errorText);

            if (_applicationConfiguration != null)
            {
                _moviestormPaths = new MoviestormPaths(_applicationConfiguration.MoviestormInstallationPath,
                    _applicationConfiguration.MoviestormUserDataPath);
                AddonDupSet.DuplicateDetectionFlag = _applicationConfiguration.DuplicateDetectionFlag;
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


        private bool ScanCmdLineArguments()
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

            if (!firstOption)
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
            formToolTip = new ToolTip();
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

            formToolTip.SetToolTip(cbAppendToDatabase, "Append valid addons to current catalogue");
            formToolTip.SetToolTip(cbRefreshItemsInDatabase, "Refresh valid addons in current catalogue");
            formToolTip.SetToolTip(pbCredits, "Credits Information");

            formToolTip.SetToolTip(pbClearAddonDatabase, "Clear content of the Addon catalogue");
            formToolTip.SetToolTip(pbInitAddonDatabase, "Initialize Addon catalogue with the addons currently installed");
            formToolTip.SetToolTip(pbSaveAddonDatabase, "Save current Addon catalogue to file");
            formToolTip.SetToolTip(cbAutoSave, "Automatically saves the current catalogue whenever some change happens");

            formToolTip.SetToolTip(pbsResetAddonCriteria, "Reset Addon Search Criteria");
            formToolTip.SetToolTip(pbsResetAssetCriteria, "Reset Asset Search Criteria");
            formToolTip.SetToolTip(pbsResetCriteria, "Reset Search Criteria (addon and asset)");
            formToolTip.SetToolTip(pbatClearAll, "Uncheck (deselect) every type of asset");
            formToolTip.SetToolTip(pbatSetAll, "Check (select) every type of asset");
            formToolTip.SetToolTip(pbsSearch, "Search assets according to the addon and asset criteria specified");

            formToolTip.SetToolTip(tbsAddonName, "Addon Name: list of strings to search for, separated by commas (preferably) or spaces (ignores case)");
            formToolTip.SetToolTip(tbsAddonPublisher, "Addon Publisher: list of strings to search for, separated by commas (preferably) or spaces (ignores case)");
            formToolTip.SetToolTip(tbsAddonLocation, "Addon location (ignores case)");
            formToolTip.SetToolTip(tbsAssetName, "Asset Name: list of strings to search for, separated by commas (preferably) or spaces (ignores case)");
            formToolTip.SetToolTip(tbAssetSubTypes, "List of Asset Subtype literals, separated by commas (preferably) or spaces (ignores case)");
            formToolTip.SetToolTip(tbsAssetTags, "List of Asset Tags, separated by commas (preferably) or spaces (ignores case)");
            formToolTip.SetToolTip(tbsAssetExtraInfo, "List of words to search for, separated by commas (preferably) or spaces (ignores case)");
            formToolTip.SetToolTip(cbascInstalled, "Filter addons: installed/not installed/all");
            formToolTip.SetToolTip(cbascType, "Filter addons: official content packs/third party addons/both");

            formToolTip.SetToolTip(pbSetup1, "Application setup");
            formToolTip.SetToolTip(dgvAddons, "Drag and drop on the grid: addon files, folders, and/or ZIP/RAR/7z archives for adding to the Catalogue\nRight-click for options\nDouble-click row for listing addon contents");
            formToolTip.SetToolTip(lblTipTable, "Drag and drop on the grid: addon files, folders, and/or ZIP/RAR/7z archives for adding to the Catalogue\nRight-click for options\nDouble-click row for listing addon contents");

            formToolTip.SetToolTip(pbCatNew, "Create a new addon catalogue (and make it the current catalogue)");
            formToolTip.SetToolTip(pbCatEdit, "Change the description of the selected catalogue");
            formToolTip.SetToolTip(pbCatRename, "Rename the selected catalogue");
            formToolTip.SetToolTip(pbCatCopy, "Create a copy of the selected catalogue");
            formToolTip.SetToolTip(pbCatDelete, "Delete the selected catalogue");
            formToolTip.SetToolTip(pbCatLoad, "Load from file the selected catalogue, replacing the currently active");
            formToolTip.SetToolTip(pbCatLoadChild, "Load from file the selected catalogue in another instance of the application (window)");
            formToolTip.SetToolTip(pbCatSave, "Save to file the currently active catalogue");
            formToolTip.SetToolTip(pbCatSetDefault, "Mark the selected catalogue as the one loaded when the program is launched");
            formToolTip.SetToolTip(pbRefreshIndex, "Refresh the Index of Addon catalogues, according to the catalogue files found");

            formToolTip.SetToolTip(cbListAlwaysAnimations, "List animations, regardless the addon includes verbs or not");
            
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
            {
                RefreshCatalogueAddonTable();
                if(cbAutoSave.Checked && (_addonPackageSet.LastUpdate > _addonPackageSetTimeStamp))
                   SaveCurrentAddonDatabase();
            }
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
                    if (cbRefreshItemsInDatabase.Checked)
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
                    if (!string.IsNullOrEmpty(_currentAddonDatabaseName))
                    {
                        tbLog.AppendText("Saving Addon Catalogue...\n");
                        tbLog.AppendText(_addonPackageSet.Save(out errorText, _currentAddonDatabaseName)
                            ? "   Addon Catalogue successfully saved.\n"
                            : $"  ERROR: saving Addon Catalogue: {errorText}\n");
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
            DuplicateDetectionFlag oldDuplicateDetectionFlag = _applicationConfiguration.DuplicateDetectionFlag;
            SetupForm setupForm = new SetupForm(_applicationConfiguration);
            if (setupForm.ShowDialog(this) != DialogResult.OK)
                return false;

            _applicationConfiguration = setupForm.ApplicationConfiguration;
            _moviestormPaths = new MoviestormPaths(_applicationConfiguration.MoviestormInstallationPath, _applicationConfiguration.MoviestormUserDataPath);
            if (oldDuplicateDetectionFlag != _applicationConfiguration.DuplicateDetectionFlag)
            {
                AddonDupSet.DuplicateDetectionFlag = _applicationConfiguration.DuplicateDetectionFlag;
                RefreshCatalogueAddonTable();
            }

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

        private void RefreshCatalogueAddonTable()
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
            lblAddonDbFilename.Text = _currentAddonDatabaseName;
            string mainFormText = !string.IsNullOrEmpty(_currentAddonDatabaseName)
                ? $@"StormCat     (version {Utils.GetExecutableVersion()})  -  {_currentAddonDatabaseName}"
                : $@"StormCat     (version {Utils.GetExecutableVersion()})";
            if (_isChildProcess)
                mainFormText += "  [Child]";
            Text = mainFormText;
            lblAddonCount.Text = $@"{_addons.Addons?.Count ?? 0}";
            if (_addons.DuplicatesFound == 0)
                lblAddonDupsCount.Visible = false;
            else
            {
                lblAddonDupsCount.Text = $@"Possible Duplicates: {_addons.DuplicatesFound} ({_addons.DuplicateGroups} groups)";
                lblAddonDupsCount.Visible = true;
                formToolTip.SetToolTip(lblAddonDupsCount, GetLabelAddonDupsCountToolTip());
            }
        }


        private void lblAddonDupsCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetLabelAddonDupsCountToolTip(), @"Duplicate detection criteria", MessageBoxButtons.OK);
        }


        private string GetLabelAddonDupsCountToolTip()
        {
            string text = AddonDupSet.GetDuplicateDetectionCriteria().Replace(",", "\n");
            return $"Duplicate detection criteria:\n {text}";
        }


        private void dgvAddons_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAddons.Columns["dgvAddonName"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAddons.Columns["dgvAddonPublisher"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvAddons.Columns["dgvAddonLocation"].SortMode = DataGridViewColumnSortMode.Automatic;
        }


        private int GetAddonSelectedRowIndex()
        {
            if ((_addons?.Addons == null) || (_addons.Addons.Count == 0))
                return -1;

            int rowIndex = dgvAddons.CurrentCell.RowIndex;
            return (rowIndex < 0) ? -1 : rowIndex;
        }



        private void cmAddonTable_Opening(object sender, CancelEventArgs e)
        {
            cmiDisplayReport.Enabled = cmiShowContents.Enabled = 
                cmiRefreshAddon.Enabled = cmiDeleteAddon.Enabled = 
                    cmiExportExcel.Enabled = 
                    cmiCopyClipboard.Enabled = // cmiPasteClipboard.Enabled =
                    false;


            string text = Clipboard.GetText();
            string errorText;
            List<AddonPackage> subSet = AddonPackageSetOperator.DeserializeAddonPackageList(text, out errorText);
            cmiPasteClipboard.Enabled = (subSet != null);

            int rowIndex = GetAddonSelectedRowIndex();
            if (rowIndex < 0)
            {
                e.Cancel = !cmiPasteClipboard.Enabled;
                return;
            }

            // int countSelected = dgvAddons.SelectedRows.Count;

            cmiDisplayReport.Enabled = cmiShowContents.Enabled = 
                    cmiRefreshAddon.Enabled = cmiDeleteAddon.Enabled = 
                    cmiExportExcel.Enabled =
                    cmiCopyClipboard.Enabled =
                    true;
        }


        private string GetSelectedAddonNameLocation(out string pLocation)
        {
            pLocation = (string)dgvAddons.SelectedRows[0].Cells["dgvAddonLocation"].Value;
            return (string)dgvAddons.SelectedRows[0].Cells["dgvAddonPublisher"].Value + "." + (string)dgvAddons.SelectedRows[0].Cells["dgvAddonName"].Value;
        }


        private List<string> GetSelectedAddonNamesLocations(out List<string> pLocations)
        {
            pLocations = null;
            if ((dgvAddons.SelectedRows == null) || (dgvAddons.SelectedRows.Count == 0))
                return null;

            List<string> names = new List<string>();
            pLocations = new List<string>();
            foreach (DataGridViewRow row in dgvAddons.SelectedRows)
            {
                pLocations.Add((string) row.Cells["dgvAddonLocation"].Value);
                names.Add((string)row.Cells["dgvAddonPublisher"].Value + "." + (string)row.Cells["dgvAddonName"].Value);
            }

            return names;
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


        private void ShowAddonContents()
        {
            string location;
            string name = GetSelectedAddonNameLocation(out location);

            AddonPackage package = _addonPackageSet.FindByLocation(location);
            if (package == null)
                return;


            AssetSearchCriteria criteria = null;
            if(!cbListAlwaysAnimations.Checked && (package.AssetSummary.Verbs > 0))
            {
                AddonAssetType types = AddonAssetType.Any ^ AddonAssetType.Animation;
                criteria = new AssetSearchCriteria(null, types, null, null, null);
            }
            
            List<AssetSearchResultItem> assets = _addonPackageSet.SearchAsset(new List<AddonPackage>() { package }, criteria);
            if (assets == null)
                return;
            assets = assets.OrderBy(o => o.SortKey).ToList();
            
            AddonContentForm contentForm = new AddonContentForm(name, assets);
            contentForm.Show(this);
        }


        private void cmiShowContents_Click(object sender, EventArgs e)
        {
            ShowAddonContents();
        }


        private void dgvAddons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GetAddonSelectedRowIndex() < 0)
                return;
            ShowAddonContents();
        }


        private void cmiExportExcel_Click(object sender, EventArgs e)
        {
            if ((_addonPackageSet?.Addons == null) || (_addonPackageSet.Addons.Count == 0))
                return;

            sfdAddonListExportExcel.FileName =
                string.IsNullOrEmpty(_currentAddonDatabaseName.Trim())
                ? "AddonsCatalogue.xlsx"
                : Path.GetFileNameWithoutExtension(_currentAddonDatabaseName) + ".xlsx";
            if (sfdAddonListExportExcel.ShowDialog(this) != DialogResult.OK)
                return;

            string file = sfdAddonListExportExcel.FileName;
            string errorText;
            if (!ExcelExporter.ExcelExport(dgvAddons, file, "Addons", out errorText))
                MessageBox.Show($@"An error has happened while trying to export to Excel:\n{errorText}",
                    @"Exportation error", MessageBoxButtons.OK);
        }


        private void cmiRefreshAddon_Click(object sender, EventArgs e)
        {
            // string location;
            // string name = GetSelectedAddonNameLocation(out location);

            List<string> locations;
            List<string> names = GetSelectedAddonNamesLocations(out locations);
            if ((locations == null) || (locations.Count == 0))
                return;
            
            for (int index = 0; index < names.Count; ++index)
                RefreshAddon(names[index], locations[index]);

            RefreshCatalogueAddonTable();
            if (cbAutoSave.Checked && (_addonPackageSet.LastUpdate > _addonPackageSetTimeStamp))
                SaveCurrentAddonDatabase();
        }


        private void RefreshAddon(string pName, string pLocation)
        {
            // Determine if inside an archive:
            int archiveIndex = pLocation.LastIndexOf(("#"));
            if (archiveIndex > 0)
                pLocation = pLocation.Substring(0, archiveIndex);

            ProcessingFlags processingFlags = ProcessingFlags.AppendToAddonPackageSet |
                                              ProcessingFlags.AppendToAddonPackageSetForceRefresh;

            IDiskEntity asset = DiskEntityHelper.GetEntity(pLocation, null, new NullReportWriter());

            if (asset == null)
            {
                return;
            }
            asset.CheckEntity(processingFlags);

            tbLog.AppendText($"Addon '{pName}' refreshed\n");
        }


        private void cmiDeleteAddon_Click(object sender, EventArgs e)
        {
            List<string> locations;
            List<string> names = GetSelectedAddonNamesLocations(out locations);
            if ((locations == null) || (locations.Count == 0))
                return;

            string messageText =
                (locations.Count == 1)
                    ? $"Delete addon {names[0]} from Catalogue. Please Confirm?"
                    : $"Delete {locations.Count} addons from Catalogue. Please Confirm?";

            if (MessageBox.Show(messageText, "Delete Addon(s) from Catalogue",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            bool deletedAny = false;

            for (int index = 0; index < names.Count; ++index)
            {
                if (_addonPackageSet.DeleteByLocation(locations[index]))
                {
                    deletedAny = true;
                    tbLog.AppendText($"Addon '{names[index]}' deleted\n");
                }
            }

            if (deletedAny)
            {
                RefreshCatalogueAddonTable();
                if (cbAutoSave.Checked)
                    SaveCurrentAddonDatabase();
            }
        }


        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void cmiCopyClipboard_Click(object sender, EventArgs e)
        {
            List<string> locations;
            List<string> names = GetSelectedAddonNamesLocations(out locations);
            if ((locations == null) || (locations.Count == 0))
                return;

            AddonPackageSetOperator setOperator = new AddonPackageSetOperator(_addonPackageSet);
            string text = setOperator.GetAddonSubSetText(names);
            if (string.IsNullOrEmpty(text))
                return;

            Clipboard.SetText(text);
            tbLog.AppendText($"Subset of {names.Count} Addons copied to the clipboard\n");
        }



        private void cmiPasteClipboard_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            string errorText;
            List<AddonPackage> subSet = AddonPackageSetOperator.DeserializeAddonPackageList(text, out errorText);
            if (subSet == null)
            {
                tbLog.AppendText("No valid addon data in the clipboard\n");
                return;
            }

            AddonPackageSetOperator setOperator = new AddonPackageSetOperator(_addonPackageSet);
            int count = setOperator.AppendAddonSubSet(subSet);

            tbLog.AppendText($"{count} addons appended to the Catalogue\n");
            if (count > 0)
            {
                RefreshCatalogueAddonTable();
                if (cbAutoSave.Checked)
                    SaveCurrentAddonDatabase();
            }
        }


        // ---------------------------------------------------------------------------------------------------------------------------------------------------------

        private void pbCheckDups_Click(object sender, EventArgs e)
        {

        }
        
        // ---------------------------------------------------------------------------------------------------------------------------------------------------------


        private void pbsResetAddonCriteria_Click(object sender, EventArgs e)
        {
            ResetAddonCriteria();
        }

        private void ResetAddonCriteria()
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
            cbatBodyPart.Checked = cbatDecal.Checked = cbatProp.Checked = cbatVerb.Checked = cbatAnimation.Checked = 
            cbatMaterial.Checked =
                cbatSound.Checked = cbatCuttingRoom.Checked = cbatSky.Checked = cbatSfx.Checked = cbatOther.Checked = cbatStock.Checked = cbatMovie.Checked = pSelect;
        }


        private void pbsResetAssetCriteria_Click(object sender, EventArgs e)
        {
            ResetAssetCriteria();
        }

        private void ResetAssetCriteria()
        {
            tbsAssetName.Text = tbsAssetTags.Text = tbAssetSubTypes.Text = tbsAssetExtraInfo.Text = null;
            SelectAllAssetTypes(true);
            cbatAnimation.Checked = false;
        }

        private void pbsResetCriteria_Click(object sender, EventArgs e)
        {
            ResetAddonCriteria();
            ResetAssetCriteria();
        }



        private void pbsSearch_Click(object sender, EventArgs e)
        {
            bool? installed = null;
            switch (cbascInstalled.SelectedIndex)
            {
                case 1:
                    installed = true;
                    break;
                case 2:
                    installed = false;
                    break;
            }

            bool? contentPack = null;
            switch (cbascType.SelectedIndex)
            {
                case 1:
                    contentPack = true;
                    break;
                case 2:
                    contentPack = false;
                    break;
            }

            AddonSearchCriteria addonSearchCriteria = new AddonSearchCriteria(tbsAddonName.Text, tbsAddonPublisher.Text, installed, contentPack, tbsAddonLocation.Text);

            AddonAssetType assetType = AddonAssetType.Null;
            if (cbatBodyPart.Checked) assetType |= AddonAssetType.BodyPart;
            if (cbatDecal.Checked) assetType |= AddonAssetType.Decal;
            if (cbatProp.Checked) assetType |= AddonAssetType.Prop;
            if (cbatVerb.Checked) assetType |= AddonAssetType.Verb;
            if (cbatAnimation.Checked) assetType |= AddonAssetType.Animation;
            if (cbatMaterial.Checked) assetType |= AddonAssetType.Material;
            if (cbatSound.Checked) assetType |= AddonAssetType.Sound;
            if (cbatCuttingRoom.Checked) assetType |= AddonAssetType.CuttingRoomAsset;
            if (cbatSky.Checked) assetType |= AddonAssetType.SkyTexture;
            if (cbatSfx.Checked) assetType |= AddonAssetType.SpecialEffect;
            if (cbatOther.Checked) assetType |= AddonAssetType.OtherAsset;
            if (cbatStock.Checked) assetType |= AddonAssetType.Stock;
            if (cbatMovie.Checked) assetType |= AddonAssetType.StartMovie;

            AssetSearchCriteria assetSearchCriteria = new AssetSearchCriteria(tbsAssetName.Text, assetType, tbAssetSubTypes.Text?.Trim(), tbsAssetTags.Text?.Trim(), tbsAssetExtraInfo.Text?.Trim());

            List<AssetSearchResultItem> searchOutput = _addonPackageSet.Search(addonSearchCriteria, assetSearchCriteria);

            if (!ReportSearchSummary(searchOutput))
                return;

            searchOutput = searchOutput.OrderBy(o => o.SortKey).ToList();

            AssetSearchResultForm resultForm = new AssetSearchResultForm(searchOutput, _addonPackageSet, cbListAlwaysAnimations.Checked);
            resultForm.Show(this);
        }


        private bool ReportSearchSummary(List<AssetSearchResultItem> pSearchOutput)
        {
            tbSearchLog.Clear();
            tbSearchLog.AppendText("Search result summary.\n");
            if ((pSearchOutput == null) || (pSearchOutput.Count == 0))
            {
                tbSearchLog.AppendText("    No assets found.");
                return false;
            }

            SearchStatistics searchStatistics = new SearchStatistics(pSearchOutput);
            
            if (searchStatistics.TotalAssets == 0)
            {
                tbSearchLog.AppendText("    No assets found.");
                return false;
            }

            tbSearchLog.AppendText($"FOUND: {searchStatistics.TotalAssets} Assets in {searchStatistics.Addons} Addons by {searchStatistics.Publishers} Publishers:\n");
            if(searchStatistics.Bodyparts > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Bodyparts,6} Bodyparts\n");
            if (searchStatistics.Decals > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Decals,6} Decals\n");
            if (searchStatistics.Props > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Props,6} Props\n");
            if (searchStatistics.Verbs > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Verbs,6} Verbs\n");
            if (searchStatistics.Animations > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Animations,6} Animations\n");
            if (searchStatistics.Materials > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Materials,6} Materials\n");
            if (searchStatistics.Sounds > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Sounds,6} Sounds\n");
            if (searchStatistics.CuttingRoomAssets > 0)
                tbSearchLog.AppendText($"    {searchStatistics.CuttingRoomAssets,6} Filters\n");
            if (searchStatistics.SpecialEffects > 0)
                tbSearchLog.AppendText($"    {searchStatistics.SpecialEffects,6} Special Effects\n");
            if (searchStatistics.SkyTextures > 0)
                tbSearchLog.AppendText($"    {searchStatistics.SkyTextures,6} Sky Textures\n");
            if (searchStatistics.OtherAssets > 0)
                tbSearchLog.AppendText($"    {searchStatistics.OtherAssets,6} Other Assets\n");
            if (searchStatistics.Stocks > 0)
                tbSearchLog.AppendText($"    {searchStatistics.Stocks,6} Stocks\n");
            if (searchStatistics.StartMovies > 0)
                tbSearchLog.AppendText($"    {searchStatistics.StartMovies,6} Demo Movies\n");

            return true;
        }



        #endregion DatabaseTab

        private void pbClearAddonDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear Addon Catalogue? Please Confirm", "Clear Addon Catalogue",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            tbLog.AppendText("Clearing Addon Catalogue...\n");
            _addonPackageSet.Clear();
            RefreshCatalogueAddonTable();
            tbLog.AppendText("   Addon Catalogue cleared.\n");
            // _currentAddonDatabaseName = null;
            // lblAddonDbFilename.Text = null;
        }



        private void pbInitAddonDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Initialize Addon Catalogue? Its current content will be cleared and then every installed addon will be added to the Catalogue. Please Confirm", "Initialize Addon Catalogue",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            tbLog.AppendText("Initializing Addon Catalogue (it can take a while)...\n");
            _addonPackageSet.InitializeDatabase();

            RefreshCatalogueAddonTable();
            tbLog.AppendText("   Addon Catalogue initialized\n");

        }




        private void LoadAddonDatabase(string pDatabaseName)
        {
            if (string.IsNullOrEmpty(pDatabaseName = pDatabaseName?.Trim()))
                return;

            string fileName = pDatabaseName + AddonPackageSet.AddonPackageSetFileExtension;
            if (!File.Exists(fileName))
                return;

            string errorText;
            AddonPackageSet addonSet = AddonPackageSet.Load(out errorText, fileName);
            if (addonSet == null)
            {
                _logReportWriter.WriteReportLineFeed($"ERROR trying to load Addon Catalogue fron file: {errorText}");
                return;
            }

            UpdateCurrentAddonDatabaseInfo(pDatabaseName, addonSet);
            _logReportWriter.WriteReportLineFeed($"Catalogue loaded from file '{_currentAddonDatabaseName}'");
            _logReportWriter.WriteReportLineFeed($"    Addons registered: {_addonPackageSet.Addons?.Count ?? 0}");
            _logReportWriter.WriteReportLineFeed($"    Last updated: {_addonPackageSet.LastUpdate}");
        }


        private void UpdateCurrentAddonDatabaseInfo(string pName, AddonPackageSet pAddonPackageSet)
        {
            _addonPackageSet = pAddonPackageSet;
            _addonPackageSetTimeStamp = _addonPackageSet.LastUpdate;
            _currentAddonDatabaseName = ShortenAddonFileName(pName);
            lblAddonDbFilename.Text = _currentAddonDatabaseName;
            DiskEntityBase.AddonPackageSet = _addonPackageSet;
            RefreshCatalogueAddonTable();
        }


        private void pbSaveAddonDatabase_Click(object sender, EventArgs e)
        {
            SaveCurrentAddonDatabase();
        }


        private void SaveCurrentAddonDatabase()
        {
            if ((_currentAddonDatabaseName == null) || (_addonPackageSet == null))
                return;

            string fileName = _currentAddonDatabaseName + AddonPackageSet.AddonPackageSetFileExtension;

            string errorText;
            if (!_addonPackageSet.Save(out errorText, fileName))
            {
                _logReportWriter.WriteReportLineFeed($"ERROR trying to save Addon Catalogue to file: {errorText}");
                return;
            }

            _addonPackageSetTimeStamp = _addonPackageSet.LastUpdate;
            _logReportWriter.WriteReportLineFeed($"Catalogue '{_currentAddonDatabaseName}' saved to file");
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

            RefreshCatalogueAddonTable();
            if(cbAutoSave.Checked && (_addonPackageSet.LastUpdate > _addonPackageSetTimeStamp))
                SaveCurrentAddonDatabase();
        }

        private void lblTipTable_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Drag and drop on the grid: addon files, folders, and/or ZIP/RAR/7z archives for adding to the Catalogue.\nRight-click for options.\nDouble-click row for listing addon contents.",
                "Addons in Catalogue View", MessageBoxButtons.OK);
        }

        // ---------------------------------------------------------------------------------------------------------------------------------

        private void RefreshCatalogueIndexTable(string pSelectedCatalogueName = null)
        {

            dgvCatalogueIndex.AutoGenerateColumns = false;

            BindingSource source = null;
            if ((_cataloguesIndex.Catalogues?.Count ?? 0) > 0)
            {
                var bindingList = new SortableBindingList<CatalogueInfo>(_cataloguesIndex.Catalogues);
                source = new BindingSource(bindingList, null);
            }

            dgvCatalogueIndex.DataSource = source;
            if ((source == null) || (pSelectedCatalogueName == null))
                return;

            int index = _cataloguesIndex.GetIndexByName(pSelectedCatalogueName);
            if (index < 0)
                return;
            dgvCatalogueIndex.Rows[index].Selected = true;
        }


        private void dgvCatalogueIndex_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int index;
            if (_cataloguesIndex.DefaultAddonDatabase != null)
            {
                index = _cataloguesIndex.GetIndexByName(_cataloguesIndex.DefaultAddonDatabase);
                if (index >= 0)
                {
                    dgvCatalogueIndex["colCatDefault", index].Value = "true";
                }
            }

            if (_currentAddonDatabaseName != null)
            {
                index = _cataloguesIndex.GetIndexByName(_currentAddonDatabaseName);
                if (index >= 0)
                {
                    dgvCatalogueIndex["colCatCurrent", index].Value = "true";
                }
            }
        }


        private void cmCatManager_Opening(object sender, CancelEventArgs e)
        {
            if ((_cataloguesIndex?.Catalogues == null) || (_cataloguesIndex.Catalogues.Count == 0))
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = false;
        }


        private void pbCatNew_Click(object sender, EventArgs e)
        {
            CatManagerNew();
        }


        private void cmiCatManNew_Click(object sender, EventArgs e)
        {
            CatManagerNew();
        }


        private void CatManagerNew()
        {
            CatalogueIndexOpsForm catOpsForm = new CatalogueIndexOpsForm(CataloguesIndexOperation.NewCatalogue,
                _moviestormPaths, _cataloguesIndex, null);

            if (catOpsForm.ShowDialog(this) != DialogResult.OK)
                return;

            _cataloguesIndex = catOpsForm.CataloguesIndex;
            _addonPackageSet = catOpsForm.NewAddonPackageSet;
            _currentAddonDatabaseName = catOpsForm.NewAddonPackageSetName;
            DiskEntityBase.AddonPackageSet = _addonPackageSet;

            RefreshCatalogueIndexTable(_currentAddonDatabaseName);

            RefreshCatalogueAddonTable();

            _logReportWriter.WriteReportLineFeed($"New addon catalogue created: {_currentAddonDatabaseName}");
            tcMainForm.SelectedTab = tpDatabase;
        }

        // ......................


        private int GetSelectedCatalogueRowIndex()
        {
            if ((_cataloguesIndex?.Catalogues == null) || (_cataloguesIndex.Catalogues.Count == 0))
                return -1;

            int rowIndex = dgvCatalogueIndex.CurrentCell.RowIndex;
            return (rowIndex < 0) ? -1 : rowIndex;
        }

        // ...................

        private void pbCatEdit_Click(object sender, EventArgs e)
        {
            CatManagerEdit();
        }


        private void cmiCatManEdit_Click(object sender, EventArgs e)
        {
            CatManagerEdit();
        }

        private void CatManagerEdit()
        {
            string selectedCatalogueName = GetSelectedCatalogueName();
            if (selectedCatalogueName == null)
                return;

            CatalogueIndexOpsForm catOpsForm = new CatalogueIndexOpsForm(CataloguesIndexOperation.EditDescription,
                _moviestormPaths, _cataloguesIndex, selectedCatalogueName);

            if (catOpsForm.ShowDialog(this) != DialogResult.OK)
                return;

            _cataloguesIndex = catOpsForm.CataloguesIndex;

            RefreshCatalogueIndexTable(selectedCatalogueName);

            RefreshCatalogueAddonTable();
        }

        // .....................

        private void pbCatRename_Click(object sender, EventArgs e)
        {
            CatManagerRename();
        }

        private void cmiCatManRename_Click(object sender, EventArgs e)
        {
            CatManagerRename();
        }

        private void CatManagerRename()
        {
            string selectedCatalogueName = GetSelectedCatalogueName();
            if (selectedCatalogueName == null)
                return;

            bool renamingCurrent = ((_currentAddonDatabaseName != null) &&
                                    (_currentAddonDatabaseName == selectedCatalogueName));

            CatalogueIndexOpsForm catOpsForm = new CatalogueIndexOpsForm(CataloguesIndexOperation.RenameCatalogue,
                _moviestormPaths, _cataloguesIndex, selectedCatalogueName);

            if (catOpsForm.ShowDialog(this) != DialogResult.OK)
                return;

            _cataloguesIndex = catOpsForm.CataloguesIndex;
            if (_cataloguesIndex.DefaultAddonDatabase == selectedCatalogueName)
            {
                _cataloguesIndex.DefaultAddonDatabase = catOpsForm.NewAddonPackageSetName;
                string errorText;
                _cataloguesIndex.Save(CataloguesIndex.CataloguesIndexFilePath, out errorText);
            }

            if (renamingCurrent)
            {
                _currentAddonDatabaseName = catOpsForm.NewAddonPackageSetName;
            }

            RefreshCatalogueIndexTable(catOpsForm.NewAddonPackageSetName);

            RefreshCatalogueAddonTable();
        }

        // ............................

        private void pbCatDelete_Click(object sender, EventArgs e)
        {
            CatManagerDelete();
        }

        private void cmiCatManDelete_Click(object sender, EventArgs e)
        {
            CatManagerDelete();
        }

        private void CatManagerDelete()
        {
            if ((_cataloguesIndex?.Catalogues.Count ?? 0) == 0)
            {
                // MessageBox.Show("There must be at least one Catalogue left at any time", "Operation denied",MessageBoxButtons.OK);
                return;
            }

            string selectedCatalogueName = GetSelectedCatalogueName();
            if (selectedCatalogueName == null)
                return;

            if (MessageBox.Show($"Please confirm deletion of addon catalogue '{selectedCatalogueName}'", "Confirmation",
                    MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            bool isLast = _cataloguesIndex.Catalogues.Count == 1;
            bool isLoaded = selectedCatalogueName == _currentAddonDatabaseName;
            bool isDefault = selectedCatalogueName == _cataloguesIndex.DefaultAddonDatabase;

            _cataloguesIndex.Delete(selectedCatalogueName);
            File.Delete(selectedCatalogueName + AddonPackageSet.AddonPackageSetFileExtension);

            string errorText;

            if (isLast)
            {
                _cataloguesIndex.DefaultAddonDatabase = AddonPackageSet.DefaultAddonPackageSet;
                _cataloguesIndex.Update(AddonPackageSet.DefaultAddonPackageSetName, "Default addon catalogue");

                _addonPackageSet = new AddonPackageSet(_moviestormPaths, null, "Default addon catalogue");
                _addonPackageSet.Save(out errorText);

                UpdateCurrentAddonDatabaseInfo(AddonPackageSet.DefaultAddonPackageSetName, _addonPackageSet);
            }
            else
            {

                if (isDefault)
                {
                    _cataloguesIndex.DefaultAddonDatabase = _cataloguesIndex.Catalogues[0].Name;
                    _cataloguesIndex.Save(CataloguesIndex.CataloguesIndexFilePath, out errorText);
                    // RefreshCatalogueAddonTable();
                }

                if (isLoaded)
                {
                    LoadAddonDatabase(_cataloguesIndex.DefaultAddonDatabase);
                }
            }

            RefreshCatalogueIndexTable(_currentAddonDatabaseName);
        }


        // ....................................

        private void pbCatCopy_Click(object sender, EventArgs e)
        {
            CatManagerCopy();
        }


        private void cmiCatManCopy_Click(object sender, EventArgs e)
        {
            CatManagerCopy();
        }


        private void CatManagerCopy()
        {
            string selectedCatalogueName = GetSelectedCatalogueName();
            if (selectedCatalogueName == null)
                return;

            CatalogueIndexOpsForm catOpsForm = new CatalogueIndexOpsForm(CataloguesIndexOperation.CopyCatalogue,
                _moviestormPaths, _cataloguesIndex, selectedCatalogueName);

            if (catOpsForm.ShowDialog(this) != DialogResult.OK)
                return;

            _cataloguesIndex = catOpsForm.CataloguesIndex;
            RefreshCatalogueIndexTable(_currentAddonDatabaseName);
        }

        // .................................................................

        private void pbCatLoad_Click(object sender, EventArgs e)
        {
            CatManagerLoad();
        }

        private void cmiCatManLoad_Click(object sender, EventArgs e)
        {
            CatManagerLoad();
        }


        private void CatManagerLoad()
        {
            string catalogueName = GetSelectedCatalogueName();
            if (string.IsNullOrEmpty(catalogueName))
                return;

            // if (catalogueName == _currentAddonDatabaseName)
            //    return;
            if ((_addonPackageSetTimeStamp < _addonPackageSet.LastUpdate) &&
                (catalogueName != _currentAddonDatabaseName))
            {
                if (MessageBox.Show("Would you like to save changes to the current catalogue before loading the new one?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                    SaveCurrentAddonDatabase();
            }

            LoadAddonDatabase(catalogueName);

            RefreshCatalogueIndexTable(catalogueName);

            tcMainForm.SelectedTab = tpDatabase;
        }

        // ........................................................

        private void pbCatLoadChild_Click(object sender, EventArgs e)
        {
            CatManagerLoadInChild();
        }


        private void cmiCatManLoadChild_Click(object sender, EventArgs e)
        {
            CatManagerLoadInChild();
        }

        private void CatManagerLoadInChild()
        {
            string catalogueName = GetSelectedCatalogueName();
            if (string.IsNullOrEmpty(catalogueName))
                return;

            if (!File.Exists(catalogueName + AddonPackageSet.AddonPackageSetFileExtension))
                return;

            string executablePath = Utils.GetExecutableFullPath();

            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = executablePath,
                WindowStyle = ProcessWindowStyle.Normal,
                Arguments = $"-child:{catalogueName}"
            };

            Process childProcess = Process.Start(processStartInfo);
        }


        // ........................................................



        private void pbCatSetDefault_Click(object sender, EventArgs e)
        {
            CatManagerSetDefault();
        }


        private void cmiCatManSetDefault_Click(object sender, EventArgs e)
        {
            CatManagerSetDefault();
        }

        private void CatManagerSetDefault()
        {
            string catalogueName = GetSelectedCatalogueName();
            if (string.IsNullOrEmpty(catalogueName))
                return;

            _cataloguesIndex.DefaultAddonDatabase = catalogueName;
            string errorText;
            _cataloguesIndex.Save(CataloguesIndex.CataloguesIndexFilePath, out errorText);
            RefreshCatalogueIndexTable(catalogueName);
        }


        // ....................................................


        private void pbCatSave_Click(object sender, EventArgs e)
        {
            SaveCurrentAddonDatabase();
        }


        private void cmiCatManSave_Click(object sender, EventArgs e)
        {
            SaveCurrentAddonDatabase();
        }


        // ................................................


        private string GetSelectedCatalogueName()
        {
            if (GetSelectedCatalogueRowIndex() < 0)
                return null;

            return (string)dgvCatalogueIndex.SelectedRows[0].Cells["colCatName"].Value;
        }


        private void pbRefreshIndex_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please confirm you want to re-create the Catalogue Index.", "Confirmation",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            string errorText;
            _cataloguesIndex = CataloguesIndex.Initialize(_moviestormPaths, out errorText);

            if ((_cataloguesIndex.Catalogues?.Count ?? 0) == 0)
            {
                _currentAddonDatabaseName = null;
                _addonPackageSet = null;
                DiskEntityBase.AddonPackageSet = null;

                RefreshCatalogueIndexTable();
                RefreshCatalogueAddonTable();
                return;
            }

            string catalogueToLoad = _cataloguesIndex.DefaultAddonDatabase ?? _cataloguesIndex.Catalogues[0].Name;

            LoadAddonDatabase(catalogueToLoad);
            RefreshCatalogueIndexTable(catalogueToLoad);
            RefreshCatalogueAddonTable();
        }


        private void dgvCatalogueIndex_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string catalogueName = GetSelectedCatalogueName();
            if (string.IsNullOrEmpty(catalogueName))
                return;

            LoadAddonDatabase(catalogueName);
            RefreshCatalogueIndexTable(catalogueName);
            RefreshCatalogueAddonTable();
            tcMainForm.SelectedTab = tpDatabase;
        }



        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_childHiddenPages != null)
            {
                foreach(TabPage page in _childHiddenPages)
                    page.Dispose();
            }
        }


        private void pbCredits_Click(object sender, EventArgs e)
        {
            CreditsForm creditsForm = new CreditsForm();
            creditsForm.ShowDialog(this);
        }



        private void pbHelp_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                string id = null;
                switch (tcMainForm.SelectedIndex)
                {
                    case 0: id = "100"; break;
                    case 1: id = "200"; break;
                    case 2: id = "300"; break;
                    case 3: id = "400"; break;
                }

                if (id == null)
                    return;

                if (!string.IsNullOrEmpty(Globals.HelpFileUri))
                    Help.ShowHelp(this, Globals.HelpFileUri, HelpNavigator.TopicId, id);
            }
            catch { }
            */
            try
            {
                if (!string.IsNullOrEmpty(Globals.HelpFileUri))
                    Help.ShowHelp(this, Globals.HelpFileUri, HelpNavigator.TopicId, "10");
            }
            catch { }
        }


        private void tcMainForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "100";
            switch (tcMainForm.SelectedIndex)
            {
                case 0: id = "100"; break;
                case 1: id = "200"; break;
                case 2: id = "300"; break;
                case 3: id = "400"; break;
            }
            ContextHelp.SetHelpKeyword(this, id);
            ContextHelp.SetHelpKeyword(tcMainForm, id);
        }


    }
}
