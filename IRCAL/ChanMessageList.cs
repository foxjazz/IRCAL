using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    public class ChanMessageList
    {
        public List<PrivMsgEventArgs> PrivMsgList;
        public ChanMessageList()
        {
            PrivMsgList = new List<PrivMsgEventArgs>();
            _LineLimit = 10000;
            _Topic = "";
            IsJoined = true;
        }
        private string _KickReason;
        public string KickReason
        {
            get { return _KickReason; }
            set { _KickReason = value; }
        }
        private string _Channel;
        public string Channel
        {
            get { return _Channel; }
            set { _Channel = value; }
        }
        private DateTime  _LastUpdate;
        public DateTime  LastUpdate
        {
            get { return _LastUpdate; }
            set { _LastUpdate = value; }
        }
        private UserInfo _TopicUser;
        public UserInfo TopicUser
        {
            get { return _TopicUser; }
            set { _TopicUser = value; }
        }
        private string _Topic;
        public string Topic
        {
            get { return _Topic; }
            set { _Topic = value; }
        }
        public void AddPrivMsg(PrivMsgEventArgs pmea)
        {
            PrivMsgList.Add(pmea);
        }

        private int _LineLimit;
        public int LineLimit
        {
            get { return _LineLimit; }
            set { _LineLimit = value; }
        }

        private List<string> _Nicks;
        public List<string> nicks
        {
            get { return _Nicks; }
            set { _Nicks = value; }
        }
        private string _Modes;
        public string Modes
        {
            get { return _Modes; }
            set { _Modes = value; }
        }
        internal void AddName(JoinEventArgs e)
        {
            if (_Nicks == null)
            {
                _Nicks = new List<string>();
            }
            if (!_Nicks.Contains(e.JoinedUser.Nick))
                _Nicks.Add(e.JoinedUser.Nick);
        }
        internal void AddNames(NameReplyEventArgs e)
        {
            if (_Nicks == null)
            {
                _Nicks = new List<string>();
            }
            foreach (string s in e.NameList)
            {
                if (!_Nicks.Contains(s))
                    _Nicks.Add(s);
            }
            
        }
        private bool _IsJoined;
        public bool IsJoined
        {
            get { return _IsJoined; }
            set { _IsJoined = value; }
        }
    }
}
