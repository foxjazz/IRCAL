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
	/// The banlist stored in a Collection.
	/// </summary>
	public class BanList : System.Collections.CollectionBase
	{
		/// <summary>
		/// Base Constructor of BanList Collection.
		/// </summary>
		public BanList()
		{

		}

		/// <summary>
		/// Add a new BanListItem to the Collection
		/// </summary>
		/// <param name="value">BanListItem class</param>
		public void Add(BanListItem value)
		{
			this.List.Add(value as object);
		}

		/// <summary>
		/// Remove a BanListItem from the Collection
		/// </summary>
		/// <param name="value">BanListItem to remove</param>
		public void Remove(BanListItem value)
		{
			this.List.Remove(value as object);
		}

		/// <summary>
		/// Determine if the BanListItem is in the Collection
		/// </summary>
		/// <param name="value">Enemy class</param>
		/// <returns>true or false</returns>
		public bool Contains(BanListItem value)
		{
			return this.List.Contains(value as object);
		}

		/// <summary>
		/// Gets or sets a BanListItem at specified index
		/// </summary>
		public BanListItem this[int index]
		{
			get
			{
				return (List[index] as BanListItem);
			}
			set
			{
				List[index] = value as object;
			}
		}
	}
}
