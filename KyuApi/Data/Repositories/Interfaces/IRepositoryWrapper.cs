using KyuApi.Data.Entities.Interfaces;
using KyuApi.Data.Repositories.Implementations.EntryRepo;
using KyuApi.Data.Repositories.Implementations.EntryStatusRepo;
using KyuApi.Data.Repositories.Implementations.EntryTagRepo;
using KyuApi.Data.Repositories.Implementations.EntryTypeRepo;
using KyuApi.Data.Repositories.Implementations.HashHolderRepo;
using KyuApi.Data.Repositories.Implementations.TagRepo;

namespace KyuApi.Data.Repositories.Interfaces
{
	public interface IRepositoryWrapper
	{
		IEntryRepository Entry { get; }
		IEntryTypeRepository EntryType { get; }
		IEntryStatusRepository EntryStatus { get; }
		IEntryTagRepository EntryTag { get; }
		ITagRepository Tag { get; }
		IHashHolderRepository HashHolder { get; }

		void Save();
		IRepository<TEntity, TKey> Specify<TEntity, TKey>() where TEntity : IEntity<TKey>;
	}
}
