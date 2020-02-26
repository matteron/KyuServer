using KyuApi.Data.Entities.TypeTables;
using KyuApi.Data.Repositories.Abstract;

namespace KyuApi.Data.Repositories.Implementations.EntryTypeRepo
{
	public class EntryTypeRepository : Repository<EntryType, int>, IEntryTypeRepository
	{
		public EntryTypeRepository(KyuContext context) : base(context)
		{
		}
	}
}
