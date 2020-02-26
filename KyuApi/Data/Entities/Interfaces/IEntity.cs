namespace KyuApi.Data.Entities.Interfaces
{
	public interface IEntity<out TKey>
	{
		TKey Id { get; }
	}
}
