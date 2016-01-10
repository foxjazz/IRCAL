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
	/// NameReplyEventArgs stores the information of the Name Reply message.
	/// </summary>
	public class NameReplyEventArgs
	{
		private string m_channel;
		private string[] m_namelist;

		/// <summary>
		/// Gets the channel where the name list come from.
		/// </summary>
		public string Channel
		{
			get
			{
				return m_channel;
			}
		}

		/// <summary>
		/// Gets the name list.
		/// </summary>
		public string[] NameList
		{
			get
			{
				return m_namelist;
			}
		}

		/// <summary>
		/// Build a NameReplyEventArgs.
		/// </summary>
		/// <param name="channel">The channel where it came from.</param>
		/// <param name="namelist">The name list.</param>
		public NameReplyEventArgs(string channel, string[] namelist)
		{
			this.m_channel = channel;
			this.m_namelist = namelist;
		}
	}
}
