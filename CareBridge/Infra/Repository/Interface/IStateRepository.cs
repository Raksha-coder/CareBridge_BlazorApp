using Domain.DataModel.Entity;
using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interface
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllStatesAsync();

        Task<JsonModel> GetStateByCountryIdAsync(int id);
    }
}
