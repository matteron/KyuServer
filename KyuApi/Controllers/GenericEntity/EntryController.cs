using System;
using KyuApi.Controllers.Abstract;
using KyuApi.Data.Entities;
using KyuApi.Data.Repositories.Interfaces;

namespace KyuApi.Controllers.GenericEntity
{
	public class EntryController : GenericController<Entry, Guid>
	{
		private readonly IRepositoryWrapper _repo;

		public EntryController(IRepositoryWrapper repo) : base(repo)
		{
			_repo = repo;
		}
	}
}
