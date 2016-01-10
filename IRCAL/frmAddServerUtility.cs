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
    public partial class frmAddServerUtility : Form
    {
        public frmAddServerUtility()
        {
            InitializeComponent();
        }
        private DataClass dc;
        private SavedSet.ServerListDataTable dtServers;
        private void frmAddServerUtility_Load(object sender, EventArgs e)
        {
            dc = DataClass.Instance;
            dtServers = dc.GetServerList();
            lbServers.DataSource = dtServers;
            lbServers.ValueMember = "servername";
            lbServers.DisplayMember = "servername";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] list;
            list = rtbList.Text.Split('\n');
            dc.AddServerNames(list);
        }
    }
}
