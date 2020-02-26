using KyuApi.Controllers.Abstract;
using KyuApi.Data.Entities.TypeTables;
using KyuApi.Data.Repositories.Interfaces;

namespace KyuApi.Controllers.GenericEntity
{
	public class EntryTypeController : GenericController<EntryType, int>
	{
		private readonly IRepositoryWrapper _repo;

		public EntryTypeController(IRepositoryWrapper repo) : base(repo)
		{
			_repo = repo;
		}
	}
}
