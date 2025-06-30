using App.Core.Interface;
using Domain.DataModel.Entity;
using Domain.ReponseModel;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public Task<List<State>> GetAllStatesAsync()
        {
            return _stateRepository.GetAllStatesAsync();
        }

        public Task<JsonModel> GetStateByCountryIdAsync(int id)
        {
            return _stateRepository.GetStateByCountryIdAsync(id);
        }
    }
}
