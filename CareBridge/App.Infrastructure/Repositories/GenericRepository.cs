using App.Application.Interfaces.Repositories;
using App.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace App.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet; // <T>
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public async Task<T> AddAsync<T>(T entity) where T : class
        {
            // what should i write here?
            // when ever the new entity is added first it has to check in the database if the entity already exists or not
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
            {
                throw new InvalidOperationException("Entity does not have an 'Id' property.");
            }
            var idValue = idProperty.GetValue(entity);
            var existingEntity = await _context.Set<T>().FindAsync(idValue);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("Entity with the same Id already exists.");
            }

            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<T> DeleteAsync<T>(int id) where T : class
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception("No Data Found");
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            var result = await _context.Set<T>().ToListAsync();

            if (result == null || result.Count == 0)
            {
                throw new Exception("No Data Found");
            }
            return result;
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result == null)
            {
                throw new Exception("No Data Found");
            }
            return result;
        }

        public Task<T> UpdateAsync<T>(T entity) where T : class
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
            {
                throw new InvalidOperationException("Entity does not have an 'Id' property.");
            }
            var idValue = idProperty.GetValue(entity);
            var existingEntity = _context.Set<T>().Find(idValue);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("Entity with the same Id does not exist.");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }
    }
}
