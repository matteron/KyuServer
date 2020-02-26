using System;
using System.Collections.Generic;
using System.Linq;
using KyuApi.Data.Constants;
using KyuApi.Data.Entities.Abstract;
using KyuApi.Data.Entities.TypeTables;
using KyuApi.Data.Repositories;
using KyuApi.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KyuApi.Extensions
{
	public static class ServiceExtensions
	{
		public static void AddRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}

		private static void CreateTableType<TEntity>(this IServiceProvider serv, List<string> names) where TEntity: TypeTable, new()
		{
			var repo = serv.GetRequiredService<IRepositoryWrapper>().Specify<TEntity, int>();
			var existing = repo.Query().Where(et => names.Contains(et.Name)).Select(et => et.Name).ToList();
			if (existing.Count() == names.Count)
			{
				return;
			}

			var toAdd = names.Where(a => !existing.Contains(a)).Select(a => new TEntity
			{
				Name = a
			}).ToList();
			repo.CreateRangeSave(toAdd);
		}

		public static void CreateEntryTypes(this IServiceProvider serv)
		{
			var all = new List<string>
			{
				DefaultEntryTypes.Note,
				DefaultEntryTypes.Link,
				DefaultEntryTypes.Book,
				DefaultEntryTypes.Show,
				DefaultEntryTypes.Movie,
				DefaultEntryTypes.Music
			};
			serv.CreateTableType<EntryType>(all);
		}

		public static void CreateEntryStatuses(this IServiceProvider serv)
		{
			var all = new List<string>
			{
				DefaultEntryStatuses.Pending,
				DefaultEntryStatuses.Active,
				DefaultEntryStatuses.Complete
			};
			serv.CreateTableType<EntryStatus>(all);
		}
	}
}
