using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    sealed class CurrentState
    {
        private static CurrentState instance;
        public static CurrentState Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new CurrentState();
                }
                return instance;
            }
            
        }
        private Dictionary<string,ServerState> _ServersInUse;
        public Dictionary<string,ServerState> ServersInUse
        {
            get { return _ServersInUse; }
            set { _ServersInUse = value; }
        }

        private Dictionary<string,ChanMessageList> _ActiveChannelList;
        public Dictionary<string,ChanMessageList> activeChannelList
        {
            get { return _ActiveChannelList; }
            set { _ActiveChannelList = value; }
        }

        public void SetServerInUse(string ic)
        {
            if (_ServersInUse == null)
                _ServersInUse = new Dictionary<string, ServerState>();
            if (!_ServersInUse.ContainsKey(ic))
            {
                currentserver = new ServerState(ic);
                _ServersInUse.Add(ic,currentserver);
            }
            if (_ActiveChannelList == null)
            {
                _ActiveChannelList = new Dictionary<string, ChanMessageList>();
                currentserver.ChannelList = _ActiveChannelList;
            }
        }

        private  ServerState currentserver;
    
    }
}
