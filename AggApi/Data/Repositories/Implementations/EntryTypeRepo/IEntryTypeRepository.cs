using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities.TypeTables;
using AggApi.Data.Repositories.Interfaces;

namespace AggApi.Data.Repositories.Implementations.EntryTypeRepo
{
	public interface IEntryTypeRepository : IRepository<EntryType, int>
	{
	}
}
