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
	/// Args for the KickEvent
	/// </summary>
	public class KickEventArgs
	{
		private string m_kickednick;
		private UserInfo m_user;
		private string m_reason;
		
		private string m_from;

		/// <summary>
		/// The nick that have been kicked
		/// </summary>
		public string KickedNick
		{
			get
			{
				return m_kickednick;
			}
		}

		/// <summary>
		/// The nick who kick
		/// </summary>
		public UserInfo KickerUser
		{
			get
			{
				return m_user;
			}
		}

		/// <summary>
		/// The reason of the kick
		/// </summary>
		public string Reason
		{
			get
			{
				return m_reason;
			}
		}


		public string From
		{
			get
			{
				return m_from;
			}
		}
		/// <summary>
		/// Build a KickEventArgs.
		/// </summary>
		/// <param name="kickednick">The nick of the user been kicked.</param>
		/// <param name="kickeruser">The UserInfo of the user who kicked the user.</param>
		/// <param name="reason">The reason why he kicked.</param>
		/// <param name="from">From which channel.</param>
		/// <param name="isyou">Is the current user of the IRCConnection.</param>
		public KickEventArgs(string kickednick, UserInfo kickeruser, string reason, string from)
		{
			this.m_kickednick = kickednick;
			this.m_user = kickeruser;
			this.m_reason = reason;
			this.m_from = from;
			
		}
	}
}
