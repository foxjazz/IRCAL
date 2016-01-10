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
    public partial class frmFavoriteChannels : Form
    {
        public frmFavoriteChannels()
        {
            InitializeComponent();
        }
        private DataClass dc;
        private SavedSet.ServerListDataTable dtServers;
        private Dictionary<string,ChanFav> listedfavs;
        private void frmFavoriteChannels_Load(object sender, EventArgs e)
        {
            dc = DataClass.Instance;
            dtServers = dc.GetServerList();
            cbIRCServers.DataSource = dtServers;
            cbIRCServers.ValueMember = "servername";
            cbIRCServers.DisplayMember = "servername";
            IsUpdating = false;
            RefreshListedFavorites();

        }
        private void RefreshListedFavorites()
        {
            lbFavs.Items.Clear();
            rtbFavs.Clear();

            listedfavs = dc.GetFavoriteList(cbIRCServers.Text);
            foreach (KeyValuePair<string, ChanFav> cf in listedfavs)
            {
                lbFavs.Items.Add(cf.Value.channel);
                rtbFavs.AppendText(cf.Value.channel + " notify in " + cf.Value.NotifyMinute + "\n");
            }

        }
        private void btnAddListFavs_Click(object sender, EventArgs e)
        {
            string[] list;
            list = rtbList.Text.Split('\n');
            dc.AddChannels(cbIRCServers.Text, list);
            RefreshListedFavorites();
        }

        private void btnRemLstFavs_Click(object sender, EventArgs e)
        {
            string[] list;
            list = rtbList.Text.Split('\n');
            dc.RemoveChannels(cbIRCServers.Text, list);

            rtbFavs.Clear();
            RefreshListedFavorites();
        }

        private void cbIRCServers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RefreshListedFavorites();
           
        }
        ChanFav ocf;
        string sel;
        bool IsUpdating;
        private void lbFavs_SelectedIndexChanged(object sender, EventArgs e)
        {
            sel = (string)lbFavs.SelectedItem;
            if (listedfavs.TryGetValue(sel, out ocf)) 
            {
                IsUpdating = true;
                if (ocf.Phonetic == null)
                {
                    ocf.Phonetic = "";
                    lblPhonetic.Text = "";
                }
                else
                    lblPhonetic.Text = ocf.Phonetic;
                if (ocf.NotifyMinute == 0)
                    ocf.NotifyMinute = 1000;
                nudNotifyMinute.Value = ocf.NotifyMinute;
            }
            else
            {
                lblPhonetic.Text = "notset";
                nudNotifyMinute.Value = 800;
            }
            IsUpdating = false;
        }

        private void frmFavoriteChannels_FormClosing(object sender, FormClosingEventArgs e)
        {
            dc.Save();
        }

        private void lblPhonetic_Validated(object sender, EventArgs e)
        {
            dc.UpdateChanFav(cbIRCServers.Text, sel, Convert.ToInt32(nudNotifyMinute.Value), lblPhonetic.Text);
        }

        private void nudNotifyMinute_ValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdating)
            {
                ocf.NotifyMinute = Convert.ToInt32(nudNotifyMinute.Value);
                ocf.Phonetic = lblPhonetic.Text;
                dc.UpdateChanFav(cbIRCServers.Text, sel, Convert.ToInt32(nudNotifyMinute.Value), lblPhonetic.Text);
                RefreshListedFavorites();
            }
           
        }
    }
}
