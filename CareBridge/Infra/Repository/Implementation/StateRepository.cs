using Domain.DataModel.Entity;
using Domain.ReponseModel;
using Infra.Context;
using Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Implementation
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<State>> GetAllStatesAsync()
        {
            var getAllStates = await _context.State.ToListAsync();

            if (getAllStates == null)
            {
                throw new Exception("No State Found");
            }
            return getAllStates;
        }

        public async Task<JsonModel> GetStateByCountryIdAsync(int id)
        {
            var getStateByCountryId = await _context.State.Where(a => a.CountryId == id).ToListAsync();

            if (getStateByCountryId != null)
            {
                return new JsonModel(200, "State List", getStateByCountryId);
            }
            return new JsonModel(404, "No State Found for this Country", null);
        }
    }
}
