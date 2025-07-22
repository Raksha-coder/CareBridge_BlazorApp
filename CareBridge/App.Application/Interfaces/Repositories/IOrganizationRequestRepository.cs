using App.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Repositories
{
    public interface IOrganizationRequestRepository
    {
        Task<JsonResponseDto> CreateOrganizationRequest(OrganizationRequestDto organizationRequestDto);
        Task<JsonResponseDto> GetOrganizationRequestById(int id);
        Task<JsonResponseDto> GetAllOrganizationRequestHasApproved();
        Task<JsonResponseDto> GetAllOrganizationRequestHasNotApproved();
        Task<JsonResponseDto> UpdateOrganizationRequest(int tennatid);
        Task<JsonResponseDto> DeleteOrganizationRequest(int id);
        Task<JsonResponseDto> GetOrganizationDetailsByTenantId(int tenantId);

        Task<JsonResponseDto> GetDatabaseDetailsByTenantId(int tenantId);
    }
}
