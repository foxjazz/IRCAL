using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
namespace myIRC
{
    sealed class DataClass
    {

        private static DataClass instance;
        private SavedSet data;


        
        public static DataClass Instance
        {

            get
            {
                if (instance == null)
                {

                    instance = new DataClass();
                    if (instance.data == null)
                    {
                        instance.data = new SavedSet();
                        try
                        {
                            instance.data.ReadXml(Application.UserAppDataPath + "\\IRCAL.xml");
                        }
                        catch (Exception exx)
                        {

                            MessageBox.Show(exx.Message);
                        }
                        instance._NameNotificationList = new Dictionary<string, SavedSet.NameNotificationRow>();
                        instance._ListServers = new List<IRCserver>();
                        foreach (SavedSet.ServerListRow slistrow in instance.data.ServerList.Rows)
                        {
                            IRCserver ircs = new IRCserver(slistrow.servername, slistrow.port);
                            instance._ListServers.Add(ircs);
                        }
                        foreach(SavedSet.NameNotificationRow nnr in instance.data.NameNotification.Rows)
                        {
                            instance.NameNotificationList.Add(nnr.Nick,nnr);
                        }
                        instance.NickList = new List<string>();
                        foreach (SavedSet.PrivateNicksRow pnr in instance.data.PrivateNicks.Rows)
                        {
                            instance.NickList.Add(pnr.Nick);
                        }
                        instance.SetConfigRow();
                        

                    }


                }
                return instance;
            }
        }
        private string _CurChannel;
        public string curChannel
        {
            get { return _CurChannel; }
            set { _CurChannel = value; }
        }
        private string  curServer;
        public Dictionary<string,ChanFav> GetFavoriteList(string server)
        {
            if (_ChannelFavorites == null)
            {
                _ChannelFavorites = new Dictionary<string,ChanFav>();
            }
            _ChannelFavorites.Clear();
            curServer = server;
            SavedSet.ChannelFavoritesDataTable dtFavs = GetFavorites();
            DataView dv = new DataView(dtFavs);
            dv.RowFilter = "servername = '" + server + "'";
            
            foreach (DataRowView drv in dv)
            {
                ChanFav cf = new ChanFav();
                cf.channel = drv["channel"].ToString();
                if (drv["NotifyMinute"] != DBNull.Value)
                    cf.NotifyMinute = Convert.ToInt32(drv["NotifyMinute"]);
                if (drv["phonetic"] != DBNull.Value)
                    cf.Phonetic = drv["phonetic"].ToString();
                if (drv["last"] != DBNull.Value)
                    cf.Last = Convert.ToDateTime(drv["last"]);

                _ChannelFavorites.Add(cf.channel,cf);
            }
            return _ChannelFavorites;
        }
        public SavedSet.ChannelFavoritesDataTable GetFavorites()
        {
            return data.ChannelFavorites;
        }
        public SavedSet.ServerListDataTable GetServerList()
        {
            return data.ServerList;
        }

        private List<IRCserver> _ListServers;
        public List<IRCserver> listServers
        {
            get {  return _ListServers; }
        }
        private Dictionary<string,ChanFav> _ChannelFavorites;
        public Dictionary<string, ChanFav> ChannelFavorites
        {
            get { return _ChannelFavorites; }
            set { _ChannelFavorites = value; }
        }


        
        public void RemoveChannels(string server, string[] channellist)
        {
            if (_ChannelFavorites == null)
            {
                _ChannelFavorites = new Dictionary<string,ChanFav>();
            }
            _ChannelFavorites.Clear();

            SavedSet.ChannelFavoritesDataTable dtFavs = GetFavorites();
            DataView dv = new DataView(dtFavs);
            dv.RowFilter = "servername = '" + server + "'";

            foreach (DataRowView drv in dv)
            {
                ChanFav cf = new ChanFav();
                cf.channel = drv["channel"].ToString();
                _ChannelFavorites.Add(cf.channel,cf);
            }
            SavedSet.ChannelFavoritesRow cfr;
            foreach (string fav in channellist)
            {
                if (_ChannelFavorites.ContainsKey(fav))
                {
                    //Add favorite to list
                    _ChannelFavorites.Remove(fav);
                    for (int i = 0; i < data.ChannelFavorites.Count; i++)
                    {
                        cfr = data.ChannelFavorites[i];

                        if (cfr["Channel"] != DBNull.Value && cfr.Channel == fav)
                        {
                            data.ChannelFavorites.RemoveChannelFavoritesRow(cfr);
                        }
                        
                    }
                    
                }
            }

            data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");

        }
        public void AddChannels(string server, string[] channellist)
        {
            if (_ChannelFavorites == null)
            {
                _ChannelFavorites = new Dictionary<string,ChanFav>();
            }
            _ChannelFavorites.Clear();

            SavedSet.ChannelFavoritesDataTable dtFavs = GetFavorites();
            DataView dv = new DataView(dtFavs);
            dv.RowFilter = "servername = '" + server + "'";

            foreach (DataRowView drv in dv)
            {
                ChanFav cf= new ChanFav();
                cf.channel = drv["channel"].ToString();
                _ChannelFavorites.Add(cf.channel,cf);
            }
            foreach (string fav in channellist)
            {
                if (!_ChannelFavorites.ContainsKey(fav))
                {
                    //Add favorite to list
                    ChanFav cf = new ChanFav(fav);
                    _ChannelFavorites.Add(cf.channel,cf);
                    SavedSet.ChannelFavoritesRow cfr = dtFavs.NewChannelFavoritesRow();
                    cfr.Channel = fav;
                    cfr.servername = server;
                    dtFavs.AddChannelFavoritesRow(cfr);
                }
            }

            data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");
        }

        public void AddServers(IRCserver[] ss)
        {
            foreach (IRCserver s in ss)
            {
                if (!_ListServers.Contains(s))
                {
                    _ListServers.Add(s);

                    SavedSet.ServerListRow srow = data.ServerList.NewServerListRow();
                    srow.port = s.port;
                    srow.servername = s.servername;
                    data.ServerList.AddServerListRow(srow);
                }

            }
            data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");

        }
        public void AddServerNames(string[] snames)
        {
            foreach (string s in snames)
            {

                
                IRCserver ircs = new IRCserver(s, 6667);
                if (!_ListServers.Contains(ircs))
                {
                    _ListServers.Add(ircs);

                    SavedSet.ServerListRow srow = data.ServerList.NewServerListRow();
                    srow.port = 6667;
                    srow.servername = s;
                    data.ServerList.AddServerListRow(srow);
                }
               
            }
            data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");
        }
        public void AddServerName(string sname, int port)
        {
            IRCserver ircs = new IRCserver(sname, port);
            if (!_ListServers.Contains(ircs))
            {
                _ListServers.Add(ircs);

                SavedSet.ServerListRow srow = data.ServerList.NewServerListRow();
                srow.port = port;
                srow.servername = sname;
                data.ServerList.AddServerListRow(srow);
                data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");
            }
        }
        private Dictionary<string,SavedSet.TextNotificationsRow>  _TextNotificationsList;
        public Dictionary<string,SavedSet.TextNotificationsRow> TextNotificationsList
        {
            get { return _TextNotificationsList; }
            set { _TextNotificationsList = value; }
        }
        public void AddTextNotification(string text,  string wavfile)
        {
            if (_TextNotificationsList.ContainsKey(text))
                return;

            SavedSet.TextNotificationsRow nnr = data.TextNotifications.NewTextNotificationsRow();
            nnr.Text = text;
            nnr.WaveFile  = wavfile;
            _TextNotificationsList.Add(text, nnr);
            data.TextNotifications.AddTextNotificationsRow(nnr);
        }

        public void RemoveTextNofification(string text)
        {
            if (!_TextNotificationsList.ContainsKey(text))
                return;

            _TextNotificationsList.Remove(text);
            foreach (SavedSet.TextNotificationsRow nnr in data.TextNotifications)
            {
                if (nnr.Text == text)
                {
                    data.TextNotifications.RemoveTextNotificationsRow(nnr);
                }
            }

        }

        public void AddNameNotification(string nick, int threshold, string wavfile, string Phonetic)
        {
            if (_NameNotificationList.ContainsKey(nick))
                return;

            SavedSet.NameNotificationRow nnr = data.NameNotification.NewNameNotificationRow();
            nnr.Nick = nick;
            nnr.Phonetic = Phonetic;
            nnr.Threshold = threshold;
            nnr.WaveFile = wavfile;
            _NameNotificationList.Add(nick, nnr);

            data.NameNotification.AddNameNotificationRow(nnr);
            data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");

        }
        public void Save()
        {
            data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");
        }
        public void RemoveNameNotification(string nick)
        {
            if (!_NameNotificationList.ContainsKey(nick))
                return;

            _NameNotificationList.Remove(nick);

            SavedSet.NameNotificationRow nnr;
            for (int i = 0; i < data.NameNotification.Count; i++)
            {
                nnr = data.NameNotification[i];
                if (nnr.Nick == nick)
                {
                    data.NameNotification.RemoveNameNotificationRow(nnr);
                }

            }
            data.AcceptChanges();
            data.WriteXml(Application.UserAppDataPath + "\\IRCAL.xml");
        }

        private Dictionary<string,SavedSet.NameNotificationRow> _NameNotificationList;
        public Dictionary<string,SavedSet.NameNotificationRow> NameNotificationList
        {
            get { return _NameNotificationList; }
            set { _NameNotificationList = value; }
        }




        internal SavedSet.NameNotificationDataTable GetNameList()
        {
          return  data.NameNotification;
        }

        internal List<string> GetNickList()
        {
            return NickList;
            
        }
        private List<string> NickList;
        internal void AddNick(string nick)
        {
            string sNick = nick.ToLower();
            foreach (SavedSet.PrivateNicksRow pnr in data.PrivateNicks)
            {
                if (pnr.Nick == sNick)
                    return;
            }
            SavedSet.PrivateNicksRow nrow = data.PrivateNicks.NewPrivateNicksRow();
            nrow.Nick = sNick;
            data.PrivateNicks.AddPrivateNicksRow(nrow);
            NickList.Add(sNick);
            Save();

            
        }

        internal void RemoveNick(string p)
        {
            string sNick = p.ToLower();
            foreach (SavedSet.PrivateNicksRow pnr in data.PrivateNicks)
            {
                if (pnr.Nick == sNick)
                {
                    data.PrivateNicks.RemovePrivateNicksRow(pnr);
                    NickList.Remove(sNick);
                    Save();
                    return;
                }
            }
        }


        internal int GetRetention()
        {
            if (data.ConfigInfo.Count > 0)
            {
                SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
                return ci.LinesToKeep;
            }
            return 150;
        }

        internal System.Drawing.Color GetNameColor()
        {
            if (data.ConfigInfo.Count > 0)
            {
                SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
                return Color.FromArgb(ci.NameColor);
            }
            return Color.Blue;
        }

        internal System.Drawing.Color GetAlertColor()
        {
            if (data.ConfigInfo.Count > 0)
            {
                SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
                return Color.FromArgb(ci.AlertColor);
            }
            return Color.Red;
        }

        internal Color GetNickColor()
        {
            if (data.ConfigInfo.Count > 0)
            {
                SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
                return Color.FromArgb(ci.NickColor);
            }
            return Color.Maroon;
        
        }

        internal string GetNick()
        {
            if (data.ConfigInfo.Count > 0)
            {
                SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
                return ci.Nick;
            }
            return "NotSet";
        }

        internal string GetName()
        {
            if (data.ConfigInfo.Count > 0)
            {
                SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
                return ci.RealName;
            }
            return "NotSet";

        }

        private void SetConfigRow()
        {
            if (data.ConfigInfo.Rows.Count == 0)
            {
                SavedSet.ConfigInfoRow row = data.ConfigInfo.NewConfigInfoRow();
                row.NickColor = Color.Maroon.ToArgb();
                row.Nick = "NotSet";
                row.RealName = "NotSet";
                row.NameColor = Color.Blue.ToArgb();
                row.LinesToKeep = 150;
                row.AlertColor = Color.Red.ToArgb();
                data.ConfigInfo.AddConfigInfoRow(row);
                Save();
            }
        }
        internal void SetNick(string p)
        {
         
                SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
                ci.Nick = p;
            
            Save();
            

        }


        internal void SetUser(string p)
        {
           
            SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
            ci.RealName = p;
            Save();

        }

        internal void SetColors(Color nick, Color user, Color alert)
        {
            SavedSet.ConfigInfoRow ci = data.ConfigInfo[0];
            ci.NickColor = nick.ToArgb();
            ci.NameColor = user.ToArgb();
            ci.AlertColor = alert.ToArgb();
            Save();

        }
        internal void UpdateChanFavLast()
        {
            
            SavedSet.ChannelFavoritesDataTable dtFavs = GetFavorites();
            foreach (SavedSet.ChannelFavoritesRow cfr in dtFavs)
            {
                if (cfr["Channel"] == DBNull.Value)
                    continue;
                if (cfr.Channel == _CurChannel && cfr.servername == curServer)
                {
                    cfr.Last = DateTime.Now;
                    break;
                }
            }
            
        }
        internal void UpdateChanFav(string server, string chan, Int32 Notify, string Phonetic)
        {
        

            SavedSet.ChannelFavoritesDataTable dtFavs = GetFavorites();
            SavedSet.ChannelFavoritesRow cfr;
            for (int i = 0; i < dtFavs.Count; i++)
            {
                cfr = dtFavs[i];
                if (cfr["Channel"] == DBNull.Value)
                {
                    dtFavs.RemoveChannelFavoritesRow(cfr);
                    i--;
                    continue;
                }
                if (cfr.Channel == chan && cfr.servername == server)
                {
                    cfr.Phonetic = Phonetic;
                    cfr.NotifyMinute = Notify;
                    break;
                }
            }
            Save();
        }
    }
}
