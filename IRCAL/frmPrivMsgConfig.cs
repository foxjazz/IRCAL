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
    public partial class frmPrivMsgConfig : Form
    {
        DataClass dc;
        public frmPrivMsgConfig()
        {
            InitializeComponent();
            dc = DataClass.Instance;
        }

        private void lbNicks_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNick.Text = (string)lbNicks.SelectedItem;
            RefreshList();
        }

        private void frmPrivMsgConfig_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            lbNicks.DataSource = dc.GetNickList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dc.AddNick( tbNick.Text);
            RefreshList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dc.RemoveNick(tbNick.Text);
            RefreshList();
        }
    }
}
