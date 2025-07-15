using App.Application.DTOs;
using App.Application.Interfaces.DbContext;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class OrganizationRequestRepository : IOrganizationRequestRepository
    {
        private readonly IMasterDbContext _masterDbContext;
        private readonly IEmailService _emailService;
        private readonly ILogger<OrganizationRequestRepository> _logger;

        public OrganizationRequestRepository(IMasterDbContext masterDbContext, IEmailService emailService, ILogger<OrganizationRequestRepository> logger)
        {
            _masterDbContext = masterDbContext;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<JsonResponseDto> CreateOrganizationRequest(OrganizationRequestDto organizationRequestDto)
        {
            try
            {
                var checkorganization = await _masterDbContext.Set<OrganizationRequest>().FirstOrDefaultAsync(x => x.Email == organizationRequestDto.Email);

                if (checkorganization != null)
                {
                    return new JsonResponseDto(404, "Organization already exists.", null);
                }

                var addorganization = new OrganizationRequest
                {
                    OrganizationName = organizationRequestDto.OrganizationName,
                    Email = organizationRequestDto.Email,
                    Phone = organizationRequestDto.Phone,
                    CountryID = organizationRequestDto.CountryID,
                    StateID = organizationRequestDto.StateID,
                    City = organizationRequestDto.City,
                    Address1 = organizationRequestDto.Address1,
                    Address2 = organizationRequestDto.Address2,
                    ApartmentNumber = organizationRequestDto.ApartmentNumber,
                    Zip = organizationRequestDto.Zip,
                    Description = organizationRequestDto.Description,
                    IsActive = true,
                    IsDeleted = false,
                    IsApproved = false,
                };
                await _masterDbContext.Set<OrganizationRequest>().AddAsync(addorganization);
                await _masterDbContext.SaveChangesAsync(cancellationToken: default);
                _logger.LogInformation("Organization request submitted successfully.");
                await _emailService.SendEmailAsync(organizationRequestDto.Email, "Organization Request", "Your organization request has been successfully submitted. We will get back to you soon.");

                // Create new database for the organization
                string orgDbName = organizationRequestDto.OrganizationName.Replace(" ", "_"); // Ensure valid DB name
                string serverName = "SDN-116\\SQLEXPRESS"; // Set your server name
                string connectionString = $"Server={serverName};Database={orgDbName};Trusted_Connection=True; TrustServerCertificate=True;";

                using (var dbConnection = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
                {
                    await dbConnection.OpenAsync();
                    var createDbCmd = dbConnection.CreateCommand();
                    createDbCmd.CommandText = $"IF DB_ID('{orgDbName}') IS NULL CREATE DATABASE [{orgDbName}]";
                    await createDbCmd.ExecuteNonQueryAsync();
                }

                // Save OrganizationDatabaseDetailDto
                var orgDbDetail = new OrganizationDatabaseDetailDto
                {
                    ServerName = serverName,
                    OrganizationId = addorganization.TenantID,
                    DatabaseName = orgDbName,
                    ConnectionString = connectionString
                };
                await _masterDbContext.Set<OrganizationDatabaseDetailDto>().AddAsync(orgDbDetail);
                await _masterDbContext.SaveChangesAsync();
                _logger.LogInformation("Organization database created successfully.");
                await _emailService.SendEmailAsync(organizationRequestDto.Email, "Organization Request", "Your organization request has been successfully submitted. We will get back to you soon.");
                return new JsonResponseDto(200, "Organization request and database created successfully.", addorganization);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateOrganizationRequest");
                throw new Exception("An error occurred while creating organization request.");
            }

        }

        public async Task<JsonResponseDto> DeleteOrganizationRequest(int id)
        {
            try
            {
                var deleteOrganizationRequest = await _masterDbContext.Set<OrganizationRequest>().FirstOrDefaultAsync(x => x.TenantID == id);
                if (deleteOrganizationRequest == null)
                {
                    return new JsonResponseDto(404, "Organization request not found.", null);
                }
                // Find related OrganizationDatabaseDetail
                var orgDbDetail = await _masterDbContext.Set<OrganizationDatabaseDetail>()
                    .FirstOrDefaultAsync(x => x.OrganizationId == id);

                if (orgDbDetail != null)
                {
                    // Drop the organization's database
                    var masterConnectionString = $"Server={orgDbDetail.ServerName};Database={orgDbDetail.DatabaseName};Trusted_Connection=True; TrustServerCertificate=True;";
                    using (var dbConnection = new Microsoft.Data.SqlClient.SqlConnection(masterConnectionString))
                    {
                        await dbConnection.OpenAsync();
                        var dropDbCmd = dbConnection.CreateCommand();
                        dropDbCmd.CommandText = $"IF DB_ID('{orgDbDetail.DatabaseName}') IS NOT NULL DROP DATABASE [{orgDbDetail.DatabaseName}]";
                        await dropDbCmd.ExecuteNonQueryAsync();
                    }

                    // Remove OrganizationDatabaseDetail entity
                    _masterDbContext.Set<OrganizationDatabaseDetail>().Remove(orgDbDetail);
                }
                _masterDbContext.Set<OrganizationRequest>().Remove(deleteOrganizationRequest);
                await _masterDbContext.SaveChangesAsync();
                await _emailService.SendEmailAsync(deleteOrganizationRequest.Email, "Your Request Has Been Deleted", "Your Organization Request Has Been Deleted.");
                _logger.LogInformation($"Organization request with ID {id} has been deleted successfully.");
                return new JsonResponseDto(200, "Organization request deleted successfully.", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteOrganizationRequest");
                throw new Exception("An error occurred while deleting organization request.");
            }
        }
        public async Task<JsonResponseDto> GetAllOrganizationRequestHasApproved()
        {
            try
            {
                var getAllOrganizationRequest = await _masterDbContext.Set<OrganizationRequest>().Where(x => x.IsApproved == true).ToListAsync();
                if (getAllOrganizationRequest == null || !getAllOrganizationRequest.Any())
                {
                    return new JsonResponseDto(404, "No organization requests found.", null);
                }
                return new JsonResponseDto(200, "Organization requests fetched has been approved successfully.", getAllOrganizationRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllOrganizationRequest");
                throw new Exception("An error occurred while fetching organization request data.");
            }
        }

        public async Task<JsonResponseDto> GetAllOrganizationRequestHasNotApproved()
        {
            try
            {
                var getAllOrganizationRequest = await _masterDbContext.Set<OrganizationRequest>().Where(x => x.IsApproved == false).ToListAsync();
                if (getAllOrganizationRequest == null || !getAllOrganizationRequest.Any())
                {
                    return new JsonResponseDto(404, "No organization requests found.", null);
                }
                return new JsonResponseDto(200, "Organization requests fetched has not been approved successfully.", getAllOrganizationRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllOrganizationRequest");
                throw new Exception("An error occurred while fetching organization request data.");
            }
        }

        public async Task<JsonResponseDto> GetOrganizationDatabaseDetailsByTenantId(int tenantId)
        {
            try
            {
                var organizationDatabaseDetails = await _masterDbContext.Set<OrganizationDatabaseDetail>().FirstOrDefaultAsync(x => x.OrganizationId == tenantId);
                if (organizationDatabaseDetails == null)
                {
                    return new JsonResponseDto(404, "Organization database details not found.", null);
                }
                return new JsonResponseDto(200, "Organization database details fetched successfully.", organizationDatabaseDetails);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetOrganizationDatabaseDetailsByTenantId");
                throw new Exception("An error occurred while fetching organization database details.");
            }
        }

        public async Task<JsonResponseDto> GetOrganizationRequestById(int id)
        {
            var getOrganizationRequestById = await _masterDbContext.Set<OrganizationRequest>().FirstOrDefaultAsync(x => x.TenantID == id);
            if (getOrganizationRequestById == null)
            {
                return new JsonResponseDto(404, "Organization request not found.", null);
            }
            return new JsonResponseDto(200, "Organization request fetched successfully.", getOrganizationRequestById);
        }

        public async Task<JsonResponseDto> UpdateOrganizationRequest(int tennatid)
        {
            try
            {
                var updateOrganizationRequest = await _masterDbContext.Set<OrganizationRequest>().FirstOrDefaultAsync(x => x.Id == tennatid);
                if (updateOrganizationRequest == null)
                {
                    return new JsonResponseDto(404, "Organization request not found.", null);
                }
                updateOrganizationRequest.IsActive = true;
                _masterDbContext.Set<OrganizationRequest>().Update(updateOrganizationRequest);
                await _masterDbContext.SaveChangesAsync(cancellationToken: default);
                await _emailService.SendEmailAsync(updateOrganizationRequest.Email, "Database Allocation Successfully", "Your database has been allocated successfully");
                return (new JsonResponseDto(200, "Organization request updated successfully.", updateOrganizationRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateOrganizationRequest");
                throw new Exception("An error occurred while updating organization request.");
            }
        }
    }
}
