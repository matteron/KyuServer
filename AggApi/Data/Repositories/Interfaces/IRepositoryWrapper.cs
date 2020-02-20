using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities.Interfaces;
using AggApi.Data.Repositories.Implementations.EntryRepo;
using AggApi.Data.Repositories.Implementations.EntryTypeRepo;

namespace AggApi.Data.Repositories.Interfaces
{
	public interface IRepositoryWrapper
	{
		IEntryRepository Entry { get; }
		IEntryTypeRepository EntryType { get; }

		void Save();
		IRepository<TEntity, TKey> Specify<TEntity, TKey>() where TEntity : IEntity<TKey>;
	}
}
