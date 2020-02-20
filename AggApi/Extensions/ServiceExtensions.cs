using System;
using System.Linq;
using AggApi.Data.Constants;
using AggApi.Data.Entities.TypeTables;
using AggApi.Data.Repositories;
using AggApi.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AggApi.Extensions
{
	public static class ServiceExtensions
	{
		public static void AddRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}

		public static void CreateEntryTypes(this IServiceProvider serv)
		{
			var repo = serv.GetRequiredService<RepositoryWrapper>();
			var all = EntryTypeNames.All;
			var existing = repo.EntryType.Query().Where(et => all.Contains(et.Name)).ToList();
			if (existing.Count == all.Count)
			{
				return;
			}
			
		}
	}
}
