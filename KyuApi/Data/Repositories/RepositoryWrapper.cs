using KyuApi.Data.Entities;
using KyuApi.Data.Entities.Interfaces;
using KyuApi.Data.Entities.TypeTables;
using KyuApi.Data.Repositories.Implementations.EntryRepo;
using KyuApi.Data.Repositories.Implementations.EntryStatusRepo;
using KyuApi.Data.Repositories.Implementations.EntryTypeRepo;
using KyuApi.Data.Repositories.Interfaces;

namespace KyuApi.Data.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private readonly KyuContext _context;
		private IEntryRepository _entry;
		private IEntryTypeRepository _entryType;
		private IEntryStatusRepository _entryStatus;

		public IEntryRepository Entry
		{
			get { return _entry ??= new EntryRepository(_context); }
		}

		public IEntryTypeRepository EntryType
		{
			get { return _entryType ??= new EntryTypeRepository(_context); }
		}

		public IEntryStatusRepository EntryStatus
		{
			get { return _entryStatus ??= new EntryStatusRepository(_context); }
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
				return (IRepository<TEntity, TKey>) EntryType;
			}

			if (type == typeof(EntryStatus))
			{
				return (IRepository<TEntity, TKey>) EntryStatus;
			}

			return null;
		}
	}
}
