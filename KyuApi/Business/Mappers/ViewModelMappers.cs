using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Business.ViewModels;
using KyuApi.Business.ViewModels.Abstract;
using KyuApi.Data.Entities;
using KyuApi.Data.Entities.Abstract;
using KyuApi.Extensions;

namespace KyuApi.Business.Mappers
{
	public static class ViewModelMappers
	{
		public static TypeTableViewModel<TEntity> Map<TEntity>(this TEntity source) where TEntity : TypeTable
		{
			return new TypeTableViewModel<TEntity>
			{
				Id = source.Id,
				Name = source.Name
			};
		}

		public static IEnumerable<TypeTableViewModel<TEntity>> Map<TEntity>(this IEnumerable<TEntity> source) where TEntity : TypeTable
		{
			return source.Select(Map);
		}

		public static EntryViewModel Map(this Entry e) 
		{
			return new EntryViewModel
			{
				Id = e.Id,
				Title = e.Title,
				Body = e.Body,
				Status = e.EntryStatus.Map(),
				Type = e.EntryType.Map(),
				Tags = e.EntryTags.Select(et => et.Tag).Map()
			};
		}

		public static IEnumerable<EntryViewModel> MapEntries(this IQueryable<Entry> source)
		{
			return source.ViewModelIncludes().Select(Map);
		}
	}
}
