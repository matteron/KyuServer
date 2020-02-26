using KyuApi.Data.Entities.Interfaces;
using KyuApi.Data.Repositories.Implementations.EntryRepo;
using KyuApi.Data.Repositories.Implementations.EntryStatusRepo;
using KyuApi.Data.Repositories.Implementations.EntryTypeRepo;

namespace KyuApi.Data.Repositories.Interfaces
{
	public interface IRepositoryWrapper
	{
		IEntryRepository Entry { get; }
		IEntryTypeRepository EntryType { get; }
		IEntryStatusRepository EntryStatus { get; }

		void Save();
		IRepository<TEntity, TKey> Specify<TEntity, TKey>() where TEntity : IEntity<TKey>;
	}
}
