using App.Application.Interfaces.DbContext;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DBContext
{
    public class MasterDbContext : DbContext,IMasterDbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }
        DbSet<OrganizationRequest> OrganizationRequest { get; set; }
        DbSet<OrganizationDatabaseDetail> OrganizationDatabaseDetail { get; set; }

        DbSet<SuperAdmin> SuperAdmin { get; set; }

    }
}
