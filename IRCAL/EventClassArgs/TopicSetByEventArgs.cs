using System;

namespace myIRC 
{
	/// <summary>
	/// Summary description for TopicSetByEventArgs.
	/// </summary>
	public class TopicSetByEventArgs
	{
		private string m_channel;
		private string m_nick;
		private DateTime m_when;

		public string Channel
		{
			get
			{
				return m_channel;
			}
		}

		public string SetByWho
		{
			get
			{
				return m_nick;
			}
		}

		public DateTime When
		{
			get
			{
				return m_when;
			}
		}

		public TopicSetByEventArgs(string channel, string nick, DateTime when)
		{
			this.m_channel = channel;
			this.m_nick = nick;
			this.m_when = when;
		}
	}
}
