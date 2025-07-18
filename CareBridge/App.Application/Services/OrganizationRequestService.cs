using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class OrganizationRequestService : IOrganizationRequestService
    {
        private readonly IOrganizationRequestRepository _organizationRequestRepository;

        public OrganizationRequestService(IOrganizationRequestRepository organizationRequestRepository)
        {
            _organizationRequestRepository = organizationRequestRepository;
        }

        public async Task<JsonResponseDto> CreateOrganizationRequest(OrganizationRequestDto organizationRequestDto)
        {
            try
            {
                return await _organizationRequestRepository.CreateOrganizationRequest(organizationRequestDto);
            }
                catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JsonResponseDto> DeleteOrganizationRequest(int id)
        {
            try
            {
                return await _organizationRequestRepository.DeleteOrganizationRequest(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JsonResponseDto> GetAllOrganizationRequestHasApproved()
        {
            try
            {
                return await _organizationRequestRepository.GetAllOrganizationRequestHasApproved();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JsonResponseDto> GetAllOrganizationRequestHasNotApproved()
        {
            try
            {
                return await _organizationRequestRepository.GetAllOrganizationRequestHasNotApproved();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JsonResponseDto> GetOrganizationDatabaseDetailsByTenantId(int tenantId)
        {
            try
            {
                return await _organizationRequestRepository.GetOrganizationDatabaseDetailsByTenantId(tenantId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JsonResponseDto> GetOrganizationRequestById(int id)
        {
            try
            {
                return await _organizationRequestRepository.GetOrganizationRequestById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<JsonResponseDto> UpdateOrganizationRequest(int tennatid)
        {
            try
            {
                return await _organizationRequestRepository.UpdateOrganizationRequest(tennatid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
