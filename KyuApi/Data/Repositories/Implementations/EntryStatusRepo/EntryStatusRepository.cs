using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Data.Entities.TypeTables;
using KyuApi.Data.Repositories.Abstract;

namespace KyuApi.Data.Repositories.Implementations.EntryStatusRepo
{
	public class EntryStatusRepository : Repository<EntryStatus, int>, IEntryStatusRepository
	{
		public EntryStatusRepository(KyuContext context) : base(context)
		{
		}
	}
}
