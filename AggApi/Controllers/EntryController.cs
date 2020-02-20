using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Controllers.Abstract;
using AggApi.Data.Entities;
using AggApi.Data.Repositories;
using AggApi.Data.Repositories.Abstract;
using AggApi.Data.Repositories.Implementations.EntryRepo;
using AggApi.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AggApi.Controllers
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
