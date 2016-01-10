using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;


namespace myIRC
{
    public partial class IRCCore : BackgroundWorker
    {
        public IRCCore()
        {
            InitializeComponent();
           
        }

        public IRCCore(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private List<string> _RawLog;
        public List<string> RawLog
        {
            get { return _RawLog; }
            set { _RawLog = value; }
        }
        private string _ServerName;
        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }
        private Socket m_socket;
        private ConnectionState m_state = ConnectionState.Disconnected;
        public enum ConnectionState
        {
            /// <summary>
            /// Disconnected
            /// </summary>
            Disconnected,
            /// <summary>
            /// Connecting...
            /// </summary>
            Connecting,
            /// <summary>
            /// Connected!
            /// </summary>
            Connected,
        }
        public ConnectionState ConnectionStatus
        {
            get
            {
                return m_state;
            }
            set
            {
                m_state = value;
            }
        }
        Message otMessage;
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            writeThreshold = 0;
            otMessage = (Message)e.Argument;
            _RawLog = new List<string>();
            setupLog();
            Connection(otMessage.server);
            

        }
        TextWriter writer;
        private void setupLog()
        {
            writer = File.CreateText(otMessage.LogFile);
        }
        private int m_port = 6667;
        string ea;
        public void Connect(string serverinfo)
        {
            ea = serverinfo;
            _ServerName = serverinfo;
            this.ConnectionWorker1.RunWorkerAsync(ea);
            
        }
        List<Message> oMessList;
        private void Connection(string serverinfo)
        {
            try
            {
                m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.ConnectionStatus = ConnectionState.Connecting;
                _ServerName = serverinfo;
                IPAddress server_ip = Dns.GetHostEntry(serverinfo).AddressList[0];
                IPEndPoint remotepoint = new IPEndPoint(server_ip, m_port);
                m_socket.Connect(remotepoint);
                Receive();
               
            }
            catch (SocketException ex)
            {
                this.ConnectionStatus = ConnectionState.Disconnected;
                otMessage.message = "ERROR:" + ex.Message;
                ReportProgress(0, otMessage);
               // this.OnErrorMessageReceived(ex.Message);
            }
        }
        int writeThreshold;
       
        private void Receive()
        {
            string messagefragment = "";
           
            while ( m_socket.Connected)
            {
                try
                {
                    
                    Byte[] buffer = new byte[512];
                    string received;
                    int index = 0;
                    bool NeedParsing = true;
                    if (m_socket.Receive(buffer) > 0)
                    {
                        oMessList = new List<Message>();
                        Message oM;
                        
                        received = Encoding.Default.GetString(buffer);
                        string[] MessageQueue = received.Split("\r\n".ToCharArray());
                        index = 0;
                        foreach (string message in MessageQueue)
                        {

                           
                            index++;
                            oM = new Message();
                            
                            NeedParsing = true;
                            oM.Direction = "";
                            oM.Status = "started";
                            oM.message = message;
                            _RawLog.Add(message + "\n");
                            writer.WriteLine(message);
                            writeThreshold++;
                            if (writeThreshold % 10 == 0)
                                writer.Flush();
                            oM.Index = index - 1;
                            if (MessageQueue.Length == index)
                                oM.Status = "done";
                            oMessList.Add(oM);
                            if (message.StartsWith(":") == false && message.StartsWith("PING") == false && message.StartsWith("NOTICE") == false && index == 1)
                            {
                                string tempmessage = messagefragment + message;
                                NeedParsing = false;
                                oM.Direction = "parse";
                                ReportProgress(0, oMessList);
                                //OnRawMessageReceived(tempmessage);
                               // m_parser.MainParser(tempmessage.Split(new char[] { ' ' }));
                            }
                            if (index == MessageQueue.Length)
                            {
                                messagefragment = message;
                                NeedParsing = false;
                            }
                            if (message.StartsWith("PING"))
                            {
                                string[] pong = received.Split(new char[] { ':' });
                                SendRaw("PONG " + pong[1]);
                            }
                            else
                            {
                                if (NeedParsing)
                                {
                                    oM.Direction = "parse";
                                    otMessage.message = message;
                                    ReportProgress(0, oMessList);


                                }
                            }
                        }
                        
                    }
                    else
                    {
                        this.ConnectionStatus = ConnectionState.Disconnected;

                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.ConnectionStatus = ConnectionState.Disconnected;
                    otMessage.message = "ERROR: " + ex.Message;
                    //this.OnErrorMessageReceived("ERROR: " + ex.Message);
                    ReportProgress(0,otMessage);
                }
            }
            
        }
        public void SendRaw(string command)
        {
            if (m_socket == null)
                return;
            if (m_socket.Connected)
            {
              
                Byte[] cmdBytes = Encoding.Default.GetBytes((command + "\r\n").ToCharArray());
                m_socket.Send(cmdBytes);
            }
        }

     

    }
}
