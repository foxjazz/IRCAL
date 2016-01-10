using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace myIRC
{
    public partial class frmConfigNameNotifications : Form
    {
        public frmConfigNameNotifications()
        {
            InitializeComponent();
            dc = DataClass.Instance;
            speaker = new SpeechSynthesizer();
            speaker.Rate = 1;
            speaker.Volume = 100;
        }
        DataClass dc;
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lblFile.Text = openFileDialog1.FileName;
        }
        SpeechSynthesizer speaker;
        private void frmConfigNameNotifications_Load(object sender, EventArgs e)
        {
            cbNameNotificationList.DataSource = dc.GetNameList();
            cbNameNotificationList.DisplayMember = "nick";
            cbNameNotificationList.ValueMember = "nick";
            RefreshList();
            
     


        }
        private void RefreshList()
        {
            rtbListedNotifications.Clear();
            foreach (KeyValuePair<string,SavedSet.NameNotificationRow> nnr in dc.NameNotificationList)
            {
                rtbListedNotifications.AppendText(nnr.Value.Nick + " -- " + nnr.Value.WaveFile + "\n");
            }

        }

        private void AddNick_Click(object sender, EventArgs e)
        {
            if (tbPhonetic.Text.Length == 0)
                tbPhonetic.Text = tbNick.Text;

            dc.AddNameNotification(tbNick.Text, Convert.ToInt32(nudThreshHold.Value), lblFile.Text,tbPhonetic.Text);
            RefreshList();

        }

        private void btnRemoveNick_Click(object sender, EventArgs e)
        {
            dc.RemoveNameNotification(cbNameNotificationList.SelectedValue.ToString());
            RefreshList();
        }

        private void SpeakIt_click(object sender, EventArgs e)
        {

            if (tbPhonetic.Text.Length == 0)
            {
                speaker.Speak(tbNick.Text);
            }
            else
                speaker.Speak(tbPhonetic.Text);
            
        }
    }
}
