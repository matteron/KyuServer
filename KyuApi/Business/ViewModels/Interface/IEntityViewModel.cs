using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Business.ViewModels.Interface
{
	public interface IEntityViewModel<TEntity, TKey> where TEntity: IEntity<TKey>
	{
		public TKey Id { get; set; }
	}
}
