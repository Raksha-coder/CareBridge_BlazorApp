using App.Core.Interface;
using Domain.ReponseModel;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public Task<JsonModel> GetAllCountryAsync()
        {
            return _countryRepository.GetAllCountryAsync();
        }
    }
}
