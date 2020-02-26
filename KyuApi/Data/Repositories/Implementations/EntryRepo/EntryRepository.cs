using System;
using KyuApi.Data.Entities;
using KyuApi.Data.Repositories.Abstract;

namespace KyuApi.Data.Repositories.Implementations.EntryRepo
{
	public class EntryRepository : Repository<Entry, Guid>, IEntryRepository
	{
		public EntryRepository(KyuContext context) : base(context)
		{
		}
	}
}
