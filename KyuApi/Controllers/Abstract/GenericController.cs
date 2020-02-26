using System;
using KyuApi.Controllers.Interfaces;
using KyuApi.Data.Entities.Interfaces;
using KyuApi.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KyuApi.Controllers.Abstract
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
