using Domain.ReponseModel;
using Infra.Context;
using Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JsonModel> GetAllCountryAsync()
        {
            var getAllCountry = await _context.Country.ToListAsync();

            if (getAllCountry != null)
            {
                return new JsonModel(200, "Country List", getAllCountry);
            }
            return new JsonModel(404, "No Country Found", null);
        }
    }
}
