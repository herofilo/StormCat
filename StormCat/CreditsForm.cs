using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSAddonLib.Util;

namespace MSAddonChecker
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreditsForm_Load(object sender, EventArgs e)
        {
            lblVersion.Text = $"Version: {Utils.GetExecutableVersion()}";
        }
    }
}
