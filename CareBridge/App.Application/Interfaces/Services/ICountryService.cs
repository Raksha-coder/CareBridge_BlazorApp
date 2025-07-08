using App.Domain.Entities;

namespace App.Application.Interfaces.Services
{
    public interface ICountryService
    {
        public Task<List<Country>> GetAllCountryAsync();
    }
}
