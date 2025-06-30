using App.Core.Dtos;
using Domain.DataModel.Entity;
using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interface
{
    public interface ICountryRepository
    {
        public Task<List<Country>> GetAllCountryAsync();
    }
}
