using System;

namespace myIRC
{
	/// <summary>
	/// ModeEventArgs store the information of a mode change of a channel.
	/// </summary>
	public class ModeEventArgs
	{
		private UserInfo m_user;
		private string m_mode;
		private string m_channel;

		/// <summary>
		/// Gets the info of the user who changed the mode.
		/// </summary>
		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}

		/// <summary>
		/// Gets the mode string.
		/// </summary>
		public string Mode
		{
			get
			{
				return m_mode;
			}
		}

		/// <summary>
		/// Gets the channel where the mode changed.
		/// </summary>
		public string Channel
		{
			get
			{
				return m_channel;
			}
		}

		/// <summary>
		/// Build a ModeEventArgs.
		/// </summary>
		/// <param name="user">The user who change the mode</param>
		/// <param name="mode">The mode string.</param>
		/// <param name="channel">The channel where the mode was changed.</param>
		public ModeEventArgs(UserInfo user, string mode, string channel)
		{
			this.m_user = user;
			this.m_mode = mode;
			this.m_channel = channel;
		}
	}
}
