using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities.TypeTables;
using AggApi.Data.Repositories.Abstract;

namespace AggApi.Data.Repositories.Implementations.EntryTypeRepo
{
	public class EntryTypeRepository : Repository<EntryType, int>, IEntryTypeRepository
	{
		public EntryTypeRepository(KyuContext context) : base(context)
		{
		}
	}
}
