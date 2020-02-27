using KyuApi.Data.Repositories.Interfaces;

namespace KyuApi.Business.Services.Abstract
{
    public abstract class ApiService
    {
        protected readonly IRepositoryWrapper _repo;

        protected ApiService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
    }
}