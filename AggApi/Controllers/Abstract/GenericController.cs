using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Controllers.Interfaces;
using AggApi.Data.Entities.Interfaces;
using AggApi.Data.Repositories.Abstract;
using AggApi.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AggApi.Controllers.Abstract
{
	[ApiController]
	[Route("[controller]")]
	public abstract class GenericController<TEntity, TKey> : ControllerBase, IGenericController<TEntity, TKey> where TEntity : class, IEntity<TKey>
	{
		private readonly IRepositoryWrapper _repo;

		protected GenericController(IRepositoryWrapper repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public IActionResult All()
		{
			return Ok(_repo.Specify<TEntity, TKey>().All());
		}

		[HttpGet("/id:TId")]
		public IActionResult Find(TKey id)
		{
			var e = _repo.Specify<TEntity, TKey>().Find(id);
			if (e == null)
			{
				return BadRequest("Entity not found.");
			}

			return Ok(e);
		}

		[HttpPost]
		public IActionResult Create([FromBody]TEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
