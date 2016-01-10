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
	/// CTCPReplyEventArgs stores the information of a CTCP reply (NOTICE).
	/// </summary>
	public class CTCPReplyEventArgs
	{
		private UserInfo m_user;
		private string m_ctcptype;
		private string m_reply;

		/// <summary>
		/// Gets the info of the user who reply to the CTCP message.
		/// </summary>
		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}

		/// <summary>
		/// Gets the CTCP type.
		/// </summary>
		public string CTCPType
		{
			get
			{
				return m_ctcptype;
			}
		}

		/// <summary>
		/// Gets the reply of the CTCP message.
		/// </summary>
		public string Reply
		{
			get
			{
				return m_reply;
			}
		}

		/// <summary>
		/// Build a CTCPReplyEventArgs.
		/// </summary>
		/// <param name="user">The user who reply to the CTCP message.</param>
		/// <param name="ctcptype">CTCP type.</param>
		/// <param name="reply">The reply of the CTCP message.</param>
		public CTCPReplyEventArgs(UserInfo user, string ctcptype, string reply)
		{
			this.m_user = user;
			this.m_ctcptype = ctcptype;
			this.m_reply = reply;
		}
	}
}
