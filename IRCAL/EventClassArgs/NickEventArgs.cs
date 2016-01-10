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
	/// Args for the NickEvent
	/// </summary>
	public class NickEventArgs
	{
		private UserInfo m_user;
		private string m_newnick;
		private bool m_you;

		/// <summary>
		/// Old nick
		/// </summary>
		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}

		/// <summary>
		/// New nick
		/// </summary>
		public string NewNick
		{
			get
			{
				return m_newnick;
			}
		}

		/// <summary>
		/// Checks if the NICK message come from the IRCConnection user.
		/// </summary>
		public bool IsYou
		{
			get
			{
				return m_you;
			}
		}

		/// <summary>
		/// Build a NickEventArgs.
		/// </summary>
		/// <param name="user">UserInfo user of the user who changes his nickname.</param>
		/// <param name="newnick">The new nickname.</param>
		/// <param name="isyou">Is the user of the IRCConnection.</param>
		public NickEventArgs(UserInfo user, string newnick, bool isyou)
		{
			this.m_user = user;
			this.m_newnick = newnick;
			this.m_you = isyou;
		}
	}
}
