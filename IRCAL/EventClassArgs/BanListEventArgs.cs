using System;

namespace myIRC
{
	/// <summary>
	/// BanListEventArgs store the information for deploying BanListItem.
	/// </summary>
	public class BanListEventArgs
	{
		private string m_channel;
		private BanListItem m_item;

		/// <summary>
		/// Gets the channel where the banlist is from.
		/// </summary>
		public string Channel
		{
			get
			{
				return m_channel;
			}
		}

		/// <summary>
		/// Gets the BanListItem.
		/// </summary>
		public BanListItem BanListItem
		{
			get
			{
				return m_item;
			}
		}

		/// <summary>
		/// Build a BanListEventArgs
		/// </summary>
		/// <param name="channel">Channel destination.</param>
		/// <param name="item">BanListItem to add.</param>
		public BanListEventArgs(string channel, BanListItem item)
		{
			this.m_channel = channel;
			this.m_item = item;
		}
	}
}
