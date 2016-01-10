using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace myIRC
{
    public class SBMessage
    {
        public SBMessage()
        {
            string connectionString = (string) myIRC.Properties.Settings.Default.ServiceBus;
            client = QueueClient.CreateFromConnectionString(connectionString, "irc");
            timetolive=TimeSpan.FromDays(10);
        }
        public QueueClient client;
        TimeSpan timetolive;
        public void SendSBM(string msg, string channel)
        {
            message = new BrokeredMessage(msg);
            message.Properties["channel"] = channel;
            message.TimeToLive = timetolive;
            client.Send(message);
        }
        public void SendSBM(string msg){

            message = new BrokeredMessage(msg) { TimeToLive = timetolive };
        client.Send(message);

            
        }
        BrokeredMessage message;
    }
}
