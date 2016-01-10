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
    public partial class frmPrivMessages : Form
    {
        public frmPrivMessages()
        {
            InitializeComponent();
            
        }
        public IRCCore ircCore1;
        public IRCParser iparse;
        private void frmPrivMessages_Load(object sender, EventArgs e)
        {
            foreach(KeyValuePair<string,ChanMessageList> cml in pmList)
            {
                lbPrivates.Items.Add(cml.Key.Substring(7));
            }
            dc = DataClass.Instance;
            iparse.oPrivMsgEvent += new PrivMsgEvent(iparse_oPrivMsgEvent);
            NameColor = Color.Blue;
            AlertColor = Color.Red;
            NickColor = Color.Maroon;

        }

        void iparse_oPrivMsgEvent(object sender, PrivMsgEventArgs e)
        {
            AppendText(e,true);
        }
        int iSubStrStart, iSubStrEnd;
        private Color NameColor;
        private Color AlertColor;
        private Color NickColor;
        public string MyNick;
        private void AppendText(PrivMsgEventArgs pme, bool wrap)
        {
            bool alert;
            alert = false;
            if (pme.Message.IndexOf(MyNick) >= 0)
                alert = true;
            if (pme.Message.Length > 7 && pme.Message.Substring(1, 6) == "ACTION")
            {
                rtbMsg.AppendText("*" + pme.User.Nick + " " + pme.Message.Substring(7) + "\n");
            }
            else
            {
                iSubStrStart = rtbMsg.Text.Length;
                rtbMsg.AppendText("{" + pme.User.Nick + "} " + pme.Message + "\n");
                if (pme.User.Nick == MyNick)
                {
                    iSubStrEnd = rtbMsg.Text.Length;
                    rtbMsg.Select(iSubStrStart, iSubStrEnd - iSubStrStart);
                    rtbMsg.SelectionColor = NickColor;
                }
                else
                {

                    iSubStrEnd = iSubStrStart + pme.User.Nick.Length + 2;
                    int lenthOfName = iSubStrEnd - iSubStrStart;
                    rtbMsg.Select(iSubStrStart, lenthOfName);
                    rtbMsg.SelectionColor = NameColor;
                    if (alert)
                    {
                        rtbMsg.Select(iSubStrEnd, rtbMsg.Text.Length - iSubStrEnd);
                        rtbMsg.SelectionColor = AlertColor;
                    }
                }
                rtbMsg.Select(rtbMsg.Text.Length, 0);

            }
            
        }

        DataClass dc;
        public void FillpmList(Dictionary<string, ChanMessageList> lst)
        {
            if (pmList == null)
                pmList = new Dictionary<string, ChanMessageList>();
            pmList.Clear();
            foreach (KeyValuePair<string, ChanMessageList> cml in lst)
            {
                if (cml.Key.StartsWith("priv_=!"))
                {
                    pmList.Add(cml.Key,cml.Value);
                }
            }
        }
        private Dictionary<string,ChanMessageList> _PmList;
        public Dictionary<string,ChanMessageList> pmList
        {
            get { return _PmList; }
            set { _PmList = value; }
        }

        private void lbPrivates_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChanMessageList cml;
            rtbMsg.Clear();
            rtbMsg.SuspendLayout();
            string priv = (string)lbPrivates.SelectedItem;
            priv = "priv_=!" + priv;
            if (_PmList.TryGetValue(priv, out cml))
            {
                foreach (PrivMsgEventArgs msg in cml.PrivMsgList)
                {
                    rtbMsg.AppendText(cml.LastUpdate.ToShortTimeString());
                    rtbMsg.AppendText(" : ");
                    rtbMsg.AppendText(msg.Message + "\n");
                }
            }
            rtbMsg.ResumeLayout();
            ScrollToBottom(rtbMsg);

        }
        private void ScrollToBottom(RichTextBox rtb)
        {
            rtb.SelectionStart = rtb.Text.Length;
            rtb.SelectionLength = 0;
            rtb.ScrollToCaret();

        }

        private void rtbTalk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //privmsg #channel :messagePart

                if (rtbTalk.Text.StartsWith("/"))
                {
                    ircCore1.SendRaw(rtbTalk.Text.Substring(1));
                }
                else if (rtbTalk.Text.Length > 0)
                {
                    PrivMsgEventArgs nPME = new PrivMsgEventArgs();
                    UserInfo uinfo = new UserInfo();
                    uinfo.RealName = dc.GetName();
                    uinfo.Nick = dc.GetNick();

                    rtbTalk.Text = rtbTalk.Text.Replace("\n", "");
                    rtbMsg.AppendText(rtbTalk.Text + "\n");
                    
                    string nic = (string)lbPrivates.SelectedItem;
                    ircCore1.SendRaw("PRIVMSG #" + nic + " :" + rtbTalk.Text + "\r\n");
                    
                }
                rtbTalk.Text = "";
                e.SuppressKeyPress = true;
            }
        }
    }
}
