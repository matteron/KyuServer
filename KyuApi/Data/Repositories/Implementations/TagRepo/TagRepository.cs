using KyuApi.Data.Entities.TypeTables;
using KyuApi.Data.Repositories.Abstract;

namespace KyuApi.Data.Repositories.Implementations.TagRepo
{
    public class TagRepository : Repository<Tag, int>, ITagRepository
    {
        public TagRepository(KyuContext context) : base(context)
        {
        }
    }
}