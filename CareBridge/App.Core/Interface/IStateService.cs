using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DataModel.Entity;

namespace App.Core.Interface
{
    public interface IStateService
    {
        public Task<List<State>> GetAllStatesAsync();
        public Task<JsonModel> GetStateByCountryIdAsync(int id);

    }
}
