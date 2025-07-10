using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;


        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountryAsync()
        {
            var result = await _context.Country.ToListAsync();

            if (result == null)
            {
                throw new Exception("No Country Found");
            }

            return result;
        }
    }
}
