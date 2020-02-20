using System;
using AggApi.Data.Entities;
using AggApi.Data.Repositories.Abstract;

namespace AggApi.Data.Repositories.Implementations.EntryRepo
{
	public class EntryRepository : Repository<Entry, Guid>, IEntryRepository
	{
		public EntryRepository(KyuContext context) : base(context)
		{
		}
	}
}
