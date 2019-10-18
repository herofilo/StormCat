using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSAddonLib.Persistence.AddonDB;
using StormCat.Domain;
using StormCat.Misc;

namespace StormCat
{
    public partial class CatalogueComparisonForm : Form
    {

        private string _catalogueName0;

        private string _catalogueName1;

        private List<CatalogueContentComparisionItem> _comparisionFull;

        private List<CatalogueContentComparisionItem> _comparisionDelta;



        public CatalogueComparisonForm(string pName0, string pName1, List<CatalogueContentComparisionItem> pComparision)
        {
            InitializeComponent();
            _catalogueName0 = pName0;
            _catalogueName1 = pName1;
            _comparisionFull = pComparision;
        }

        private void CatalogueComparisonForm_Load(object sender, EventArgs e)
        {
            _comparisionDelta = new List<CatalogueContentComparisionItem>();
            foreach (CatalogueContentComparisionItem item in _comparisionFull)
                if ((item.AddonCatalogue0 == null) || (item.AddonCatalogue1 == null))
                    _comparisionDelta.Add(item);

            ContextHelp.HelpNamespace = Globals.HelpFilename;
            ContextHelp.SetHelpNavigator(this, HelpNavigator.TopicId);

            DisplayData(true);
        }

        private void DisplayData(bool pFull)
        {
            dgvComparison.Columns[0].HeaderText = _catalogueName0;
            dgvComparison.Columns[1].HeaderText = _catalogueName1;
            dgvComparison.AutoGenerateColumns = false;

            BindingSource source = null;

            var bindingList = new SortableBindingList<CatalogueContentComparisionItem>(pFull ? _comparisionFull : _comparisionDelta);
            source = new BindingSource(bindingList, null);


            dgvComparison.DataSource = source;
        }

        private void cbOnlyDelta_CheckedChanged(object sender, EventArgs e)
        {
            DisplayData(!cbOnlyDelta.Checked);
        }

        private void pbSaveExcel_Click(object sender, EventArgs e)
        {
            SaveToExcel();
        }

        private void SaveToExcel()
        {

            if (sfdExportExcel.ShowDialog(this) != DialogResult.OK)
                return;

            string file = sfdExportExcel.FileName;
            string errorText;
            if (!ExcelExporter.ExcelExport(dgvComparison, file, "Comparison", out errorText))
                MessageBox.Show($@"An error has happened while trying to export to Excel:\n{errorText}",
                    @"Exportation error", MessageBoxButtons.OK);
        }

    }
}
