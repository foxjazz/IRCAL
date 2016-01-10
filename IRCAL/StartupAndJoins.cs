using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace myIRC
{
    class StartupAndJoins
    {
        
        public static void JoinFavorites(IRCCore icore, Dictionary<string,ChanMessageList> clist)
        
        {
            DataClass oData;
            DataTable dt = new DataTable();
            oData = DataClass.Instance;
            //SavedSet.ServerListDataTable dtSList;
            Dictionary<string,ChanFav> favlist = oData.GetFavoriteList(icore.ServerName);

            
            foreach (KeyValuePair<string,ChanFav> cf in  favlist)
            {
             
                if (!clist.ContainsKey(cf.Value.channel))
                {
                    icore.SendRaw("JOIN #" + cf.Value.channel);
                    ChanMessageList cml = new ChanMessageList();
                    cml.Channel = cf.Value.channel;
                    clist.Add(cf.Value.channel, cml);
                }

            }
            
            foreach (KeyValuePair<string, ChanMessageList> cvpair in clist)
            {
                if (!favlist.ContainsKey(cvpair.Value.Channel))
                {
                    icore.SendRaw("PART #" + cvpair.Value.Channel);
                }
            }
        }
    }
}
