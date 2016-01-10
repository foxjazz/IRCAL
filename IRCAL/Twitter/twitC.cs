using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using System.ServiceModel;
using System.Net;
using System.IO;

namespace myIRC.Twitter
{
    public class twitC
    {

      
        private string PerformRequest(string method, string url)
        {
            string user = myIRC.Properties.Settings.Default.TwitterUser;
            string password = myIRC.Properties.Settings.Default.TwitterPassword;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = method;
            request.Credentials = new NetworkCredential(user, password);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            reader.Close();
            return responseString;
        }
        private string Post(string url)
        {
            return PerformRequest("POST", url);
        }

        private string Get(string url)
        {
            return PerformRequest("GET", url);
        }

     

       public List<UserStatus> GetUserTimeLine(string user)
       {
           string url = string.Format("http://twitter.com/statuses/user_timeline/{0}.xml", user);
           string response = Get(url);

           XDocument document = XDocument.Parse(response, LoadOptions.None);

           var query = from e in document.Root.Descendants("status")
                       select new UserStatus
                       {
                           UserName = e.Element("user").Element("name").Value,
                           ProfileImage = e.Element("user").Element("profile_image_url").Value,
                           Status = HttpUtility.HtmlDecode(e.Element("text").Value),
                           StatusDate = (e.Element("created_at").Value.ParseDateTime())
                       };

           List<UserStatus> users = (from u in query
                                     where u.Status != ""
                                     orderby u.StatusDate descending
                                     select u).ToList();

           return users;
       }
    }
}
