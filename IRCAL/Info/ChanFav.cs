using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    public class ChanFav
    {
        public ChanFav(string s)
        {
            _Channel = s;
        }
        public ChanFav()
        {
            
        }
        private string _Channel;
        public string channel
        {
            get { return _Channel; }
            set { _Channel = value; }
        }
        private Int32 _NotifyMinute;
        public Int32 NotifyMinute
        {
            get { return _NotifyMinute; }
            set { _NotifyMinute = value; }
        }
        private string _Phonetic;
        public string Phonetic
        {
            get { return _Phonetic; }
            set { _Phonetic = value; }
        }
        private DateTime _Last;
        public DateTime Last
        {
            get { return _Last; }
            set { _Last = value; }
        }
    }
}
