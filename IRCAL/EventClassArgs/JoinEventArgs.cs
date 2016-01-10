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
	/// Args for the Join Event
	/// </summary>
	public class JoinEventArgs : System.EventArgs
	{
		private string m_channel;
		private UserInfo m_user;
		/// <summary>
		/// Channel joined
		/// </summary>
		public string Channel
		{
			get
			{
				return m_channel;
			}
		}

		/// <summary>
		/// Nick that join Channel
		/// </summary>
		public UserInfo JoinedUser
		{
			get
			{
				return m_user;
			}
		}
        private string _Reason;
        public string reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
		/// <summary>
		/// Build a JoinEventArgs.
		/// </summary>
		/// <param name="channel">The channel where the user joined.</param>
		/// <param name="joineduser">UserInfo of the joineduser.</param>
		public JoinEventArgs(string channel, UserInfo joineduser)
		{
			this.m_channel = channel;
			this.m_user = joineduser;
		}
        public JoinEventArgs(string channel, UserInfo joineduser,string reason)
        {
            this.m_channel = channel;
            this.m_user = joineduser;
            this.reason = reason;
        }
	}
}
