using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StormCat.Misc;
using MSAddonLib.Persistence.AddonDB;

namespace StormCat
{
    public partial class AssetSearchResultForm : Form
    {

        private List<AssetSearchResultItem> _assets;

        public AssetSearchResultForm(List<AssetSearchResultItem> pAssets)
        {
            _assets = pAssets;
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
        }

        private void cmAssetTable_Opening(object sender, CancelEventArgs e)
        {
            cmiSaveToExcel.Enabled = (_assets != null) && (_assets.Count > 0);
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
    }
}
