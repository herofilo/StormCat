using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSAddonLib.Domain.Addon;
using MSAddonLib.Persistence.AddonDB;
using StormCat.Misc;

namespace StormCat
{
    public partial class CompareByFingerprintForm : Form
    {
        private List<AddonPackage> _addons;

        private AddonPackageSet _addonPackageSet;

        // --------------------------------------------------------------------------------------------------------------------

        public CompareByFingerprintForm(List<AddonPackage> pAddons, AddonPackageSet pAddonPackageSet)
        {
            _addons = pAddons;
            _addonPackageSet = pAddonPackageSet;
            InitializeComponent();
        }

        private void CompareByFingerprintForm_Load(object sender, EventArgs e)
        {
            ContextHelp.HelpNamespace = Globals.HelpFilename;
            ContextHelp.SetHelpNavigator(this, HelpNavigator.TopicId);

            DisplayData();
        }

        private void DisplayData()
        {
            dgvComparison.AutoGenerateColumns = false;

            BindingSource source = null;

            var bindingList = new SortableBindingList<AddonPackage>(_addons);
            source = new BindingSource(bindingList, null);

            dgvComparison.DataSource = source;
        }


        private void cmiDisplayAddonReport_Click(object sender, EventArgs e)
        {
            AddonPackage addon = GetSelectedAddon();
            if (addon == null)
                return;

            AddonReportForm reportForm = new AddonReportForm(addon.QualifiedName, addon.ToString());
            reportForm.Show(this);
        }



        private void cmiListAddonContents_Click(object sender, EventArgs e)
        {
            ListAddonContents();
        }


        private void dgvComparison_DoubleClick(object sender, EventArgs e)
        {
            ListAddonContents();
        }


        private void ListAddonContents()
        {
            AddonPackage addon = GetSelectedAddon();
            if (addon != null)
                ShowAddonContents(addon);
        }



        private AddonPackage GetSelectedAddon()
        {
            if ((_addons == null) || (_addons.Count == 0))
                return null;

            string location = (string)dgvComparison.SelectedRows[0].Cells["colLocation"].Value;
            foreach (AddonPackage addon in _addons)
                if (addon.Location == location)
                    return addon;

            return null;
        }


        private void ShowAddonContents(AddonPackage pAddon)
        {
            List<AssetSearchResultItem> assets = _addonPackageSet.SearchAsset(new List<AddonPackage>() { pAddon }, null);

            AddonContentForm contentForm = new AddonContentForm($"{pAddon.Publisher}.{pAddon.Name}", assets);
            contentForm.Show(this);
        }

        private void cmiOpenContainingFolder_Click(object sender, EventArgs e)
        {
            AddonPackage addon = GetSelectedAddon();
            if (addon == null)
                return;

            string errorText;
            if (!MiscUtils.OpenContainingFolder(addon, out errorText))
            {
                if (!string.IsNullOrEmpty(errorText))
                    MessageBox.Show(errorText, "Error while opening folder", MessageBoxButtons.OK);
            }

        }
    }
}
