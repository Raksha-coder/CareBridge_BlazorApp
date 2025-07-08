using App.Application.DTOs;
using App.Domain.Entities;

namespace App.Application.Interfaces.Repositories
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStatesAsync();

        Task<JsonResponseDto> GetStateByCountryIdAsync(int id);
    }
}
