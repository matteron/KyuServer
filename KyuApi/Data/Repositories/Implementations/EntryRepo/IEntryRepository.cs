using System;
using KyuApi.Data.Entities;
using KyuApi.Data.Repositories.Interfaces;

namespace KyuApi.Data.Repositories.Implementations.EntryRepo
{
	public interface IEntryRepository : IRepository<Entry, Guid>
	{
	}
}
