using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace StormCat
{
    public partial class AddonReportForm : Form
    {
        private string _name;

        private string _text;

        public AddonReportForm(string pAddonName, string pSummary)
        {
            _name = pAddonName;
            _text = pSummary;
            InitializeComponent();
        }

        private void AddonReportForm_Load(object sender, EventArgs e)
        {
            this.Text = _name;
            tbAddonSummary.Text = _text;

        }

        private void cmiCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                string textforClipboard = tbAddonSummary.Text.Replace(Environment.NewLine, "\n");
                Clipboard.Clear();
                Clipboard.SetText(textforClipboard);
                SystemSounds.Beep.Play();
            }
            catch { }
        }

        private void cmiWordwrapOutput_Click(object sender, EventArgs e)
        {
            tbAddonSummary.WordWrap = !tbAddonSummary.WordWrap;
        }

        private void cmiIncreaseFont_Click(object sender, EventArgs e)
        {
            try
            {
                float fontSize = tbAddonSummary.Font.Size + (float)1.0;
                tbAddonSummary.Font = new Font(tbAddonSummary.Font.FontFamily, fontSize);
            }
            catch { }
        }

        private void cmiDecreaseFont_Click(object sender, EventArgs e)
        {
            try
            {
                float fontSize = tbAddonSummary.Font.Size - (float)1.0;
                if (fontSize >= 6.0)
                    tbAddonSummary.Font = new Font(tbAddonSummary.Font.FontFamily, fontSize);
            }
            catch { }
        }
    }
}
