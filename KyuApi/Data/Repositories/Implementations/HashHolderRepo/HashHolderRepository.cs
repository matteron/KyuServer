using KyuApi.Data.Entities;
using KyuApi.Data.Repositories.Abstract;

namespace KyuApi.Data.Repositories.Implementations.HashHolderRepo
{
	public class HashHolderRepository : Repository<HashHolder, int>,IHashHolderRepository
	{
		public HashHolderRepository(KyuContext context) : base(context)
		{
		}
	}
}
