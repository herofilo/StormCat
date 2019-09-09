using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSAddonChecker.Domain;
using MSAddonChecker.Misc;
using MSAddonLib.Persistence.AddonDB;

namespace MSAddonChecker
{
    public partial class AddonContentForm : Form
    {
        private string _name;

        private List<AssetSearchResultItem> _assets;


        public AddonContentForm(string pName, List<AssetSearchResultItem> pAssets)
        {
            _name = pName;
            _assets = pAssets;
            InitializeComponent();
        }



        private void AddonContentForm_Load(object sender, EventArgs e)
        {
            this.Text = _name;

            int assetsFound = _assets?.Count ?? 0;
            lblSummary.Text = $"Assets found: {assetsFound}";
            dgvAssets.AutoGenerateColumns = false;
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
            string name = _name.Replace(".", "-");
            sfdExportExcel.FileName = $"{name}_Assets.xlsx";
            if (sfdExportExcel.ShowDialog(this) != DialogResult.OK)
                return;

            string file = sfdExportExcel.FileName;
            string errorText;
            ExcelExporter.ExcelExport(dgvAssets, file, "Assets", out errorText);
        }

    }
}
