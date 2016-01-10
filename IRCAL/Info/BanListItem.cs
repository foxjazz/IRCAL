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
	/// BanListItem is a banlist item obtained by the IRC Server reply 367.
	/// </summary>
	public class BanListItem
	{
		private string m_hostbanned;
		private UserInfo m_user;
		private DateTime m_datetime;
		private int m_nbMinsBanned;	// Nombre(s) de minutes avant que l'utilisateur 
									//  soit débanni.

		/// <summary>
		/// Gets or sets the host banned.
		/// </summary>
		public string HostBanned
		{
			get
			{
				return m_hostbanned;
			}
			set
			{
				m_hostbanned = value;
			}
		}

		public int NbMinsBanned
		{
			get
			{
				return m_nbMinsBanned;
			}
			set
			{
				m_nbMinsBanned = value;
			}
		}

		/// <summary>
		/// Gets the user who banned the host.
		/// </summary>
		public UserInfo User
		{
			get
			{
				return m_user;
			}
		}

		/// <summary>
		/// Gets the DateTime object when the user ban the host.
		/// </summary>
		public DateTime WhenHostWasBanned
		{
			get
			{
				return m_datetime;
			}
		}

		/// <summary>
		/// Build a banlist item
		/// </summary>
		/// <param name="hostbanned">Host banned in a string.</param>
		/// <param name="user">UserInfo class of the user that banned this host.</param>
		/// <param name="datetime">DateTime class when the user banned this host.</param>
		public BanListItem(string hostbanned, UserInfo user, DateTime datetime, int p_nbMinsBanned)
		{
			this.m_hostbanned = hostbanned;
			this.m_user = user;
			this.m_datetime = datetime;
			this.m_nbMinsBanned= p_nbMinsBanned;
		}

		/// <summary>
		/// Build a banlist item
		/// </summary>
		/// <param name="hostbanned">Host banned in a string.</param>
		/// <param name="user">UserInfo class of the user that banned this host.</param>
		/// <param name="datetime">DateTime class when the user banned this host.</param>
		public BanListItem(string hostbanned, UserInfo user, DateTime datetime)
		{
			this.m_hostbanned = hostbanned;
			this.m_user = user;
			this.m_datetime = datetime;
			this.m_nbMinsBanned = -1;
		}
	}
}
