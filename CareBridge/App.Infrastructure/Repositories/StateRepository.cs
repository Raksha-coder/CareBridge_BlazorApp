using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<StateRepository> _logger;
        public StateRepository(AppDbContext context, ILogger<StateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<State>> GetAllStatesAsync()
        {
            try
            {
                var getAllStates = await _context.State.ToListAsync();

                if (getAllStates == null)
                {
                    _logger.LogError("No State Found.");
                    throw new Exception("No State Found");
                }
                _logger.LogInformation("Successfully fetched all states.");
                return getAllStates;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllStatesAsync");
                throw new Exception("An error occurred while fetching state data.");
            }
        }

        public async Task<JsonResponseDto> GetStateByCountryIdAsync(int id)
        {
            try
            {
                var getStateByCountryId = await _context.State.Where(a => a.CountryId == id).ToListAsync();

                if (getStateByCountryId != null)
                {
                    _logger.LogInformation("Retrived list of State.");
                    return new JsonResponseDto(200, "State List", getStateByCountryId);
                }
                _logger.LogWarning("No State Found for the provided Country ID.");
                return new JsonResponseDto(404, "No State Found for this Country", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetStateByCountryIdAsync");
                throw new Exception("An error occurred while fetching state data.");
            }
        }
    }
}
