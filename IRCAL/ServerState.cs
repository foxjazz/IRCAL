using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    class ServerState
    {

        public ServerState(string servername)
        {
            _Servername = servername;
        }
        private string _Servername;
        public string servername
        {
            get { return _Servername; }
            set { _Servername = value; }
        }
        private Dictionary<string,ChanMessageList> _ChannelMessages;
        public Dictionary<string,ChanMessageList> ChannelMessages
        {
            get { return _ChannelMessages; }
            set { _ChannelMessages = value; }
        }
        public Dictionary<string, ChanMessageList> ChannelList;

    }
}
