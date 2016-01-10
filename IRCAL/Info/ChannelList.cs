using System;

namespace myIRC
{
	/// <summary>
	/// Summary description for ChannelList.
	/// </summary>
	public class ChannelList : System.Collections.CollectionBase
	{
		public ChannelList()
		{

		}

		/// <summary>
		/// Add a new BanListItem to the Collection
		/// </summary>
		/// <param name="value">BanListItem class</param>
		public void Add(ChannelListItem value)
		{
			this.List.Add(value as object);
		}

		/// <summary>
		/// Remove a BanListItem from the Collection
		/// </summary>
		/// <param name="value">BanListItem to remove</param>
		public void Remove(ChannelListItem value)
		{
			this.List.Remove(value as object);
		}

		/// <summary>
		/// Determine if the BanListItem is in the Collection
		/// </summary>
		/// <param name="value">Enemy class</param>
		/// <returns>true or false</returns>
		public bool Contains(ChannelListItem value)
		{
			return this.List.Contains(value as object);
		}

		/// <summary>
		/// Gets or sets a BanListItem at specified index
		/// </summary>
		public ChannelListItem this[int index]
		{
			get
			{
				return (List[index] as ChannelListItem);
			}
			set
			{
				List[index] = value as object;
			}
		}
	}
}
