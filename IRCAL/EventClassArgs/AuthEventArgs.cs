using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    public class AuthEventArgs
    {
        public AuthEventArgs(string mes)
        {
            _Message = mes;
        }
        private string _Message;
        public string message
        {
            get { return _Message; }
        }
    }
}
