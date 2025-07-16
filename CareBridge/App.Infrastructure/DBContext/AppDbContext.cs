using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Otp> Otp { get; set; }
        public DbSet<Appoinment> Appoinment { get; set; }
    }
}