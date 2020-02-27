using KyuApi.Data.Entities.Navigation;
using KyuApi.Data.Repositories.Abstract;

namespace KyuApi.Data.Repositories.Implementations.EntryTagRepo
{
    public class EntryTagRepository : Repository<EntryTag, int>, IEntryTagRepository
    {
        public EntryTagRepository(KyuContext context) : base(context)
        {
        }
    }
}