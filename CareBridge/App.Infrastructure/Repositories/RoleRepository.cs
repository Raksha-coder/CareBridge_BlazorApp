using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllRoleAsync()
        {
            var getAllRole = await _context.Role.ToListAsync();

            if (getAllRole == null)
            {
                throw new Exception("No Role Found");
            }
            return getAllRole;
        }
    }
}
