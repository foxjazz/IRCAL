using System;

namespace myIRC
{
	/// <summary>
	/// Summary description for ChannelListItem.
	/// </summary>
	public class ChannelListItem
	{
		private string m_channelname;
		private int m_nbrusers;
		private string m_topic;

		public string ChannelName
		{
			get
			{
				return m_channelname;
			}
		}

		public int NumberOfUsers
		{
			get
			{
				return m_nbrusers;
			}
		}

		public string Topic
		{
			get
			{
				return m_topic;
			}
		}

		public ChannelListItem(string channelname, int nbrusers, string topic)
		{
			this.m_channelname = channelname;
			this.m_nbrusers = nbrusers;
			this.m_topic = topic;
		}
	}
}
