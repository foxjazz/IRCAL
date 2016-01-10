using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    class IRCserver
    {
        public IRCserver(string name, Int32 port)
        {
            _Servername = name;
            _Port = port;
        }
        public IRCserver(string name, string port)
        {
            _Servername = name;
            _Port = Convert.ToInt32(port);
        }

        private string _Servername;
        public string servername
        {
            get { return _Servername; }
        
        }
        private Int32 _Port;
        public Int32 port
        {
            get { return _Port; }
        
        }
    }
}
