using System;
using System.Collections.Generic;
using System.Linq;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Data.Repositories.Interfaces
{
	public interface IRepository<TEntity, in TId> where TEntity: IEntity<TId>
	{
		IEnumerable<TEntity> All();
		IEnumerable<TEntity> Filter(Func<TEntity, bool> clause);
		IQueryable<TEntity> Query();
		TEntity Find(TId id);
		TEntity Create(TEntity entity);
		TEntity CreateSave(TEntity entity);
		void CreateRange(IEnumerable<TEntity> entities);
		void CreateRangeSave(IEnumerable<TEntity> entities);
		TEntity Update(TEntity entity);
		TEntity UpdateSave(TEntity entity);
		void UpdateRange(IEnumerable<TEntity> entities);
		void UpdateRangeSave(IEnumerable<TEntity> entities);
		TEntity Delete(TEntity entity);
		TEntity DeleteSave(TEntity entity);
		TEntity Delete(TId id);
		TEntity DeleteSave(TId id);
		void DeleteRange(IEnumerable<TEntity> entities);
		void DeleteRangeSave(IEnumerable<TEntity> entities);
	}
}
