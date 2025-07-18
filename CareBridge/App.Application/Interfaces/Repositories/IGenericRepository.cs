using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync<T>(int id) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T> AddAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
        Task<T> DeleteAsync<T>(int id) where T : class;
    }
}
