using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC
{
    public class ForwardEventArgs
    {

        public ForwardEventArgs(string s1, string s2)
        {
            _SourceChannel = s1;
            _TargetChannel = s2;
        }
        private string _SourceChannel;
        public string sourceChannel
        {
            get { return _SourceChannel; }
            
        }
        private string _TargetChannel;
        public string targetChannel
        {
            get { return _TargetChannel; }
            
        }
    }
}
