using KyuApi.Data.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KyuApi.Controllers.Interfaces
{
	public interface IGenericController<in TEntity, in TId> where TEntity: IEntity<TId>
	{
		public IActionResult All();
		public IActionResult Find(TId id);
		public IActionResult Create(TEntity entity);
	}
}
