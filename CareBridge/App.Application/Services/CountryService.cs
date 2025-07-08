using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;

namespace App.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Task<List<Country>> GetAllCountryAsync()
        {
            return _countryRepository.GetAllCountryAsync();
        }
    }
}
