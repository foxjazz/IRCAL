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
	/// CTCPReceivedEventArgs store the info of a CTCP message (PRIVMSG).
	/// </summary>
	public class CTCPReceivedEventArgs
	{
		private UserInfo m_user;
		private string m_ctcptype;
		private string m_from;

		/// <summary>
		/// Gets the info of the user who sent the CTCP message.
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
		/// Gets the source of the CTCP message, where it come from.
		/// </summary>
		public string From
		{
			get
			{
				return m_from;
			}
		}

		/// <summary>
		/// Build the CTCPReceivedEventArgs.
		/// </summary>
		/// <param name="user">The user who came from the CTCP.</param>
		/// <param name="ctcptype">CTCP type.</param>
		/// <param name="from">From whom(can be a user nick or a channel).</param>
		public CTCPReceivedEventArgs(UserInfo user, string ctcptype, string from)
		{
			this.m_user = user;
			this.m_ctcptype = ctcptype;
			this.m_from = from;
		}
	}
}
