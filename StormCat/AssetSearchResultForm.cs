using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSAddonLib.Domain.Addon;
using StormCat.Misc;
using MSAddonLib.Persistence.AddonDB;

namespace StormCat
{
    public partial class AssetSearchResultForm : Form
    {

        private List<AssetSearchResultItem> _assets;

        private AddonPackageSet _addonPackageSet;

        private bool _listAlwaysAnimations;

        public AssetSearchResultForm(List<AssetSearchResultItem> pAssets, AddonPackageSet pAddonPackageSet, bool pListAlwaysAnimations)
        {
            _assets = pAssets;
            _addonPackageSet = pAddonPackageSet;
            _listAlwaysAnimations = pListAlwaysAnimations;
            InitializeComponent();
        }


        private void AssetSearchResultForm_Load(object sender, EventArgs e)
        {

            dgvAssets.AutoGenerateColumns = false;
            int assetsFound = _assets?.Count ?? 0;
            lblSummary.Text = $"Assets found: {assetsFound}";

            BindingSource source = null;
            if (assetsFound > 0)
            {
                var bindingList = new SortableBindingList<AssetSearchResultItem>(_assets);
                source = new BindingSource(bindingList, null);
            }

            dgvAssets.DataSource = source;
            ContextHelp.HelpNamespace = Globals.HelpFilename;
            ContextHelp.SetHelpNavigator(this, HelpNavigator.TopicId);
        }

        private void cmAssetTable_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (_assets == null) || (_assets.Count == 0);
        }


        private void cmiSaveToExcel_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void pbSaveToExcel_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void SaveToExcel()
        {

            if (sfdExportExcel.ShowDialog(this) != DialogResult.OK)
                return;

            string file = sfdExportExcel.FileName;
            string errorText;
            if(!ExcelExporter.ExcelExport(dgvAssets, file, "Assets", out errorText))
                MessageBox.Show($@"An error has happened while trying to export to Excel:\n{errorText}",
                    @"Exportation error", MessageBoxButtons.OK);
        }

        // ------------------------------------------------------------------------------------------------------------------------------

        private void cmiDisplayAddonReport_Click(object sender, EventArgs e)
        {
            if (GetAssetSelectedRowIndex() < 0)
                return;

            string publisher;
            string name = GetSelectedAddonNamePublisher(out publisher);

            AddonPackage package = _addonPackageSet.FindByName(name, publisher);
            if (package == null)
                return;

            AddonReportForm reportForm = new AddonReportForm(name, package.ToString());
            reportForm.Show(this);
        }


        private void cmiListAddonContents_Click(object sender, EventArgs e)
        {
            ListAddonContents();
        }


        private void dgvAssets_DoubleClick(object sender, EventArgs e)
        {
            ListAddonContents();
        }

        private void ListAddonContents()
        {
            if (GetAssetSelectedRowIndex() < 0)
                return;
            ShowAddonContents();
        }


        private int GetAssetSelectedRowIndex()
        {
            if ((_assets == null) || (_assets.Count == 0))
                return -1;

            int rowIndex = dgvAssets.CurrentCell.RowIndex;
            return (rowIndex < 0) ? -1 : rowIndex;
        }



        private void ShowAddonContents()
        {
            string publisher;
            string name = GetSelectedAddonNamePublisher(out publisher);

            AddonPackage package = _addonPackageSet.FindByName(name, publisher);
            if (package == null)
                return;


            AssetSearchCriteria criteria = null;
            if (!_listAlwaysAnimations && (package.AssetSummary.Verbs > 0))
            {
                AddonAssetType types = AddonAssetType.Any ^ AddonAssetType.Animation;
                criteria = new AssetSearchCriteria(null, types, null, null, null);
            }

            List<AssetSearchResultItem> assets = _addonPackageSet.SearchAsset(new List<AddonPackage>() { package }, criteria);

            AddonContentForm contentForm = new AddonContentForm($"{publisher}.{name}", assets);
            contentForm.Show(this);
        }


        private string GetSelectedAddonNamePublisher(out string pPublisher)
        {
            pPublisher = (string)dgvAssets.SelectedRows[0].Cells["colAddonPublisher"].Value;
            return (string)dgvAssets.SelectedRows[0].Cells["colAddonName"].Value;
        }



        // ------------------------------------------------------------------------------------------------------------------------------



    }
}
