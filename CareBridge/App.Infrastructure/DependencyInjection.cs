using App.Application.DTOs;
using App.Application.Interfaces;
using App.Application.Interfaces.DbContext;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Application.Services;
using App.Infrastructure.DBContext;
using App.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ISuperAdminRepository, SuperAdminRepository>();
            services.AddScoped<ISuperAdminService, SuperAdminService>();
            services.AddScoped<IOrganizationRequestRepository, OrganizationRequestRepository>();
            services.AddScoped<IOrganizationRequestService, OrganizationRequestService>();
            services.AddScoped<IAppoinmentRepository, AppoinmentRepository>();
            services.AddScoped<IAppoinmentService, AppoinmentService>();
            services.AddScoped<IGenericRepository<AppDbContext>, GenericRepository<AppDbContext>>();
            services.AddScoped<IMasterDbContext, MasterDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

            //services.AddSingleton<Func<IServiceProvider, string>>(sp =>
            //{
            //    var configDb = sp.GetRequiredService<MasterDbContext>();
            //    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
            //    var httpContext = httpContextAccessor.HttpContext ?? throw new Exception("No active HTTP context found.");

            //    // Get industry name from header
            //    var industryName = httpContext.Request.Headers["Industry-Name"].FirstOrDefault();
            //    var targetConnectionString = configDb.IndustryConfig
            //        .Where(c => c.Name == industryName)
            //        .Select(c => c.ConnectionString)
            //        .FirstOrDefault();

            //    if (string.IsNullOrEmpty(targetConnectionString))
            //    {
            //        throw new Exception($"AppDb connection string not found for industry '{industryName}'.");
            //    }

            //    return targetConnectionString;
            //});


            services.AddDbContext<AppDbContext>((provide, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<MasterDbContext>((provide, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MasterConnection"));
            });
            return services;
        }
    }
}
