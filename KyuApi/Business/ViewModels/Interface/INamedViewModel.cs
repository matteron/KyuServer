using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Business.ViewModels.Interface
{
	public interface INamedViewModel<TEntity> where TEntity: INamed
	{
		public string Name { get; set; }
	}
}
