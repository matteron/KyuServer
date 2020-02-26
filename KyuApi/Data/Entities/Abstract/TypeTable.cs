using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Data.Entities.Abstract
{
	public class TypeTable : IntEntity, INamed
	{
		public string Name { get; set; }
	}
}
