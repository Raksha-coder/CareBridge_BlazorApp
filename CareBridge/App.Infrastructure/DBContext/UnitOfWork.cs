using App.Application.Interfaces;
using App.Application.Interfaces.Repositories;
using App.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.DBContext
{
    public sealed class UnitOfWork<TContext>(TContext context, ILogger<UnitOfWork<TContext>> logger, AppDbContext dbcontext) : IUnitOfWork where TContext : DbContext
    {
        private readonly AppDbContext _dbcontext = dbcontext;
        private readonly TContext _context = context;
        private readonly ILogger<UnitOfWork<TContext>> _logger = logger;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                _logger.LogError(dbUpdateException, "An error occured during commiting changes");
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_dbcontext);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
