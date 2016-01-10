using System;

namespace myIRC
{
	/// <summary>
	/// TopicEventArgs stores the information of a topic change of a channel.
	/// </summary>
	public class TopicEventArgs
	{
		private UserInfo m_user;
		private string m_topic;
		private string m_channel;

		/// <summary>
		/// Gets the info of the user who changed the topic.
		/// </summary>
		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}

		/// <summary>
		/// Gets the new topic.
		/// </summary>
		public string Topic
		{
			get
			{
				return m_topic;
			}
		}

		/// <summary>
		/// Gets the channel where the topic was changed.
		/// </summary>
		public string Channel
		{
			get
			{
				return m_channel;
			}
		}

		/// <summary>
		/// Build a TopicEventArgs.
		/// </summary>
		/// <param name="user">The user who changed the topic.</param>
		/// <param name="topic">The new topic.</param>
		/// <param name="channel">The channel where the topic was changed.</param>
		public TopicEventArgs(UserInfo user, string topic, string channel)
		{
			this.m_user = user;
			this.m_topic = topic;
			this.m_channel = channel;
		}
	}
}
