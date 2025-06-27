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
        Task<JsonModel> GetAllStatesAsync();

        Task<JsonModel> GetStateByCountryIdAsync(int id);
    }
}
