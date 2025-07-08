using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
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

        public async Task<JsonResponseDto> GetStateByCountryIdAsync(int id)
        {
            var getStateByCountryId = await _context.State.Where(a => a.CountryId == id).ToListAsync();

            if (getStateByCountryId != null)
            {
                return new JsonResponseDto(200, "State List", getStateByCountryId);
            }
            return new JsonResponseDto(404, "No State Found for this Country", null);
        }
    }
}
