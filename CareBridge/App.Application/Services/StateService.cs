using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;

namespace App.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public Task<List<State>> GetAllStatesAsync()
        {
            return _stateRepository.GetAllStatesAsync();
        }

        public Task<JsonResponseDto> GetStateByCountryIdAsync(int id)
        {
            return _stateRepository.GetStateByCountryIdAsync(id);
        }
    }
}
