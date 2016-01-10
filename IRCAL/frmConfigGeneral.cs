using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myIRC
{
    public partial class frmConfigGeneral : Form
    {
        public frmConfigGeneral()
        {
            InitializeComponent();
        }
        DataClass dc;
        private void frmConfigGeneral_Load(object sender, EventArgs e)
        {
            dc = DataClass.Instance;
            pbSent.BackColor = dc.GetNickColor();
            pbNames.BackColor = dc.GetNameColor();
            pbAlert.BackColor = dc.GetAlertColor();
            tbNick.Text = dc.GetNick();
            tbName.Text = dc.GetName();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dc.SetNick(tbNick.Text);
            dc.SetUser(tbName.Text);
            dc.SetColors(pbSent.BackColor, pbNames.BackColor, pbAlert.BackColor);
            dc.Save();
        }

        private void pbNames_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pbNames.BackColor = colorDialog1.Color;
        }

        private void pbSent_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pbSent.BackColor = colorDialog1.Color;

        }
    }
}
