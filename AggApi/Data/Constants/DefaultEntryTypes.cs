using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AggApi.Data.Constants
{
	public static class EntryTypeNames
	{
		public static string Link { get; set; } = "Link";
		public static string Book { get; set; } = "Book";
		public static string Show { get; set; } = "Show";
		public static string Movie { get; set; } = "Movie";
		public static string Music { get; set; } = "Music";

		public static List<string> All = new List<string>
		{
			Link,
			Book,
			Show,
			Movie,
			Music
		};
	}
}
