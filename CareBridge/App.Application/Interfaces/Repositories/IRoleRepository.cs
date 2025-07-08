using App.Domain.Entities;

namespace App.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoleAsync();
    }
}
