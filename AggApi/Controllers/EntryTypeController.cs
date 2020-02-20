using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Controllers.Abstract;
using AggApi.Data.Entities.TypeTables;
using AggApi.Data.Repositories.Interfaces;

namespace AggApi.Controllers
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
