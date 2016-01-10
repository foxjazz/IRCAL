using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;




namespace myIRC
{
   

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            iparse = new IRCParser();
            iparse.oNameCompleteEvent += new NameCompleteEvent(iparse_oNameCompleteEvent);
            iparse.oJoinEvent += new JoinEvent(iparse_JoinEvent);
            iparse.oNoticeEvent += new NoticeEvent(iparse_oNoticeEvent);
            iparse.oModeEvent += new ModeEvent(iparse_oModeEvent);
            iparse.oAuthEvent += new AuthEvent(iparse_oAuthEvent);
            iparse.oTopicEvent +=new TopicEvent(iparse_oTopicEvent);
            iparse.oForwardEvent += new ForwardEvent(iparse_oForwardEvent);
            iparse.oKickEvent += new KickEvent(iparse_oKickEvent);
            iparse.oPrivMsgEvent += new PrivMsgEvent(iparse_oPrivMsgEvent);
            
            place = 55;
            curstate = CurrentState.Instance;
            ChannelList = new Dictionary<string, ChanMessageList>();
            selectedChannel = "";
            
        }
        DataClass dc;
        private int Retention;
        private Color NameColor;
        private Color AlertColor;
        private Color NickColor;

        private void SetGeneralConfigs()
        {
            dc = DataClass.Instance;
            Retention = dc.GetRetention();
            NameColor = dc.GetNameColor();
            AlertColor = dc.GetAlertColor();
            NickColor = dc.GetNickColor();
            tbUser.Text = dc.GetName();
            tbNick.Text = dc.GetNick();
        }
        void iparse_oPrivMsgEvent(object sender, PrivMsgEventArgs e)
        {
            ChanMessageList cml;
            List<string> nll = dc.GetNickList();
            if (!nll.Contains(e.User.Nick.ToLower()))
                return; //Return when no accepted nicks are found. We don't want private messages from users we don't know.

            if (!ChannelList.TryGetValue("priv_=!" + e.User.Nick,out cml))
            {
                cml = new ChanMessageList();
                ChannelList.Add("priv_=!" + e.User.Nick, cml);
            }
            else
            {
                cml.AddPrivMsg(e);
                cml.LastUpdate = DateTime.Now;
                btnPrivMsg.Visible = true;
                
            }
            
            
        }
        
        void iparse_oKickEvent(object sender, KickEventArgs e)
        {
            TreeNode thisTN = null;
            ChanMessageList cml;
            if (e.KickedNick == tbNick.Text)
            {
                foreach (TreeNode tnn in tvChans.Nodes)
                {
                    if (tnn.Text == ircCore1.ServerName)
                        thisTN = tnn;
                }
                if (ChannelList.TryGetValue(e.From, out cml))
                {
                    cml.IsJoined = false;
                    cml.KickReason = e.KickerUser + " Kicked " + tbNick.Text + " -- " + e.Reason;
                }
                foreach (TreeNode tn2 in thisTN.Nodes)
                {
                    if (tn2.Text == e.From)
                    {
                        tn2.ForeColor = Color.LightGray;
                    }
                }
            }
        }

        void iparse_oForwardEvent(object sender, ForwardEventArgs e)
        {
            //Here we need to be careful because we are forwarding a channel that was supposedly joined.
            //so we need to remove the joined channel and modify it
            string source = StripPND( e.sourceChannel);
            string target = StripPND(e.targetChannel);

            if (!ChannelList.ContainsKey(source))
                return;
            if (ChannelList.ContainsKey(target)) //we only need to do this once.
                return;
            ChannelList.Remove(source);

            TreeNode thisTN = null;
            foreach (TreeNode tnn in tvChans.Nodes)
            {
                if (tnn.Text == ircCore1.ServerName)
                    thisTN = tnn;
            }
            TreeNode ttn = new TreeNode();
            ttn.Text = target;
            ChanMessageList cml = new ChanMessageList();
            ttn.Tag = cml;
            thisTN.Nodes.Add(ttn);
            ChannelList.Add(target, cml);

            foreach (TreeNode tn2 in thisTN.Nodes)
            {
                if (tn2.Text == source)
                {
                    tn2.Remove();
                }
            }
        }

        void  iparse_oTopicEvent(object sendere, TopicEventArgs e)
        {
            //First get channel from channellist.
            //then set the topic.
            place = 5;
            ChanMessageList cml;
            string scChannel = StripPND(e.Channel);

            if (!ChannelList.TryGetValue(scChannel, out cml))
            {
                cml = new ChanMessageList();
                ChannelList.Add(scChannel, cml);
            }
            if (e.Topic.Length == 0)
                cml.Topic = "Topic not set.";
            else
                cml.Topic = e.Topic;

            cml.TopicUser = e.User;
            if (selectedChannel == scChannel)
            {
                if (e.User != null)
                {
                    rtbTopic.Text = e.User.Nick + "\n";
                }
                rtbTopic.Clear();
                rtbTopic.AppendText(e.Topic);
             
            }


     	        //throw new NotImplementedException();
        }

        private void AddChannelList()
        {
           
            TreeNode thisTN = null;
            foreach (TreeNode tnn in tvChans.Nodes)
            {
                if (tnn.Text == ircCore1.ServerName)
                    thisTN = tnn;
            }
            if (thisTN == null)
                return;
            foreach (TreeNode chanNode in thisTN.Nodes)
            {
                ircCore1.SendRaw("JOIN #" + chanNode.Text);
                ChanMessageList cml = new ChanMessageList();
                cml.Channel = chanNode.Text;
                ChannelList.Add(chanNode.Text, cml);

            }
        }
        private void StartTransmitsAfterAuthentication()
        {
            Register();
            curstate.SetServerInUse(ircCore1.ServerName);
            try
            {
                //this means the server authenticated and ready to join channels. Good place to join favorites.
                StartupAndJoins.JoinFavorites(ircCore1, curstate.activeChannelList);

                TreeNode thisTN = null;
                foreach (TreeNode tnn in tvChans.Nodes)
                {
                    if (tnn.Text == ircCore1.ServerName)
                        thisTN = tnn;
                }
                thisTN.Nodes.Clear();


                TreeNode tnn2 = null;
                for (int i = 0; i < connectionNodes.Count; i++)
                {
                    tnn2 = connectionNodes[i];
                    if (tnn2.Text == ircCore1.ServerName)
                        break;
                }
                if (tnn2 == null)
                    return;
                foreach (KeyValuePair<string, ChanMessageList> chans in curstate.activeChannelList)
                {
                    TreeNode n = new TreeNode(chans.Key);
                    tnn2.Nodes.Add(n);
                    n.Tag = chans.Value;
                    //clbChannels.Items.Add(chans.Value.Channel);
                }
                AddChannelList();
                tnn2.ExpandAll();
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }

        }
     #region AuthenticationAfter
		   void iparse_oAuthEvent(object sender, AuthEventArgs e)
        {
            if (e.message.IndexOf("Found") >= 0)
            {
                StartTransmitsAfterAuthentication();
            }

        } 
	#endregion

        void iparse_oModeEvent(object sender, ModeEventArgs e)
        {
            if (e.User != null && e.User.Nick != tbNick.Text)  //this pertains to the client nick only
                return;
            ChanMessageList cml;
            if (ChannelList.TryGetValue(e.Channel, out cml))
            {

                cml.Modes = e.Mode;
            }
            if (selectedChannel == e.Channel)
                lblModes.Text = e.Mode;
           
        }
        private CurrentState curstate;
        void iparse_oNoticeEvent(object sender, NoticeEventArgs e)
        {
            
            if (e.Message.IndexOf("Found") >= 0)
            {
                StartTransmitsAfterAuthentication();
            }
            
        }
        const string retval = "\n";
        IRCParser iparse;
        List<Message> listMessage = new List<Message>();
        List<string> MessageQueue;
        List<TreeNode> connectionNodes;
        private void button1_Click(object sender, EventArgs e)
        {

            Message mm = new Message();
            listMessage.Add(mm);

            MessageQueue = new List<string>();
            mm.server = cbEntry.Text;
            curstate.SetServerInUse(mm.server);
            button1.Enabled = false;
            mm.LogFile = Application.UserAppDataPath + "\\myIRCLog_" + mm.server + ".log";
            this.ircCore1.RunWorkerAsync(mm);
            iparse.CORE = this.ircCore1;
            if (connectionNodes == null)
            {
                connectionNodes = new List<TreeNode>();
            }
            TreeNode ttn = new TreeNode(mm.server);
            if (!connectionNodes.Contains(ttn))
            {
                connectionNodes.Add(ttn);
                tvChans.Nodes.Add(ttn);
            }

            rtbTalk.Focus();
        }
        
        List<Message> mList;
        Message m;
        Notify oNotify;
        
        DataTable dtServers;
        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.ircCore1.ProgressChanged += new ProgressChangedEventHandler(icore_ProgressChanged);
            oNotify = new Notify();
            dc = DataClass.Instance;

            dtServers = dc.GetServerList();
            cbEntry.DataSource = dtServers;
            cbEntry.ValueMember = "servername";
            cbEntry.DisplayMember = "servername";
            lbChanUsers.DrawMode = DrawMode.OwnerDrawVariable;
            SetGeneralConfigs();
            
        }
        private void ScrollToBottom(RichTextBox rtb)
        {
            rtb.SelectionStart = rtb.Text.Length;
            rtb.SelectionLength = 0;
            rtb.ScrollToCaret();
            
        }
        string msg1;
        int index;
        int endlen;
        int place;
        int iSubStrStart, iSubStrEnd;
        
        #region OldCode
        private string MessagePart(int len, string mt)
        {
            if (index >= (mt.Length - 1))
                return "";

            place = 1;
            if ((index + len) >= mt.Length)
                return mt.Substring(index);
            else
            {
                place = 4;
                endlen = mt.Substring(index, len).LastIndexOf(" ");
                if (endlen <= 0)  //if there are no spaces in the line, then use the full length of the line.
                    endlen = len;
            }
            if ((index + endlen) >= (mt.Length - 1))
            {
                place = 2;
                msg1 = mt.Substring(index);
            }
            else
            {
                place = 3;
                msg1 = mt.Substring(index, endlen);
            }
            index += endlen;
            place = 5;
            return msg1;
        }
        string msg;
        string tempMessage;
        private void AppendText(PrivMsgEventArgs pme)
        {
            int suggestedLen;
            int textLen;
            int divisor = 1;
            tempMessage = pme.Message;  //save for debuggind and use it.
            Size size;
            size = TextRenderer.MeasureText(tempMessage, rtbBox.Font);
            textLen = size.Width;
            if (textLen > rtbBox.Width)
            {
                place = 54;
                divisor = textLen / rtbBox.Width;
                divisor++;
                suggestedLen = tempMessage.Length / divisor;
            }
            else
                suggestedLen = tempMessage.Length;

            if (tempMessage.Length > suggestedLen)
            {
                place = 4;
                index = 0;
                endlen = 0;

                for (int i = 0; i < divisor; i++)
                {
                    msg = MessagePart(suggestedLen + 1, tempMessage);
                    rtbBox.AppendText(msg + retval);
                    place = 6;
                    if (i == 0)
                        rtbTopic.AppendText(pme.From + ":" + pme.User.Nick + retval);
                    else
                        rtbTopic.AppendText(retval);

                }

            }
            else
            {
                rtbBox.AppendText(tempMessage + retval);
                rtbTopic.AppendText(pme.From + ":" + pme.User.Nick + retval);
            }
            rtbTopic.SelectAll();
            rtbTopic.SelectionAlignment = HorizontalAlignment.Right;

            ScrollToBottom(rtbTopic);
            ScrollToBottom(rtbBox);


        } 
        #endregion
        private void AppendText(PrivMsgEventArgs pme, bool wrap)
        {
            bool alert;
            alert = false;
            if (pme.Message.IndexOf(tbNick.Text) >= 0)
                alert = true;
            if (pme.Message.Length > 7 && pme.Message.Substring(1, 6) == "ACTION")
            {
                rtbBox.AppendText("*" + pme.User.Nick + " " + pme.Message.Substring(7) + "\n");
            }
            else
            {   
                iSubStrStart = rtbBox.Text.Length;
                rtbBox.AppendText("{" + pme.User.Nick + "} " + pme.Message + "\n");
                if (pme.User.Nick == tbNick.Text)
                {
                    iSubStrEnd = rtbBox.Text.Length;
                    rtbBox.Select(iSubStrStart, iSubStrEnd - iSubStrStart);
                    rtbBox.SelectionColor = NickColor;
                }
                else
                {
                    
                    iSubStrEnd = iSubStrStart + pme.User.Nick.Length + 2;
                    int lenthOfName = iSubStrEnd - iSubStrStart;
                    rtbBox.Select(iSubStrStart, lenthOfName);
                    rtbBox.SelectionColor = NameColor;
                    if (alert)
                    {
                        rtbBox.Select(iSubStrEnd, rtbBox.Text.Length - iSubStrEnd);
                        rtbBox.SelectionColor = AlertColor;
                    }
                }
                rtbBox.Select(rtbBox.Text.Length, 0);
                
            }
            place = 4;
        }


        #region SpecialEvents

        void iparse_JoinEvent(object sender, JoinEventArgs e)
        {
            ChanMessageList cml;
            place = 53;

            string scChannel = StripPND(e.Channel);
            if (!ChannelList.TryGetValue(scChannel, out cml))
            {
                cml = new ChanMessageList();
                ChannelList.Add(scChannel, cml);
            }
            cml.AddName(e);
            if (scChannel == selectedChannel)
            {
                lbChanUsers.Items.Clear();
                lbChanUsers.BeginUpdate();
                foreach (string s in cml.nicks)
                {
                    lbChanUsers.Items.Add(s);
                }
                lbChanUsers.EndUpdate();
            }


        }
        void iparse_oNameCompleteEvent(object sender, NameReplyEventArgs e)
        {

            ChanMessageList cml;
            place = 52;
            string scChannel = StripPND(e.Channel);
            if (!ChannelList.TryGetValue(scChannel, out cml))
            {
                cml = new ChanMessageList();
                ChannelList.Add(scChannel, cml);
            }
            cml.AddNames(e);
            if (scChannel == selectedChannel)
            {
                lbChanUsers.Items.Clear();
                lbChanUsers.BeginUpdate();
                foreach (string s in cml.nicks)
                {
                    lbChanUsers.Items.Add(s);
                }
                lbChanUsers.EndUpdate();
            }

        }
        private string StripPND(string s)
        {
            if (s[0] == '#')
                return s.Substring(1).ToLower();
            else
                return s.ToLower();
            
        }
        #endregion

        //*********************************************************************
        //*************** THIS IS WHERE MESSAGES HAPPEN
        SBMessage sbmc;
        //IrcalBot ibot;
        private void icore_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            place = -1;
            if (e.UserState is List<Message>)
                mList = (List<Message>)e.UserState;
            else
                return;
            place = -2;
            try
            {
                int icnt = mList.Count;
                if (sbmc == null)
                    sbmc = new SBMessage();
                //if (ibot == null)
                //    ibot = new IrcalBot(ircCore1);

                //ibot.pushmessage(mList);

                for (int i = 0; i < icnt; i++)
                {
                    place = 49;
                    m = (Message) mList[i];
                    place = 52;
                    //
                    //:foxjazz_!n=foxjazz@c-75-71-194-237.hsd1.co.comcast.net PRIVMSG #HamRadio :test
                    //sbmc.SendSBM(m.message);

                    if (m.message.Contains("PRIVMSG"))
                    {
                        place = 53;
                        iparse.MainParser(m.message);
                        PrivMsgEventArgs pme = iparse.pmargs;
                        PrivMsgEventArgs nPME = new PrivMsgEventArgs();
                        pme.Copy(ref nPME);
                         ChanMessageList cml;
                         place = 54;
                        string scChannel = StripPND(nPME.From);
                        sbmc.SendSBM(m.message,scChannel);
                        MessageQueue.Add(m.message);
                         if (!ChannelList.TryGetValue(scChannel, out cml))
                         {
                             cml = new ChanMessageList();
                             ChannelList.Add(nPME.From, cml);
                         }
                         if (ChannelList.TryGetValue(scChannel, out cml))
                         {
                             cml.AddPrivMsg(nPME);
                             
                             if (!cml.nicks.Contains(nPME.User.Nick))
                                 cml.nicks.Add(nPME.User.Nick);
                             //Only add text to window if channel is selected.
                             if (selectedChannel == scChannel.ToLower())
                             {
                                 AppendText(nPME, true);
                                 rtbTopic.SelectAll();
                                 rtbTopic.SelectionAlignment = HorizontalAlignment.Right;
                                 ScrollToBottom(rtbBox);
                             }
                             oNotify.CheckName(nPME.User.Nick);
                             oNotify.CheckChannel(ircCore1.ServerName, scChannel, nPME);
                             cml.LastUpdate = DateTime.Now;
                         }
                        place = 88;
                    }
                    else
                    {
                        iparse.MainParser(m.message);
                        if (!iparse.parsed)
                        {
                            string msg = m.message.Trim();
                            if (msg.Length > 0 )
                            {
                                if (msg.StartsWith("PING"))
                                    break;
                                rtbGeneral.AppendText(msg + retval);
                                rtbGeneral.Select(rtbGeneral.Text.Length, 0);
                            }
                        }
                        
                    }
                    //if (m.Direction == "parse")
                    //{
                    //    place = 71;
                    //    iparse.MainParser(m.message.Split(new char[] { ' ' }));

                    //}
                  
                        

                }
                place = 72;

                mList.RemoveRange(0, mList.Count);
                place = 73;
            }
            catch (Exception ex)
            {
                rtbGeneral.AppendText("ERROR:place" + place.ToString() +  ex.Message);
                    
              //  MessageBox.Show(ex.Message + " err: place = "+ place.ToString());
            }
           
            
        }
        public void Register()
        {
            ircCore1.SendRaw("NICK " + tbNick.Text + "\r\n");
            ircCore1.SendRaw("USER " + tbUser.Text + " 0 * :" + tbUser.Text + "\r\n");
        }
        string selectedChannel;
     

        private void btnViewPrivMessages_Click(object sender, EventArgs e)
        {
            
            frmPrivMessages frmPMs = new frmPrivMessages();
            frmPMs.FillpmList(ChannelList);
            frmPMs.ircCore1 = this.ircCore1;
            frmPMs.iparse = this.iparse;
            frmPMs.MyNick = tbNick.Text;
            frmPMs.Show();
        }

        Dictionary<string,ChanMessageList> ChannelList;
        private void btnJoinChans_Click(object sender, EventArgs e)
        {
            
            TreeNode thisTN = null;
            foreach (TreeNode tnn in tvChans.Nodes)
            {
                if (tnn.Text == ircCore1.ServerName)
                    thisTN = tnn;
            }

            foreach (TreeNode item in thisTN.Nodes)
            {
                ircCore1.SendRaw("JOIN #"  + item.Text);
                if (!ChannelList.ContainsKey(item.Text))
                {
                    ChanMessageList cml = new ChanMessageList();
                    cml.Channel = item.Text;
                    ChannelList.Add(item.Text, cml);
                }
            }
        }

    

        private void btnLeave_Click(object sender, EventArgs e)
        {
            

            TreeNode thisTN = null;
            foreach (TreeNode tnn in tvChans.Nodes)
            {
                if (tnn.Text == ircCore1.ServerName)
                    thisTN = tnn;
            }

            foreach (TreeNode item in thisTN.Nodes)
            {
                ircCore1.SendRaw("PART #" + item.Text);
                item.ForeColor = Color.LightGray;
                //ChanMessageList cml = new ChanMessageList();
                //cml.Channel = item;
                //ChannelList.Add(item,cml);
            }
        
        }

     

        private void serverListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddServerUtility fas = new frmAddServerUtility();
            fas.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dc.SetNick(tbNick.Text);
            dc.SetUser(tbUser.Text);
        }

        private void channelFavoritsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFavoriteChannels fas = new frmFavoriteChannels();
            fas.ShowDialog();
        }


        ChanMessageList currentCML;
        private void tvChans_AfterSelect(object sender, TreeViewEventArgs e)
        {

            place = 2;
            rtbBox.Clear();
            selectedChannel = e.Node.Text.ToLower();
            lblChannel.Text = selectedChannel;
            ChanMessageList cml;
            dc.curChannel = e.Node.Text;
            if (ChannelList != null && ChannelList.TryGetValue(e.Node.Text, out cml))
            {
                currentCML = cml;
                rtbBox.Clear();
                
                Application.DoEvents();
                rtbBox.SuspendLayout();
                if (cml.PrivMsgList.Count > 150)
                {
                    int idxToD;
                    idxToD = cml.PrivMsgList.Count - 150;
                    cml.PrivMsgList.RemoveRange(0, idxToD);
                }
                foreach (PrivMsgEventArgs pmea in cml.PrivMsgList)
                {
                    AppendText(pmea, true);
                }

                if (!cml.IsJoined)
                {
                    rtbBox.AppendText(retval + cml.KickReason + retval);
                }
                rtbTopic.SelectAll();
                rtbTopic.SelectionAlignment = HorizontalAlignment.Right;
                ScrollToBottom(rtbBox);
                rtbBox.ResumeLayout();
                rtbTopic.Clear();
                if (cml.TopicUser != null)
                {
                    rtbTopic.Text = cml.TopicUser.Nick + "\n";
                }
                rtbTopic.AppendText(cml.Topic);
                lblModes.Text = cml.Modes;
                if (cml.nicks != null)
                {
                    lbChanUsers.Items.Clear();
                    lbChanUsers.BeginUpdate();
                    //rtbChannUsers.Clear();
                    //rtbChannUsers.SuspendLayout();
                    foreach (string s in cml.nicks)
                    {
                        lbChanUsers.Items.Add(s);
                      //  rtbChannUsers.AppendText(s + retval);
                    }

                    lbChanUsers.EndUpdate();

                    //rtbChannUsers.ResumeLayout();
                    //rtbChannUsers.Refresh();
                }
            }
            rtbTalk.Focus();
        }

        private void nicksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigNameNotifications fcnn = new frmConfigNameNotifications();
            fcnn.ShowDialog();

        }

        private void rawLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRaw fr = new frmRaw(ircCore1);
            
            fr.Show();
        }
        private int lidx;
        private bool IsFirstWord;
        private string FindLastWord(string s)
        {
            lidx = s.LastIndexOf(" ");
            IsFirstWord = false;
            if (lidx == -1)
            {
                lidx = 0;
                IsFirstWord = true;
                return s;
            }
            if (lidx - 1 == s.Length)
                return "";
            else
                return s.Substring(lidx + 1);

        }
        private void rtbTalk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                rtbTalk.Text = LastSent;
                rtbTalk.Select(rtbTalk.Text.Length, 0);
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (rtbTalk.Text.Length > 1 )
                {
                    string name;
                    string test = FindLastWord(rtbTalk.Text);
                    foreach (string s in currentCML.nicks)
                    {
                        if (s.Length == 0)
                            continue;
                        if (s[0] == '@' || s[0] == '+')
                            name = s.Substring(1);
                        else
                            name = s;
                        if (name.ToLower().StartsWith(test))
                        {
                            rtbTalk.Text = rtbTalk.Text.Substring(0, lidx);
                            if (IsFirstWord)
                            {
                                rtbTalk.AppendText(name + ": ");
                            }
                            else
                                rtbTalk.AppendText(" " + name);
                            
                        }
                    }
                }
                e.SuppressKeyPress = true;
                
            }
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
                    nPME.SetData(rtbTalk.Text, uinfo, selectedChannel,  false);
                    ChanMessageList cml;
                    if (!ChannelList.TryGetValue(nPME.From, out cml))
                    {
                        cml = new ChanMessageList();
                        ChannelList.Add(nPME.From, cml);
                    }
                    cml.AddPrivMsg(nPME);
                    AppendText(nPME, true);
                    ircCore1.SendRaw("PRIVMSG #" + selectedChannel + " :" + rtbTalk.Text + "\r\n");
                    LastSent = rtbTalk.Text;
                }
                rtbTalk.Text = "";
                e.SuppressKeyPress = true;
            }
        }
        private string LastSent;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            ircCore1.SendRaw("QUIT \r\n");
        }

        private void btnJoinFavs_Click(object sender, EventArgs e)
        {
            StartupAndJoins.JoinFavorites(ircCore1, curstate.activeChannelList);
        }

        private void btnAddChanToFavorites_Click(object sender, EventArgs e)
        {

        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void rtbTopic_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void rtbBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void privateMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrivMsgConfig fpmc = new frmPrivMsgConfig();
            fpmc.ShowDialog();
        }

        private void generalConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigGeneral fcg = new frmConfigGeneral();
            fcg.ShowDialog();
            SetGeneralConfigs();
        }

        private void lbChanUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            Color c = Color.Black;
            if (this.lbChanUsers.Items[e.Index].ToString().IndexOf("@") >= 0)
                c = Color.Blue;
             if (this.lbChanUsers.Items[e.Index].ToString().IndexOf("+") >= 0)
                 c = Color.Maroon;
            if (c == Color.Black)
                e.Graphics.DrawString(this.lbChanUsers.Items[e.Index].ToString(), lbChanUsers.Font, new SolidBrush(c), e.Bounds);
            else
                e.Graphics.DrawString(this.lbChanUsers.Items[e.Index].ToString().Substring(1), lbChanUsers.Font, new SolidBrush(c), e.Bounds);


        }

   

        private void btnPrivMsg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                btnPrivMsg.Visible = false;
            }
        }
    }
}
