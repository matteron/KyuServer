using KyuApi.Business.ViewModels.Interface;
using KyuApi.Data.Entities.Abstract;

namespace KyuApi.Business.ViewModels.Abstract
{
	public abstract class IntEntityViewModel<TEntity> : IEntityViewModel<TEntity, int> where TEntity : IntEntity
	{
		public int Id { get; set; }
	}
}
