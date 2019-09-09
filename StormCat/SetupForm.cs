using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSAddonChecker.Configuration;
using MSAddonLib.Util;
using MSAddonLib.Util.Persistence;

namespace MSAddonChecker
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
            // cbPreserveOptions.Checked = _applicationConfiguration.PreserveOptions;

            SetToolTips();
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
