using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Controllers.Abstract;
using KyuApi.Data.Entities.TypeTables;
using KyuApi.Data.Repositories.Interfaces;

namespace KyuApi.Controllers.GenericEntity
{
	public class EntryStatusController : GenericController<EntryStatus, int>
	{
		public EntryStatusController(IRepositoryWrapper repo) : base(repo)
		{
		}
	}
}
