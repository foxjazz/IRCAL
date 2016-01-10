using System;

namespace myIRC
{
	/// <summary>
	/// NoticeEventArgs store the information of a notice.
	/// </summary>
	public class NoticeEventArgs
	{
		private UserInfo m_user;
		private string m_message;
		private string m_from;

		/// <summary>
		/// Gets the info of the user who sent the notice.
		/// </summary>
		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}

		/// <summary>
		/// Gets the message of the notice.
		/// </summary>
		public string Message
		{
			get
			{
				return m_message;
			}
		}

		/// <summary>
		/// Gets the destination of the notice.
		/// </summary>
		public string From
		{
			get
			{
				return m_from;
			}
		}

		/// <summary>
		/// Build a NoticeEventArgs.
		/// </summary>
		/// <param name="user">The user where the notice came from.</param>
		/// <param name="message">The message.</param>
		/// <param name="from">Destination.</param>
		public NoticeEventArgs(UserInfo user, string message, string from)
		{
			this.m_user = user;
			this.m_message = message;
			this.m_from = from;
		}
	}
}
