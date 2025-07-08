using App.Application.DTOs;
using App.Domain.Entities;

namespace App.Application.Interfaces.Services
{
    public interface IStateService
    {
        public Task<List<State>> GetAllStatesAsync();
        public Task<JsonResponseDto> GetStateByCountryIdAsync(int id);
    }
}
