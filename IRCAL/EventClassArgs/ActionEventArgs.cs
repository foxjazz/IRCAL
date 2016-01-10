using System;

namespace myIRC
{
	/// <summary>
	/// Summary description for ActionEventArgs.
	/// </summary>
	public class ActionEventArgs
	{
		private UserInfo m_user;
		private string m_message;
		private string m_from;

		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}

		public string Message
		{
			get
			{
				return m_message;
			}
		}

		public string From
		{
			get
			{
				return m_from;
			}
		}
		public ActionEventArgs(UserInfo user, string from, string message)
		{
			this.m_user = user;
			this.m_from = from;
			this.m_message = message;
		}
	}
}
