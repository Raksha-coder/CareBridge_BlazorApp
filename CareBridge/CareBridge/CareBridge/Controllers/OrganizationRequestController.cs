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

        [HttpPost("UpdateOrganizationRequest")]
        public async Task<IActionResult> UpdateOrganizationRequest(int tenantId)
        {
            var result = await _organizationRequestService.UpdateOrganizationRequest(tenantId);
            return Ok(result);
        }
        [HttpDelete("DeleteOrganizationRequest/{id}")]
        public async Task<IActionResult> DeleteOrganizationRequest(int id)
        {
            var result = await _organizationRequestService.DeleteOrganizationRequest(id);
            return Ok(result);
        }

        [HttpGet("GetOrganizationDatabaseDetailsByTenantId/{tenantId}")]
        public async Task<IActionResult> GetOrganizationDatabaseDetailsByTenantId(int tenantId)
        {
            var result = await _organizationRequestService.GetOrganizationDatabaseDetailsByTenantId(tenantId);
            return Ok(result);
        }

    }
}
