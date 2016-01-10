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
using System.Collections;

namespace myIRC
{
	/// <summary>
	/// ChannelInfo stores the information of a channel.
	/// </summary>
	public class ChannelInfo
	{
		private string m_channel;
		private ArrayList m_topics;
		private string m_limit;
		private string m_key;

		private bool m_private;
		private bool m_invite;
		private bool m_secret;
		private bool m_opstopic;
		private bool m_externmessage;
		private bool m_moderated;

		private BanList m_banlist;

		/// <summary>
		/// Gets or sets the channel name.
		/// </summary>
		public string ChannelName
		{
			get
			{
				return m_channel;
			}
			set
			{
				m_channel = value;
			}
		}

		/// <summary>
		/// Gets or sets the topics of the channel.
		/// </summary>
		public ArrayList Topics
		{
			get
			{
				return m_topics;
			}
			set
			{
				m_topics = value;
			}
		}

		/// <summary>
		/// Gets or sets the limit of users of a channel.
		/// </summary>
		public string Limit
		{
			get
			{
				return m_limit;
			}
			set
			{
				m_limit = value;
			}
		}

		/// <summary>
		/// Gets or sets the key of the channel.
		/// </summary>
		public string Key
		{
			get
			{
				return m_key;
			}
			set
			{
				m_key = value;
			}
		}

		/// <summary>
		/// Gets or sets the "p" flag.
		/// </summary>
		public bool IsPrivate
		{
			get
			{
				return m_private;
			}
			set
			{
				m_private = value;
			}
		}

		/// <summary>
		/// Gets or sets the "i" flag.
		/// </summary>
		public bool IsInvite
		{
			get
			{
				return m_invite;
			}
			set
			{
				m_invite = value;
			}
		}

		/// <summary>
		/// Gets or sets the "s" flag.
		/// </summary>
		public bool IsSecret
		{
			get
			{
				return m_secret;
			}
			set
			{
				m_secret = value;
			}
		}

		/// <summary>
		/// Gets or sets the "t" flag.
		/// </summary>
		public bool IsOnlyOpsSetTopic
		{
			get
			{
				return m_opstopic;
			}
			set
			{
				m_opstopic = value;
			}
		}

		/// <summary>
		/// Gets or sets the "m" flag.
		/// </summary>
		public bool IsModerated
		{
			get
			{
				return m_moderated;
			}
			set
			{
				m_moderated = value;
			}
		}

		/// <summary>
		/// Gets or sets the "n" flag.
		/// </summary>
		public bool IsNotAcceptExternalMessages
		{
			get
			{
				return m_externmessage;
			}
			set
			{
				m_externmessage = value;
			}
		}

		/// <summary>
		/// Gets the complete mode of the channel in a string.
		/// </summary>
		public string Mode
		{
			get
			{
				string channelmode = "+";
				if(IsInvite)
					channelmode += "i";
				if(IsModerated)
					channelmode += "m";
				if(IsNotAcceptExternalMessages)
					channelmode += "n";
				if(IsPrivate)
					channelmode += "p";
				if(IsSecret)
					channelmode += "s";
				if(IsOnlyOpsSetTopic)
					channelmode += "t";
				if(Limit != "")
					channelmode += "l";
				if(Key != "")
					channelmode += "k";
				return channelmode;
			}
		}

		/// <summary>
		/// Gets or sets the ban list of the channel.
		/// </summary>
		public BanList BanList
		{
			get
			{
				return m_banlist;
			}
			set
			{
				m_banlist = value;
			}
		}

		/// <summary>
		/// Make a copy of ChannelInfo.
		/// </summary>
		/// <returns>ChannelInfo copy.</returns>
		public ChannelInfo Copy()
		{
			ChannelInfo destination = new ChannelInfo();
			destination.BanList = this.BanList;
			destination.ChannelName = this.ChannelName;
			destination.IsInvite = this.IsInvite;
			destination.IsModerated = this.IsModerated;
			destination.IsNotAcceptExternalMessages = this.IsNotAcceptExternalMessages;
			destination.IsOnlyOpsSetTopic = this.IsOnlyOpsSetTopic;
			destination.IsPrivate = this.IsPrivate;
			destination.IsSecret = this.IsSecret;
			destination.Key = this.Key;
			destination.Limit = this.Limit;
			destination.Topics = this.Topics;
			return destination;
		}
		/// <summary>
		/// Base contructor of ChannelInfo class.
		/// </summary>
		public ChannelInfo()
		{
			this.Topics = new ArrayList();
			this.Key = "";
			this.Limit = "";
			this.BanList = new BanList();
		}
	}
}
