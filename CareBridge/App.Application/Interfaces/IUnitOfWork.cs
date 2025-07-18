using App.Application.Interfaces.Repositories;

namespace App.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<bool> CommitAsync();

        public IGenericRepository<T> GenericRepository<T>() where T : class;
    }
}
