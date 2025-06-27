using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interface
{
    public interface IStateService
    {
        public Task<JsonModel> GetAllStatesAsync();
        public Task<JsonModel> GetStateByCountryIdAsync(int id);

    }
}
