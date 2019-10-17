using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MSAddonLib.Persistence.AddonDB;
using MSAddonLib.Util;
using MSAddonLib.Util.Persistence;
using StormCat.Misc;
using StormCat.Persistence;

namespace StormCat
{
    public partial class CatalogueIndexOpsForm : Form
    {

        private static Regex _checkNamesRegex = new Regex("[-_A-Z0-9]*", RegexOptions.IgnoreCase);

        private CataloguesIndexOperation _operation = CataloguesIndexOperation.Null;

        private MoviestormPaths _moviestormPaths;

        // private CataloguesIndex _cataloguesIndex;

        private string _selectedCatalogueName;

        private ToolTip _formToolTip;

        public CataloguesIndex CataloguesIndex { get; private set; }

        public AddonPackageSet NewAddonPackageSet { get; private set; }

        public string NewAddonPackageSetName { get; private set; }


        // -----------------------------------------------------------------------------------------------


        public CatalogueIndexOpsForm(CataloguesIndexOperation pOperation, MoviestormPaths pMoviestormPaths, CataloguesIndex pCataloguesIndex, string pSelectedCatalogueName)
        {
            _operation = pOperation;
            _moviestormPaths = pMoviestormPaths;
            CataloguesIndex = pCataloguesIndex;
            _selectedCatalogueName = pSelectedCatalogueName;

            InitializeComponent();
        }

        private void CatalogueIndexOpsForm_Load(object sender, EventArgs e)
        {
            CatalogueInfo currentCatalogue;
            if (CataloguesIndex == null)
            {
                MessageBox.Show("ERROR: No Catalogue Index has been specified", "Error", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (_operation != CataloguesIndexOperation.NewCatalogue)
            {
                if (CataloguesIndex.GetIndexByName(_selectedCatalogueName) < 0)
                {
                    MessageBox.Show("ERROR: Current Catalogue not found in the index", "Error", MessageBoxButtons.OK);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
            }

            SetToolTips();
            ContextHelp.HelpNamespace = Globals.HelpFilename;
            ContextHelp.SetHelpNavigator(this, HelpNavigator.TopicId);

            switch (_operation)
            {
                case CataloguesIndexOperation.NewCatalogue:
                    Text = "Create New Catalogue";
                    lblCurrentCat.Visible = tbCurrentCat.Visible = false;
                    tbNewCat.Focus();
                    break;
                case CataloguesIndexOperation.RenameCatalogue:
                    Text = "Rename Selected Catalogue";
                    tbCurrentCat.Text = _selectedCatalogueName;
                    lblNewCat.Text = "New Name:";
                    tbDescription.ReadOnly = true;
                    currentCatalogue = CataloguesIndex.GetByName(_selectedCatalogueName);
                    tbDescription.Text = currentCatalogue.Description;
                    tbNewCat.Focus();
                    break;
                case CataloguesIndexOperation.EditDescription:
                    Text = "Edit Description of Selected Catalogue";
                    tbCurrentCat.Text = _selectedCatalogueName;
                    lblNewCat.Visible = tbNewCat.Visible = false;
                    tbDescription.ReadOnly = false;
                    _formToolTip.SetToolTip(tbDescription, "New description of the selected catalogue");
                    currentCatalogue = CataloguesIndex.GetByName(_selectedCatalogueName);
                    tbDescription.Text = currentCatalogue.Description;
                    tbDescription.Focus();
                    break;
                case CataloguesIndexOperation.CopyCatalogue:
                    Text = "Copy Current Catalogue";
                    tbCurrentCat.Text = _selectedCatalogueName;
                    lblNewCat.Text = "New Catalogue:";
                    _formToolTip.SetToolTip(tbNewCat, "Name of the new (copy) catalogue");
                    _formToolTip.SetToolTip(tbDescription, "Description of the new (copy) catalogue");
                    tbDescription.ReadOnly = false;
                    currentCatalogue = CataloguesIndex.GetByName(_selectedCatalogueName);
                    tbDescription.Text = currentCatalogue.Description;
                    tbNewCat.Focus();
                    break;
            }
        }

        private void SetToolTips()
        {
            _formToolTip = new ToolTip();
            _formToolTip.SetDefaults();

            _formToolTip.SetToolTip(tbCurrentCat, "Current name of the selected catalogue");
            _formToolTip.SetToolTip(tbNewCat, "New name for the selected catalogue");
            _formToolTip.SetToolTip(tbDescription, "Description of the catalogue");

            _formToolTip.SetToolTip(pbOk, "Save changes");
            _formToolTip.SetToolTip(pbCancel, "Cancel changes");

        }



        private void pbCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }



        private void pbOk_Click(object sender, EventArgs e)
        {
            bool operationOk = false;
            switch (_operation)
            {
                case CataloguesIndexOperation.NewCatalogue:
                    operationOk = NewCatalogue();
                    break;
                case CataloguesIndexOperation.RenameCatalogue:
                    operationOk = RenameCatalogue();
                    break;
                case CataloguesIndexOperation.EditDescription:
                    operationOk = EditCatalogueDescription();
                    break;
                case CataloguesIndexOperation.CopyCatalogue:
                    operationOk = CopyCatalogue();
                    break;
            }

            if (!operationOk)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }




        // ----------------------------------------------------------------------------------------------------------------------

        private bool NewCatalogue()
        {
            string newCatalogueName = CheckCatalogueName(tbNewCat.Text);
            if (newCatalogueName == null)
            {
                tbNewCat.Focus();
                return false;
            }

            if (CheckNameDuplicate(newCatalogueName))
            {
                tbNewCat.Focus();
                return false;
            }

            NewAddonPackageSet = new AddonPackageSet(_moviestormPaths, null, tbDescription.Text.Trim());

            string newCatalogueFilename = newCatalogueName + ".scat";
            string errorText;
            NewAddonPackageSet.Save(out errorText, newCatalogueFilename);

            CataloguesIndex.Update(newCatalogueName, tbDescription.Text, NewAddonPackageSet.Addons?.Count ?? 0, NewAddonPackageSet.LastUpdate, NewAddonPackageSet.CatalogueVersion);
            NewAddonPackageSetName = newCatalogueName;

            return true;
        }

        private bool RenameCatalogue()
        {
            string newCatalogueName = CheckCatalogueName(tbNewCat.Text);
            if (newCatalogueName == null)
            {
                tbNewCat.Focus();
                return false;
            }

            if (CheckNameDuplicate(newCatalogueName))
            {
                tbNewCat.Focus();
                return false;
            }


            try
            {
                string oldFilename = _selectedCatalogueName + ".scat";
                string newFilename = newCatalogueName + ".scat";
                File.Move(oldFilename, newFilename);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error renaming file", MessageBoxButtons.OK);
                tbNewCat.Focus();
                return false;
            }

            CataloguesIndex.Rename(_selectedCatalogueName, newCatalogueName);

            // NewAddonPackageSet = _selectedAddonPackageSet;
            NewAddonPackageSetName = newCatalogueName;

            return true;
        }


        private bool EditCatalogueDescription()
        {
            string newDescription = tbDescription.Text.Trim();

            CatalogueInfo selectedCatalogue = CataloguesIndex.GetByName(_selectedCatalogueName);

            string oldDescription = selectedCatalogue.Description?.Trim() ?? "";

            if (oldDescription == newDescription)
                return true;

            string errorText;

            AddonPackageSet selectedAddonPackageSet = AddonPackageSet.Load(out errorText, selectedCatalogue.FilePath);

            selectedAddonPackageSet.SetDescription(newDescription);

            if (!selectedAddonPackageSet.Save(out errorText, selectedCatalogue.FilePath))
            {
                MessageBox.Show(errorText, "Error saving updated catalogue", MessageBoxButtons.OK);
                tbDescription.Focus();
                return false;
            }

            CataloguesIndex.Update(_selectedCatalogueName, newDescription);

            NewAddonPackageSet = selectedAddonPackageSet;
            return true;
        }


        private bool CopyCatalogue()
        {
            string newCatalogueName = CheckCatalogueName(tbNewCat.Text);
            if (newCatalogueName == null)
            {
                tbNewCat.Focus();
                return false;
            }

            if (CheckNameDuplicate(newCatalogueName))
            {
                tbNewCat.Focus();
                return false;
            }

            CatalogueInfo selectedCatalogue = CataloguesIndex.GetByName(_selectedCatalogueName);

            string errorText;

            AddonPackageSet newPackageSet = AddonPackageSet.Load(out errorText, selectedCatalogue.FilePath);
            newPackageSet.SetDescription(tbDescription.Text.Trim());

            if (!newPackageSet.Save(out errorText, newCatalogueName + ".scat"))
            {
                MessageBox.Show(errorText, "Error saving copied catalogue", MessageBoxButtons.OK);
                return false;
            }

            CataloguesIndex.Update(newCatalogueName, tbDescription.Text.Trim(), newPackageSet.Addons?.Count ?? 0, newPackageSet.LastUpdate, newPackageSet.CatalogueVersion);

            NewAddonPackageSet = newPackageSet;
            NewAddonPackageSetName = newCatalogueName;
            return true;
        }


        // .....................................................................................


        private string CheckCatalogueName(string pName)
        {
            if (string.IsNullOrEmpty(pName?.Trim()))
            {
                MessageBox.Show("Invalid name: it can't be null", "Invalid catalogue name", MessageBoxButtons.OK);
                return null;
            }

            if (pName.IndexOfAny(":/\\.,;\"'+*? ".ToCharArray()) >= 0)
            {
                MessageBox.Show("Invalid name. It can't include blanks or any of these characters:\n :/\\.,;\"'+*?", "Invalid catalogue name", MessageBoxButtons.OK);
                return null;
            }

            return pName;
        }


        private bool CheckNameDuplicate(string pName)
        {
            int index = CataloguesIndex.GetIndexByName(pName);
            if (index < 0)
                return false;

            MessageBox.Show("There's already a catalogue with this name", "Name duplicated", MessageBoxButtons.OK);
            return true;
        }


    }
}
