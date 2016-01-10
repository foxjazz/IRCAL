using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
namespace myIRC
{
    class Notify
    {
        private DataClass dc;
        public Notify()
        {
            dc = DataClass.Instance;
            speaker = new SpeechSynthesizer();
            speaker.Rate = 1;
            speaker.Volume = 100;
        }
        SpeechSynthesizer speaker;
        public void CheckName(string nick)
        {

            SavedSet.NameNotificationRow nnr;
            if (dc.NameNotificationList.ContainsKey(nick))
            {
                dc.NameNotificationList.TryGetValue(nick, out nnr);
                if ( DBNull.Value.Equals(nnr["DateOfLastActivity"] ) )
                    nnr.DateOfLastActivity = DateTime.Now;

                else
                {
                    //here compare now to threshhold, 
                    DateTime activity = nnr.DateOfLastActivity;
                    int Threshold = nnr.Threshold;
                    activity = activity.AddMinutes(Threshold);
                    if (activity > DateTime.Now)
                    { //if added activity time < currenttime then no need to notify, get out.
                        nnr.DateOfLastActivity = DateTime.Now;
                        return;
                    }
                }

                if (nnr.WaveFile == null || nnr.WaveFile.Length == 0)
                {
                    speaker.Speak(nnr.Phonetic);
                    dc.Save();
                }
                //else play wav file selected.

                nnr.DateOfLastActivity = DateTime.Now;
            }
            
        }

        internal void CheckChannel(string server,string scChannel, PrivMsgEventArgs nPME)
        {
            Dictionary<string, ChanFav> favs;
            favs = dc.GetFavoriteList(server);
            ChanFav cf;
            if (favs.TryGetValue(scChannel, out cf))
            {
                dc.UpdateChanFavLast();
                if (cf.Last == null)
                {
                
                    return;
                }
                DateTime activity = cf.Last;
                int Threshold = cf.NotifyMinute;
                if (cf.NotifyMinute == 0)
                    return;
                activity = activity.AddMinutes(Threshold);
                if (activity > DateTime.Now)
                { //if added activity time > currenttime then no need to notify, get out.
                
                    return;
                }
                string ph;
                if (cf.Phonetic.Length == 0)
                    ph = cf.channel;
                else
                    ph = cf.Phonetic;

                if (ph.ToLower() == "notset")
                    return;
                speaker.Speak("channel " + ph + " has activity from " + nPME.User.Nick);

            }
        }
    }
}
