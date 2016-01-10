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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            iparse = new IRCParser();

        }
        
        IRCParser iparse;
        List<Message> listMessage = new List<Message>();
        List<string> MessageQueue;
        private void button1_Click(object sender, EventArgs e)
        {
        
            
            listMessage.Add(new Message());
            
            MessageQueue = new List<string>();
            listMessage.Last().server = tbServer.Text;
            button1.Enabled = false;
            this.ircCore1.RunWorkerAsync(listMessage.Last());
            
            
        }
        
        List<Message> mList;
        Message m;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ircCore1.ProgressChanged += new ProgressChangedEventHandler(icore_ProgressChanged);    
        }
        private void icore_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            mList = (List<Message>)e.UserState;
            try
            {
                int icnt = mList.Count;
                for (int i = 0; i < icnt; i++)
                {
                    
                    m = (Message) mList[i];
                    
                    //MessageQueue.Add(m.message);

                    if (m.message.Contains("PRIVMSG"))
                    {
                        rtbBox.AppendText(m.message);
                    }
                    else
                    {
                        rtbGeneral.AppendText(m.message + "\r\n");
                    }


                    if (m.Direction == "pars")
                    {
                        iparse.MainParser(m.message.Split(new char[] { ' ' }));

                    }
                  //  if (m.Status == "done")
                        

                }
                mList.RemoveRange(0, icnt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }
        public void Register()
        {
            ircCore1.SendRaw("NICK " + Properties.Settings.Default.nick + "\r\n");
            ircCore1.SendRaw("USER " + Properties.Settings.Default.user + " 0 * :" + Properties.Settings.Default.user + "\r\n");
        }
        private void rtbTalk_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ircCore1.SendRaw(rtbTalk.Text + "\r\n");
                rtbTalk.Text = "";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register();
        }
    }
}
