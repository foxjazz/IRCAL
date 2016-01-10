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
	/// UserInfo stores the information of a user.
	/// </summary>
	public class UserInfo
	{
		private string m_nick;
		private string m_realname;
		private string m_hostname;
		private bool m_invisible;

		/// <summary>
		/// Gets or sets the nick of a user.
		/// </summary>
		public string Nick
		{
			get
			{
				return m_nick;
			}
			set
			{
				m_nick = value;
			}
		}

		/// <summary>
		/// Gets or sets the real name of a user.
		/// </summary>
		public string RealName
		{
			get
			{
				return m_realname;
			}
			set
			{
				m_realname = value;
			}
		}

		/// <summary>
		/// Gets or sets the Invisible flag.
		/// </summary>
		public bool Invisible
		{
			get
			{
				return m_invisible;
			}
			set
			{
				m_invisible = value;
			}
		}

		/// <summary>
		/// Gets or sets the hostname of a user.
		/// </summary>
		public string HostName
		{
			get
			{
				return m_hostname;
			}
			set
			{
				m_hostname = value;
			}
		}

		/// <summary>
		/// Build a imcomplete UserInfo.
		/// </summary>
		/// <param name="nick">The user's nick.</param>
		/// <param name="hostname">The user's hostname.</param>
		public UserInfo(string nick, string hostname)
		{
			this.m_nick = nick;
			this.m_hostname = hostname;
			this.m_realname = "";
			this.m_invisible = false;
		}

		/// <summary>
		/// Build a complete UserInfo.
		/// </summary>
		/// <param name="nick">The user's nick.</param>
		/// <param name="realname">The user's real name.</param>
		/// <param name="hostname">The user's hostname.</param>
		/// <param name="invisible">The user's invisible flag.</param>
		public UserInfo(string nick, string realname, string hostname, bool invisible)
		{
			this.m_nick = nick;
			this.m_realname = realname;
			this.m_hostname = hostname;
			this.m_invisible = invisible;
		}

		/// <summary>
		/// Gets the UserInfo in a string.
		/// </summary>
		/// <returns>Formated string with the user infos.</returns>
        private string _Status;
        public string status
        {
            get { return _Status; }
            set { _Status = value; }
        }
		public override string ToString()
		{
			return this.Nick + "@" + this.HostName + " :" + this.RealName;
		}

		/// <summary>
		/// Base constructor.
		/// </summary>
		public UserInfo()
		{

		}
	}
}
