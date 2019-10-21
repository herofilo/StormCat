using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StormCat.Configuration;
using MSAddonLib.Util;
using MSAddonLib.Util.Persistence;
using StormCat.Domain;
using StormCat.Misc;

namespace StormCat
{
    public partial class SetupForm : Form
    {

        public ApplicationConfiguration ApplicationConfiguration { get; private set; }


        private ApplicationConfiguration _applicationConfiguration;

        // -----------------------------------------------------------------------------------

        public SetupForm(ApplicationConfiguration pApplicationConfiguration)
        {
            _applicationConfiguration = ApplicationConfiguration = pApplicationConfiguration;
            InitializeComponent();
        }




        private void SetupForm_Load(object sender, EventArgs e)
        {
            if (_applicationConfiguration == null)
                return;

            tbMoviestormInstallPath.Text = _applicationConfiguration.MoviestormInstallationPath;
            tbMoviestormUserDataPath.Text = _applicationConfiguration.MoviestormUserDataPath;

            SetDupDetectionCriteriaCheckBoxes(_applicationConfiguration.DuplicateDetectionFlag);
            // cbPreserveOptions.Checked = _applicationConfiguration.PreserveOptions;

            SetToolTips();
            ContextHelp.HelpNamespace = Globals.HelpFilename;
            ContextHelp.SetHelpNavigator(this, HelpNavigator.TopicId);
        }

        private void SetDupDetectionCriteriaCheckBoxes(DuplicateDetectionFlag pFlags)
        {
            SetDupDetectionCriteriaCheckBox(cbDupDetName, DuplicateDetectionFlag.Name, pFlags);
            SetDupDetectionCriteriaCheckBox(cbDupDetPublisher, DuplicateDetectionFlag.Publisher, pFlags);
            SetDupDetectionCriteriaCheckBox(cbDupDetRecompilable, DuplicateDetectionFlag.RecompilableFlag, pFlags);
            SetDupDetectionCriteriaCheckBox(cbDupDetAssetCount, DuplicateDetectionFlag.AssetCount, pFlags);
            SetDupDetectionCriteriaCheckBox(cbDupDetFileCount, DuplicateDetectionFlag.TotalFiles, pFlags);
            SetDupDetectionCriteriaCheckBox(cbDupDetLastPublished, DuplicateDetectionFlag.LastCompiled, pFlags);
            SetDupDetectionCriteriaCheckBox(cbDupDetMeshSize, DuplicateDetectionFlag.MeshDataSize, pFlags);
            SetDupDetectionCriteriaCheckBox(cbDupDetFingerprint, DuplicateDetectionFlag.Fingerprint, pFlags);
            if(cbDupDetFingerprint.Checked)
                SetDupDetectionCriteriaCheckBoxes2();
        }

        private void cbDupDetFingerprint_CheckedChanged(object sender, EventArgs e)
        {
            SetDupDetectionCriteriaCheckBoxes2();
        }

        private void SetDupDetectionCriteriaCheckBoxes2()
        {
            if (cbDupDetFingerprint.Checked)
            {
                cbDupDetName.Checked = cbDupDetPublisher.Checked = cbDupDetRecompilable.Checked =
                    cbDupDetAssetCount.Checked = cbDupDetFileCount.Checked =
                        cbDupDetLastPublished.Checked = cbDupDetMeshSize.Checked = false;
                cbDupDetName.Enabled = cbDupDetPublisher.Enabled = 
                    cbDupDetAssetCount.Enabled = cbDupDetFileCount.Enabled =
                        cbDupDetLastPublished.Enabled = cbDupDetMeshSize.Enabled = false;
                return;
            }
            cbDupDetName.Enabled = cbDupDetPublisher.Enabled =
                cbDupDetAssetCount.Enabled = cbDupDetFileCount.Enabled =
                    cbDupDetLastPublished.Enabled = cbDupDetMeshSize.Enabled = false;
            cbDupDetRecompilable.Checked = true;

            SetDupDetectionCriteriaCheckBoxes(AddonDupSet.DefaultDuplicateDetectionFlag);

        }


        private void SetDupDetectionCriteriaCheckBox(CheckBox pCheckBox, DuplicateDetectionFlag pFlag, DuplicateDetectionFlag pFlags)
        {
            if (AddonDupSet.ForcedDuplicateDetectionFlags.HasFlag(pFlag))
            {
                pCheckBox.Checked = true;
                pCheckBox.Enabled = false;
                return;
            }

            pCheckBox.Enabled = true;
            pCheckBox.Checked = pFlags.HasFlag(pFlag);
        }


        private void SetToolTips()
        {
            ToolTip formToolTip = new ToolTip();
            formToolTip.SetDefaults();

            // Sets up the ToolTip text for the Button and Checkbox.

            // formToolTip.SetToolTip(this, "Press F1 for help");

            formToolTip.SetToolTip(pbSelectInstallFolder, "Select Moviestorm installation folder");
            formToolTip.SetToolTip(pbSelectUserDataFolder, "Select Moviestorm user data folder");
            formToolTip.SetToolTip(pbPathsDefaults, "Try to get Moviestorm folders by default");
            formToolTip.SetToolTip(gbDupCriteria, "Select criteria for detection of (possibly) duplicate addons in a Catalogue");
            formToolTip.SetToolTip(pbDupCriteriaDefault, "Restore default criteria for detection of (possibly) duplicate addons in a Catalogue");

            formToolTip.SetToolTip(pbSave, "Save configuration");
            formToolTip.SetToolTip(pbCancel, "Cancel changes to configuration");

        }


        // -----------------------------------------------------------------------------------------------------------------

        private void pbSave_Click(object sender, EventArgs e)
        {
            string moviestormInstallPath = tbMoviestormInstallPath.Text.Trim();
            if (string.IsNullOrEmpty(moviestormInstallPath))
            {
                pbSelectInstallFolder.Focus();
                return;
            }

            string moviestormUserDataPath = tbMoviestormUserDataPath.Text.Trim();
            if (string.IsNullOrEmpty(moviestormUserDataPath))
            {
                pbSelectUserDataFolder.Focus();
                return;
            }

            ApplicationConfiguration newConfiguration = new ApplicationConfiguration(moviestormInstallPath, tbMoviestormUserDataPath.Text);

            newConfiguration.DuplicateDetectionFlag = AddonDupSet.ForcedDuplicateDetectionFlags;
            if(cbDupDetName.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.Name;
            if (cbDupDetPublisher.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.Publisher;
            if (cbDupDetRecompilable.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.RecompilableFlag;
            if (cbDupDetAssetCount.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.AssetCount;
            if (cbDupDetLastPublished.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.LastCompiled;
            if (cbDupDetMeshSize.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.MeshDataSize;
            if (cbDupDetFileCount.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.TotalFiles;
            if (cbDupDetFingerprint.Checked)
                newConfiguration.DuplicateDetectionFlag |= DuplicateDetectionFlag.Fingerprint;

            string errorText;
            if (!newConfiguration.Save(ApplicationConfiguration.ConfigurationFilePath, out errorText))
            {
                MessageBox.Show(errorText, "Error saving configuration");
                return;
            }

            ApplicationConfiguration = newConfiguration;
            this.DialogResult = DialogResult.OK;
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
        }


        // ---------------------------------------------------------------------------------------------------

        private void pbPathsDefaults_Click(object sender, EventArgs e)
        {
            string errorText;
            MoviestormPaths defaultMoviestormPaths = AddonPersistenceUtils.GetMoviestormPaths(out errorText);
            if (defaultMoviestormPaths == null)
            {
                MessageBox.Show(errorText, "Error determining Moviestorm folders", MessageBoxButtons.OK);
                return;
            }

            tbMoviestormInstallPath.Text = defaultMoviestormPaths.InstallationPath;
            tbMoviestormUserDataPath.Text = defaultMoviestormPaths.UserDataPath;
        }

        private void pbDupCriteriaDefault_Click(object sender, EventArgs e)
        {
            SetDupDetectionCriteriaCheckBoxes(AddonDupSet.DefaultDuplicateDetectionFlag);
        }


        // ----------------------------------------------------------------------------------------------------

        private void pbSelectInstallFolder_Click(object sender, EventArgs e)
        {
            string newFolder = GetNewFolder();
            if (newFolder != null)
                tbMoviestormInstallPath.Text = newFolder;
        }



        private void pbSelectUserDataFolder_Click(object sender, EventArgs e)
        {
            string newFolder = GetNewFolder();
            if (newFolder != null)
                tbMoviestormUserDataPath.Text = newFolder;
        }

        private string GetNewFolder()
        {
            return (folderBrowser.ShowDialog(this) == DialogResult.OK)
                ? folderBrowser.SelectedPath
                : null;
        }


    }
}
