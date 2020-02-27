using System;
using System.Collections.Generic;
using System.Linq;
using KyuApi.Business.ViewModels.Requests;
using KyuApi.Data.Entities;
using KyuApi.Data.Entities.Navigation;

namespace KyuApi.Business.Mappers
{
    public static class RequestMappers
    {
        public static Entry Map(this EntryRequest source) 
        {
            return new Entry
            {
                Title = source.Title,
                Body = source.Body,
                CreateDate = DateTime.Now,
                EntryStatusId = 1,
                EntryTypeId = source.Type,

            };
        }

        public static IEnumerable<EntryTag> CreateLinks(this IEnumerable<int> source, Entry entity)
        {
            return source.Select(t => new EntryTag 
            {
                TagId = t,
                EntryId = entity.Id
            });
        }
    }
}