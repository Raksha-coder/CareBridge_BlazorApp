using App.Core.Dtos;
using Domain.DataModel.Entity;
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
