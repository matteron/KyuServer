using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KyuApi.Extensions
{
	public static class IncludeExtensions
	{
		public static IQueryable<Entry> ViewModelIncludes(this IQueryable<Entry> source)
		{
			return source
				.Include(e => e.EntryStatus)
				.Include(e => e.EntryType)
				.Include(e => e.EntryTags)
				.ThenInclude(et => et.Tag);
		}
	}
}
