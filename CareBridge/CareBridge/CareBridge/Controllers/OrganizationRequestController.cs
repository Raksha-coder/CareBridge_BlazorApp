using App.Application.DTOs;
using App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationRequestController : ControllerBase
    {
        private readonly IOrganizationRequestService _organizationRequestService;

        public OrganizationRequestController(IOrganizationRequestService organizationRequestService)
        {
            _organizationRequestService = organizationRequestService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrganizationRequest([FromBody] OrganizationRequestDto organizationRequestDto)
        {
            var result = await _organizationRequestService.CreateOrganizationRequest(organizationRequestDto);
            return Ok(result);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetOrganizationRequestById(int id)
        {
            var result = await _organizationRequestService.GetOrganizationRequestById(id);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrganizationRequestHasApproved()
        {
            var result = await _organizationRequestService.GetAllOrganizationRequestHasApproved();
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrganizationRequestHasNotApproved()
        {
            var result = await _organizationRequestService.GetAllOrganizationRequestHasNotApproved();
            return Ok(result);
        }

        [HttpPost("[action]/{tenantId}")]
        public async Task<IActionResult> UpdateOrganizationRequest(int tenantId)
        {
            var result = await _organizationRequestService.UpdateOrganizationRequest(tenantId);
            return Ok(result);
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteOrganizationRequest(int id)
        {
            var result = await _organizationRequestService.DeleteOrganizationRequest(id);
            return Ok(result);
        }

        [HttpGet("[action]/{tenantId}")]
        public async Task<IActionResult> GetOrganizationDetailsByTenantId(int tenantId)
        {
            var result = await _organizationRequestService.GetOrganizationDetailsByTenantId(tenantId);
            return Ok(result);
        }

        [HttpGet("[action]/{tenantId}")]
        public async Task<IActionResult> GetDatabaseDetailsByTenantId(int tenantId)
        {
            var result = await _organizationRequestService.GetDatabaseDetailsByTenantId(tenantId);
            return Ok(result);
        }

    }
}
