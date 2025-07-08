using App.Domain.Entities;

namespace App.Application.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        public Task<List<Country>> GetAllCountryAsync();
    }
}
