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
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace myIRC
{
	/// <summary>
	/// Static Utility Services used in all the project
	/// </summary>
	public class UtilityService
	{
		/// <summary>
		/// Static string used to store the CRLF bytes.
		/// </summary>
		public static readonly string CrLf = "\r\n";
		/// <summary>
		/// Hold the character used in CTCP messages
		/// </summary>
		public static readonly string CTCPMarker = "\u0001";

		/// <summary>
		/// The character used for color message.
		/// </summary>
		public static readonly string ColorMarker = "\u0003";
		private static DateTime Epoch = new DateTime(1970, 1, 1);
		/// <summary>
		/// Static string that hold the contributors of Aeru IRC project
		/// </summary>
		public static readonly string Contributors = "Michal Larouche(shock@shockdev.ca.tc)\nAlex Egg(eggie5@techline.com)\nWilliam Myatt(bmyatt99@msn.com)\n�tienne Gosselin(burger100@hotmail.com)\nMartin L�vesque(0240852@cstjean.qc.ca)";

		// Version system, based on Linux Kernel Versionning: 
		// Major, Minor(Instable(Impair) or Stable(Pair)), Revision, Class(Alpha(Programmer Version), Beta(Expert user Version), Zeta(ENDUSER friendly), Nu(Final)) 
		private static readonly string Major = "0";
		private static readonly string Minor = "3";
		private static readonly string Revision = "0";
		private static readonly string Class = "Alpha";

		/// <summary>
		/// Returns the complete Aeru IRC Version string.
		/// </summary>
		public static string AeruIRCVersion
		{
			get
			{
				string version = Major+"."+Minor+"."+Revision+" "+Class;
				return version;
			}
		}
		/// <summary>
		/// Holds the version string returned by CTCP VERSION.
		/// </summary>
		public static readonly string CTCPVersion = "Aeru IRC "+ AeruIRCVersion + " - http://aeruirc.sourceforge.net";

		/// <summary>
		/// Function to join an array of strings splitted by a white space in a specific index
		/// </summary>
		/// <param name="msg">string[] array</param>
		/// <param name="index">Index to Start</param>
		/// <param name="Length">Length of the string[] array</param>
		/// <returns>Joined string</returns>
		public static string JoinString(string[] msg, int index, int Length)
		{
			string joinstring = "";
			for(int i=index;i<Length;i++)
			{
				if(i==index)
				{
					joinstring += msg[i];
				}
				else
				{
					joinstring = joinstring + " " + msg[i];
				}
			}
			return joinstring;
		}

		/// <summary>
		/// Method to convert .NET DateTime to UNIX Timeswap(ctime).
		/// </summary>
		/// <param name="value">DateTime class to convert.</param>
		public static string ConvertDateTimeToCtime(DateTime value)
		{
			TimeSpan span = value - Epoch;
			int ctime = Convert.ToInt32(span.TotalSeconds);
			return ctime.ToString();
		}

		/// <summary>
		/// Method to convert UNIX Timeswap to .NET DateTime.
		/// </summary>
		/// <param name="value">ctime in a string.</param>
		public static DateTime ConvertCtimeToDateTime(string value)
		{
			DateTime convertedtime = Epoch.AddSeconds(Convert.ToDouble(value));
			return convertedtime;
		}

		public static string ExtractFilePath(string fullpath)
		{
			int index = fullpath.LastIndexOf("\\") + 1;
			string path = fullpath.Remove(index, fullpath.Length - index);
			return path;
		}

		/// <summary>
		/// Come from Sharkbite's IRC Library
		/// </summary>
		/// <param name="hostorderlong"></param>
		/// <returns></returns>
		public static long GetNetworkUnsignedLong(long hostorderlong)
		{
			long networklong = IPAddress.HostToNetworkOrder( hostorderlong );
			//Network order has the octets in reverse order starting with byte 7
			//To get the correct string simply shift them down 4 bytes
			//and zero out the first 4 bytes.
			return (networklong >> 32 ) & 0x00000000ffffffff;
		}

		/// <summary>
		/// Convert a long IP address to a network-ordered IP address.
		/// </summary>
		/// <param name="ipaddress">Source IP address.</param>
		/// <returns>Network-ordered IP address.</returns>
		public static long ConvertIPAddress(long ipaddress) 
		{
			MemoryStream memstream = new MemoryStream();
			int address1 = Convert.ToInt32(ipaddress/65536);
			int address2 = Convert.ToInt32(ipaddress%65536);
			int address_1 = address1/256;
			int address_2 = address1%256;
			int address_3 = address2/256;
			int address_4 = address2%256;
			memstream.WriteByte(Convert.ToByte(address_1));
			memstream.WriteByte(Convert.ToByte(address_2));
			memstream.WriteByte(Convert.ToByte(address_3));
			memstream.WriteByte(Convert.ToByte(address_4));
			BinaryReader br = new BinaryReader(memstream);
			try
			{
				memstream.Seek(0, SeekOrigin.Begin);
				uint tempaddress = br.ReadUInt32();
				long newaddress = Convert.ToInt64(tempaddress);
				return newaddress;
			}
			catch(Exception)
			{

			}
			return 0;
		}
	}
}
