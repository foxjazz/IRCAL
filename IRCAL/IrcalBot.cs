using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myIRC.Twitter;
using LinqToTwitter;

namespace myIRC
{
    public class IrcalBot
    {
        private DataClass dc;
        public IrcalBot(IRCCore ircCore1)
        {
            status = false;
            
            botCore = ircCore1;
            dc = DataClass.Instance;
           
        }

        private IRCCore botCore;
        public bool status { get; set; }
        private string user { get; set; }
        private string selectedchannel { get; set; }
        public void pushmessage(List<Message> lstmsg)
        {
           
            foreach (Message mm in lstmsg)
            {
                if(setChannel(mm) < 0)
                    return ;
               
                process(mm);
            }

        }
        private int setChannel(Message mm)
        {

            int nloc = mm.message.IndexOf("#");
            if (nloc < 0)
                return -1;
            int end = mm.message.IndexOf(" ", nloc);
            if (end < 1)
                return -1;
            if (nloc >= end)
                return -1;
            selectedchannel = mm.message.Substring(nloc + 1, end - nloc);
            return nloc;
        }
        private void process(Message mm)
        {
            string[] ml;
            int cnt;
            if (mm.message.IndexOf(dc.GetNick()) >= 0)
            {
                ml = mm.message.Split(' ');

                if (ml[4].ToLower() == "req")
                {
                    if (ml.Length == 6)
                        DoReq(ml[5], 1);
                    else{
                        if(Int32.TryParse(ml[6],out cnt))
                            DoReq(ml[5],cnt);
                        }
                    }
            }
        }
        twitC oTwit;
        List<UserStatus> us;
        private void DoReq(string name, int cnt)
        {
            GetTwitterStatus(name, cnt);
        }

        private void GetTwitterStatus(string name,int cnt)
        {
            var twitterCtx = new TwitterContext(DoSingleUserAuth());
            var friendTweets =
                from tweet in twitterCtx.Status
                where tweet.Type == StatusType.User &&
                      tweet.ScreenName == name &&
                      tweet.Count == cnt
                select new
                {
                    tweet.User.Name,
                    tweet.RetweetedStatus,
                    tweet.Text
                };

            int icnt=0;
            if (friendTweets.Count() == 0)
                SendChannel(name + ": no activity.");
            foreach (var tweet in friendTweets)
            {
                SendChannel(name + ": " + tweet.Text);
              
            }

        }
        private void SendChannel(string msg)
        {
            botCore.SendRaw("PRIVMSG #" + selectedchannel + " :" + msg + "\r\n");
        }

        static ITwitterAuthorizer DoSingleUserAuth()
        {
            // validate that credentials are present
            //if (ConfigurationManager.AppSettings["twitterConsumerKey"].IsNullOrWhiteSpace() ||
            //    ConfigurationManager.AppSettings["twitterConsumerSecret"].IsNullOrWhiteSpace() ||
            //    ConfigurationManager.AppSettings["twitterOAuthToken"].IsNullOrWhiteSpace() ||
            //    ConfigurationManager.AppSettings["twitterAccessToken"].IsNullOrWhiteSpace())
            //{
            //    Console.WriteLine("You need to set credentials in App.config/appSettings. Visit http://dev.twitter.com/apps for more info.\n");
            //    Console.Write("Press any key to exit...");
            //    Console.ReadKey();
            //    return null;
            //}

            // configure the OAuth object
            var auth = new SingleUserAuthorizer
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = myIRC.Properties.Settings.Default.twitterConsumerKey,
                    ConsumerSecret = myIRC.Properties.Settings.Default.twitterConsumerSecret,
                    OAuthToken = myIRC.Properties.Settings.Default.twitterOAuthToken,
                    AccessToken = myIRC.Properties.Settings.Default.twitterAccessToken
                }
            };

            // Remember, do not call authorize - you don't need it.
            // auth.Authorize();
            return auth;
        }

    }
}
