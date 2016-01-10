using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myIRC.Twitter
{
    public class UserStatus
    {
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
