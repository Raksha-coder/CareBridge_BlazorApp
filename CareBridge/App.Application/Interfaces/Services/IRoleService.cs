using App.Domain.Entities;

namespace App.Application.Interfaces.Services
{
    public interface IRoleService
    {
        public Task<List<Role>> GetAllRoleAsync();
    }
}
