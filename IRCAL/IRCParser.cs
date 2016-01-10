using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace myIRC
{
    public delegate void NameCompleteEvent(object sender, NameReplyEventArgs e);
    public delegate void JoinEvent(object sender, JoinEventArgs e);
    public delegate void QuitEvent(object sender, JoinEventArgs e);
    public delegate void NoticeEvent(object sender, NoticeEventArgs e);
    public delegate void ModeEvent(object sender, ModeEventArgs e);
    public delegate void AuthEvent(object sender, AuthEventArgs e);
    public delegate void TopicEvent(object sender, TopicEventArgs e);
    public delegate void ForwardEvent (object sender, ForwardEventArgs e);
    public delegate void KickEvent (object sender, KickEventArgs e);
    public delegate void PrivMsgEvent (object sender, PrivMsgEventArgs e);

    public partial class IRCParser : Component
    {
        public IRCParser()
        {
            InitializeComponent();
        }
        
        public event NameCompleteEvent oNameCompleteEvent;
        public event JoinEvent oJoinEvent;
        public event QuitEvent oQuitEvent;
        public event NoticeEvent oNoticeEvent;
        public event ModeEvent oModeEvent;
        public event AuthEvent oAuthEvent;
        public event TopicEvent oTopicEvent;
        public event ForwardEvent oForwardEvent;
        public event KickEvent oKickEvent;
        public event PrivMsgEvent oPrivMsgEvent;
        

        public IRCParser(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        
        }
        private IRCCore _CORE;
        public IRCCore CORE
        {
            get { return _CORE; }
            set { _CORE = value; }
        }
        private char[] arobas = new char[] { '@' };
        private char[] space = new char[] { ' ' };

        public void MainParser(string sss)
        {
            MainParser(sss.Split(' '));
        }
     
     
        public void MainParser(string[] args)
        {
            _Parsed = false;
            if (args.Length >= 2)
            {
                switch (args[1])
                {
                    case "001":
                        Handle001Message(args);
                        break;
                    case "002":
                    case "003":
                    case "004":
                    case "005":
                    case "251":
                    case "252":
                    case "253":
                    case "254":
                    case "255":
                    case "302":
                    case "303":
                    case "351":
                    case "366":
                    case "371":
                    case "372":
                    case "374":
                    case "375":
                    case "376":
                        HandleReplyMessage(args);
                        break;
                    case "401":
                    case "403":
                    case "404":
                    case "405":
                    case "406":
                    case "407":
                    case "409":
                    case "411":
                    case "412":
                    case "413":
                    case "414":
                    case "421":
                    case "422":
                    case "423":
                    case "424":
                    case "431":
                    case "432":
                    case "433":
                    case "436":
                    case "441":
                    case "442":
                    case "443":
                    case "444":
                    case "445":
                    case "446":
                    case "451":
                    case "461":
                    case "462":
                    case "463":
                    case "464":
                    case "465":
                    case "467":
                    case "471":
                    case "472":
                    case "473":
                    case "474":
                    case "475":
                    case "481":
                    case "482":
                    case "483":
                    case "491":
                    case "501":
                    case "502":
                        HandleErrorMessage(args);
                        break;

                    case "470":
                        cmd470(args);
                        break;
                    case "JOIN":
                        cmdJOIN(args);
                        break;
                    case "PRIVMSG":
                        cmdPRIVMSG(args);
                        break;
                    case "KICK":
                        cmdKICK(args);
                        break;
                    case "QUIT":
                        cmdQUIT(args);
                        break;
                    case "NOTICE":
                        cmdNOTICE(args);
                        break;
                    case "AUTH":
                        cmdAUTH(args);
                        break;
                    case "MODE":
                        cmdMODE(args);
                        break;
                    case "PART":
                        cmdPART(args);
                        break;
                    case "TOPIC":
                        cmdTOPIC(args);
                        break;
                    case "NICK":
                        cmdNICK(args);
                        break;
                    case "INVITE":
                        cmdINVITE(args);
                        break;
                    case "311":
                        cmd311(args);
                        break;
                    case "312":
                        cmd312(args);
                        break;
                    case "314":
                        cmd314(args);
                        break;
                    case "315":
                        cmd315(args);
                        break;
                    case "317":
                        cmd317(args);
                        break;
                    case "318":
                        cmd318(args);
                        break;
                    case "319":
                        cmd319(args);
                        break;
                    case "321":
                        cmd321(args);
                        break;
                    case "322":
                        cmd322(args);
                        break;
                    case "323":
                        cmd323(args);
                        break;
                    case "324":
                        cmd324(args);
                        break;
                    case "329":
                        cmd329(args);
                        break;
                    case "331":
                        cmd331(args);
                        break;
                    case "332":
                        cmd332(args);
                        break;
                    case "333":
                        cmd333(args);
                        break;
                    case "341":
                        cmd341(args);
                        break;
                    case "352":
                        cmd352(args);
                        break;
                    case "353":
                        cmd353(args);
                        break;
                    case "367":
                        cmd367(args);
                        break;
                    case "368":
                        cmd368(args);
                        break;
                    default:
                        break;
                }
            }
        }

        
        private void cmd368(string[] args)
        {
            
        }

        private void cmd367(string[] args)
        {
            
        }
        private bool _Parsed;
        public bool parsed
        {
            get { return _Parsed; }
            set { _Parsed = value; }
        }
        //ForwardEventArgs> :kubrick.freenode.net 470 foxjazz #csharp ##csharp :Forwarding to another channel
        private void cmd470(string[] args)
        {
            _Parsed = true;
            string names = UtilityService.JoinString(args, 5, args.Length).Trim(new char[] { ':' });
            
            string[] namelist = names.Split(' ');
            string channel = args[4];

            ForwardEventArgs e = new ForwardEventArgs(args[3], args[4]);
            // Sometimes, the 331 isn't sended by the server so we emit the channel joined event here
            //CORE.OnChannelJoinedReceived(channel);
            oForwardEvent(this, e);
        }

        private void cmd353(string[] args)
        {
            _Parsed = true;
            string names = UtilityService.JoinString(args, 5, args.Length).Trim(new char[] { ':' });

            string[] namelist = names.Split(' ');
            string channel = args[4];
            // Sometimes, the 331 isn't sended by the server so we emit the channel joined event here
            //CORE.OnChannelJoinedReceived(channel);
            CORE.SendRaw("MODE " + channel);
            CORE.SendRaw("TOPIC " + channel);
            NameReplyEventArgs e = new NameReplyEventArgs(channel, namelist);
            
            if (oNameCompleteEvent != null)
                oNameCompleteEvent(this, e);

            /////
          
            
        }

        private void cmd352(string[] args)
        {
            
        }

        private void cmd341(string[] args)
        {
            
        }

        private void cmd333(string[] args)
        {
            
        }

        private void cmd332(string[] args)
        {
            _Parsed = true;
            string topic = "";
            string channel = "";
            if (args[3].IndexOf("#") > -1 || args[3].IndexOf("&") > -1)
            {
                topic = UtilityService.JoinString(args, 4, args.Length).Trim(new char[] { ':' });
                channel = args[3];
            }
            else
            {
                topic = UtilityService.JoinString(args, 3, args.Length).Trim(new char[] { ':' });
                channel = args[2];
            }
            TopicEventArgs e = new TopicEventArgs(null, topic, channel);
            oTopicEvent(this, e);
            
        }

        private void cmd331(string[] args)
        {
            
        }

        private void cmd329(string[] args)
        {
            
        }

        private void cmd324(string[] args)
        {
            _Parsed = true;
            string channel = args[3];
            string mode = UtilityService.JoinString(args, 4, args.Length);
            ModeEventArgs e = new ModeEventArgs(null, mode, channel);
            oModeEvent(this, e);
        }

        private void cmd323(string[] args)
        {
            
        }

        private void cmd322(string[] args)
        {
            
        }

        private void cmd321(string[] args)
        {
            
        }

        private void cmd319(string[] args)
        {
            
        }

        private void cmd318(string[] args)
        {
            
        }

        private void cmd317(string[] args)
        {
            
        }

        private void cmd315(string[] args)
        {
            
        }

        private void cmd314(string[] args)
        {
            
        }

        private void cmd312(string[] args)
        {
            
        }

        private void cmd311(string[] args)
        {
            
        }

        private void cmdINVITE(string[] args)
        {
            
        }

        private void cmdNICK(string[] args)
        {
            
        }

        private void cmdTOPIC(string[] args)
        {
            _Parsed = true;
            string[] source = args[0].Split(new char[] { '!' });
            string nick = source[0].Replace(":", "");
            string realname = source[1].Split(arobas)[0];
            string hostname = source[1].Split(arobas)[1];
            UserInfo user = new UserInfo(nick, realname, hostname, false);
            string channel = args[2];
            string topic = UtilityService.JoinString(args, 3, args.Length).Remove(0, 1);
            TopicEventArgs e = new TopicEventArgs(user, topic, channel);
            oTopicEvent(this, e);
            
        }

        private void cmdPART(string[] args)
        {
            
        }

        private void cmdMODE(string[] args)
        {
            _Parsed = true;
            string[] source = args[0].Split(new char[] { '!' });
            string nick = source[0].Replace(":", "");
            string realname;
            string hostname;
            if (args[0].IndexOf("!") > -1)
            {
                realname = source[1].Split(arobas)[0];
                hostname = source[1].Split(arobas)[1];
            }
            else
            {
                hostname = null;
                realname = null;
            }
            string channel = args[2].Replace(":", "");
            string mode = UtilityService.JoinString(args, 3, args.Length);
            UserInfo user = new UserInfo(nick, realname, hostname, false);
            ModeEventArgs e = new ModeEventArgs(user, mode, channel);
            if (oModeEvent != null)
                oModeEvent(this, e);

        }
        private void cmdAUTH(string[] args)
        {
            _Parsed = true;
            string message = UtilityService.JoinString(args, 3, args.Length);
            AuthEventArgs e = new AuthEventArgs( message);
            if (oAuthEvent != null)
                oAuthEvent(this, e);

        }
        private void cmdNOTICE(string[] args)
        {
            _Parsed = true;
            string[] source = args[0].Split(new char[] { '!' });
            string nick = source[0].Replace(":", "");
            string realname;
            string hostname;
            if (args[0].IndexOf("!") > -1)
            {
                realname = source[1].Split(arobas)[0];
                hostname = source[1].Split(arobas)[1];
            }
            else
            {
                hostname = null;
                realname = null;
            }
            UserInfo user = new UserInfo(nick, realname, hostname, false);
            string channel = args[2];
            if (channel.StartsWith("@"))
                channel = channel.Remove(0, 1);
            string message = UtilityService.JoinString(args, 3, args.Length).Remove(0, 1);
            if (message.StartsWith(UtilityService.CTCPMarker))
            {
                CTCPReplyEventArgs e_ctcp;
                string reply = message.Replace(UtilityService.CTCPMarker, "");
                string ctcptype = (reply.Split(new char[] { ' ' }))[0];
                reply = reply.Replace(ctcptype, "");
                if (ctcptype.ToUpper() == "PING")
                {
                    DateTime now = DateTime.Now;
                    DateTime ping = UtilityService.ConvertCtimeToDateTime(reply);
                    TimeSpan difference = now - ping;
                    reply = Convert.ToInt32(difference.TotalSeconds).ToString() + " second(s)";
                   
                }
                e_ctcp = new CTCPReplyEventArgs(user, ctcptype, reply);
                //connection.OnCTCPReplyEventReceived(e_ctcp);
            }
            else
            {
                NoticeEventArgs e = new NoticeEventArgs(user, message, channel);
                if (oNoticeEvent != null)
                    oNoticeEvent(this, e);

               // connection.OnNoticeEventReceived(e);
            }
        }

        private void cmdQUIT(string[] args)
        {

            string[] source = args[0].Split(new char[] { '!' });
            string nick = source[0].Replace(":", "");
            string realname = source[1].Split(arobas)[0];
            string hostname = source[1].Split(arobas)[1];
            UserInfo user = new UserInfo(nick, realname, hostname, false);
            string reason = UtilityService.JoinString(args, 2, args.Length).Trim(new char[] { ':' });

            JoinEventArgs e = new JoinEventArgs("", user,reason);
            if (oQuitEvent != null)
                oQuitEvent(this, e);
            //connection.OnQuitCommandReceived(user, reason);
        }
        //>> :kubrick.freenode.net 470 foxjazz #csharp ##csharp :Forwarding to another channel
        private void cmdKICK(string[] args)
        {
            string[] source = args[0].Split(new char[] { '!' });
            string nick = source[0].Replace(":", "");
            string realname = source[1].Split(arobas)[0];
            string hostname = source[1].Split(arobas)[1];
            UserInfo user = new UserInfo(nick, realname, hostname, false);
            string channel = args[2].Replace(":", "");
            string kickednick = args[3];
            string reason = UtilityService.JoinString(args, 4, args.Length).Trim(new char[] { ':' });
            KickEventArgs e;
            //bool isyou = false;
            //if (kickednick == connection.UserInformation.Nick)
            //{
            //    isyou = true;
            //}
            e = new KickEventArgs(kickednick, user, reason, channel);
            oKickEvent(this, e);
        }

        private void cmdPRIVMSG(string[] args)
        {
            _Parsed = true;
            string[] source = args[0].Split(new char[] { '!' });
            string nick = source[0].Replace(":", "");
            string realname = source[1].Split(arobas)[0];
            string hostname = source[1].Split(arobas)[1];
            UserInfo user = new UserInfo(nick, realname, hostname, false);
            string channel = args[2];
            string message = UtilityService.JoinString(args, 3, args.Length).Remove(0, 1);
            PrivMsgEventArgs e;
         
                if (channel.StartsWith("#") == false)
                {
                    e = new PrivMsgEventArgs(user, message, nick, false);
                }
                else
                {
                    e = new PrivMsgEventArgs(user, message, channel, true);
                }
                _Pmargs = e;
                oPrivMsgEvent(this, e);
        }

        private PrivMsgEventArgs _Pmargs;
        public PrivMsgEventArgs pmargs
        {
            get { return _Pmargs; }
            set { _Pmargs = value; }
        }
        private void cmdJOIN(string[] args)
        {
            _Parsed = true;
            string[] source = args[0].Split(new char[] { '!' });
            string nick = source[0].Replace(":", "");
            string realname = source[1].Split(arobas)[0];
            string hostname = source[1].Split(arobas)[1];
            UserInfo user = new UserInfo(nick, realname, hostname, false);
            string channel = args[2].Replace(":", "");
            JoinEventArgs e = new JoinEventArgs(channel, user);
            if (oJoinEvent != null)
                oJoinEvent(this, e);
        }

        private void HandleErrorMessage(string[] args)
        {
            
        }

        private void HandleReplyMessage(string[] args)
        {
            
        }

        private void Handle001Message(string[] args)
        {
            
        }
    }
}
