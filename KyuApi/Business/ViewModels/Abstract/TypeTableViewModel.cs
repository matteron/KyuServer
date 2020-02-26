using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KyuApi.Business.ViewModels.Interface;
using KyuApi.Data.Entities.Abstract;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Business.ViewModels.Abstract
{
	public class TypeTableViewModel<TEntity> : IntEntityViewModel<TEntity>, INamedViewModel<TEntity> where TEntity : TypeTable
	{
		public string Name { get; set; }
	}
}
