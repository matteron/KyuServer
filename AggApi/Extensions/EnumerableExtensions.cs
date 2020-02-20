using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AggApi.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach (var item in enumeration)
			{
				action(item);
				yield return item;
			}
		}
	}
}
