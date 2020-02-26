using System;
using System.Collections.Generic;
using System.Linq;
using KyuApi.Data.Entities.Interfaces;
using KyuApi.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KyuApi.Data.Repositories.Abstract
{
	public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
	{
		private readonly KyuContext _context;
		public Repository(KyuContext context)
		{
			_context = context;
		}
		public IEnumerable<TEntity> All()
		{
			return _context.Set<TEntity>().AsEnumerable();
		}

		public IEnumerable<TEntity> Filter(Func<TEntity, bool> clause)
		{
			return _context.Set<TEntity>().Where(clause).AsEnumerable();
		}

		public IQueryable<TEntity> Query()
		{
			return _context.Set<TEntity>();
		}

		public TEntity Find(TId id)
		{
			return _context.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
		}

		private TEntity SaveReturn(EntityEntry<TEntity> tracking)
		{
			_context.SaveChanges();
			return tracking.Entity;
		}

		public TEntity Create(TEntity entity)
		{
			return _context.Add(entity).Entity;
		}

		public TEntity CreateSave(TEntity entity)
		{
			return SaveReturn(_context.Add(entity));
		}

		public void CreateRange(IEnumerable<TEntity> entities)
		{
			_context.AddRange(entities);
		}

		public void CreateRangeSave(IEnumerable<TEntity> entities)
		{
			_context.AddRange(entities);
			_context.SaveChanges();
		}

		public TEntity Update(TEntity entity)
		{
			return _context.Update(entity).Entity;
		}

		public TEntity UpdateSave(TEntity entity)
		{
			return SaveReturn(_context.Update(entity));
		}

		public void UpdateRange(IEnumerable<TEntity> entities)
		{
			_context.UpdateRange(entities);
		}

		public void UpdateRangeSave(IEnumerable<TEntity> entities)
		{
			_context.UpdateRange(entities);
			_context.SaveChanges();
		}

		public TEntity Delete(TEntity entity)
		{
			return _context.Remove(entity).Entity;
		}

		public TEntity DeleteSave(TEntity entity)
		{
			return SaveReturn(_context.Remove(entity));
		}

		public TEntity Delete(TId id)
		{
			var e = Find(id);
			return e != null ? Delete(e) : null;
		}

		public TEntity DeleteSave(TId id)
		{
			var e = Find(id);
			return e != null ? DeleteSave(e) : null;
		}

		public void DeleteRange(IEnumerable<TEntity> entities)
		{
			_context.RemoveRange(entities);
		}

		public void DeleteRangeSave(IEnumerable<TEntity> entities)
		{
			_context.RemoveRange(entities);
			_context.SaveChanges();
		}
	}
}
