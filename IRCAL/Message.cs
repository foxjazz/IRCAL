using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    public class Message
    {
        
        private   string _Message;
        public  string message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        private string  _From;
        public string  from
        {
            get { return _From; }
            set { _From = value; }
        }
        private string _Channel;
        public string channel
        {
            get { return _Channel; }
            set { _Channel = value; }
        }
        private string  _Server;
        public string  server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        private string _Direction;
        public string Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }
        private int _Index;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _LogFile;
        public string LogFile
        {
            get { return _LogFile; }
            set { _LogFile = value; }
        }

    }
}
