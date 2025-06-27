using Domain.ReponseModel;
using Infra.Context;
using Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JsonModel> GetAllRoleAsync()
        {
            var getAllRole = await _context.Role.ToListAsync();

            if (getAllRole != null)
            {
                return new JsonModel(200, "Role List", getAllRole);
            }
            return new JsonModel(404, "No Role Found", null);
        }
    }
}
