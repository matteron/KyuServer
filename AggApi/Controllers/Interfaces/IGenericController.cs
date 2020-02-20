using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AggApi.Controllers.Interfaces
{
	public interface IGenericController<in TEntity, in TId> where TEntity: IEntity<TId>
	{
		public IActionResult All();
		public IActionResult Find(TId id);
		public IActionResult Create(TEntity entity);
	}
}
