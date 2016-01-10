// Aeru IRC - A IRC Client for Microsoft .NET Framework
// Copyright (C) 2002 Shock's Dev
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

using System;

namespace myIRC
{
	/// <summary>
	/// PrivMsgEventArgs stores the information of a private message.
	/// </summary>
	public class PrivMsgEventArgs
	{
		private UserInfo m_user;
		private string m_message;
		private string m_from;
		private bool m_isfromchannel;

		/// <summary>
		/// Nick that the message come from
		/// </summary>
		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}
        public void SetData(string msg,UserInfo usr, string from, bool Is)
        {
            
            this.m_user = usr;
            this.m_message = msg;
            this.m_from = from;
            this.m_isfromchannel = Is;

        }
        public void Copy(ref PrivMsgEventArgs npme)
        {
            npme.SetData(this.m_message, this.m_user, this.From, this.IsFromAChannel);
        }
		/// <summary>
		/// The message itself
		/// </summary>
		public string Message
		{
			get
			{
				return m_message;
			}
		}

		/// <summary>
		/// From who or what come the message(a query or a channel)
		/// </summary>
		public string From
		{
			get
			{
				return m_from;
			}
		}

		/// <summary>
		/// Determines if the message is from a channel
		/// </summary>
		public bool IsFromAChannel
		{
			get
			{
				return m_isfromchannel;
			}
		}
        //private string _Nick;
        //public string nick
        //{
        //    get { return _Nick; }
        //    set { _Nick = value; }
        //}
		/// <summary>
		/// Build a PrivMsgEventArgs.
		/// </summary>
		/// <param name="user">The user where the message came from.</param>
		/// <param name="message">The message.</param>
		/// <param name="from">Destination of the message.</param>
		/// <param name="isfromachannel">Is from a channel?</param>
        /// 
        public PrivMsgEventArgs() { }
		public PrivMsgEventArgs(UserInfo user, string message, string from, bool isfromachannel)
		{

			this.m_user = user;
			this.m_message = message;
			this.m_from = from;
			this.m_isfromchannel = isfromachannel;
		}
	}
}
