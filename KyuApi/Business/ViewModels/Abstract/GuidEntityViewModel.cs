using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Business.ViewModels.Interface;
using KyuApi.Data.Entities.Abstract;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Business.ViewModels.Abstract
{
	public abstract class GuidEntityViewModel<TEntity> : IEntityViewModel<TEntity, Guid> where TEntity : GuidEntity
	{
		public Guid Id { get; set; }
	}
}
