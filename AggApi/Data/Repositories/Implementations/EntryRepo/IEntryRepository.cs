using System;
using AggApi.Data.Entities;
using AggApi.Data.Repositories.Interfaces;

namespace AggApi.Data.Repositories.Implementations.EntryRepo
{
	public interface IEntryRepository : IRepository<Entry, Guid>
	{
	}
}
