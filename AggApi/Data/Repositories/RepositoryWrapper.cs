using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities;
using AggApi.Data.Entities.Interfaces;
using AggApi.Data.Entities.TypeTables;
using AggApi.Data.Repositories.Implementations.EntryRepo;
using AggApi.Data.Repositories.Implementations.EntryTypeRepo;
using AggApi.Data.Repositories.Interfaces;
using Type = System.Type;

namespace AggApi.Data.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private readonly KyuContext _context;
		private IEntryRepository _entry;
		private IEntryTypeRepository _entryType;

		public IEntryRepository Entry
		{
			get { return _entry ??= new EntryRepository(_context); }
		}

		public IEntryTypeRepository EntryType
		{
			get { return _entryType ??= new EntryTypeRepository(_context); }
		}

		public RepositoryWrapper(KyuContext context)
		{
			_context = context;
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public IRepository<TEntity, TKey> Specify<TEntity, TKey>() where TEntity : IEntity<TKey>
		{
			var type = typeof(TEntity);
			if (type == typeof(Entry))
			{
				return (IRepository<TEntity, TKey>)Entry;
			}

			if (type == typeof(EntryType))
			{
				return (IRepository<TEntity, TKey>)EntryType;
			}

			return null;
		}
	}
}
