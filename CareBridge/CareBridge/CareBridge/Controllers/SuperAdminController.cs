using App.Application.DTOs;
using App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _superAdminService;

        public SuperAdminController(ISuperAdminService superAdminService)
        {
            _superAdminService = superAdminService;
        }

        [HttpPost("SuperAdminLogin")]
        public async Task<IActionResult> SuperAdminLogin([FromBody] SuperAdminDto loginDto)
        {
            var result = await _superAdminService.SuperAdminLogin(loginDto);
            return Ok(result);
        }

        [HttpPost("VerifySuperAdmin")]
        public async Task<IActionResult> VerifySuperAdmin([FromBody] VerifySuperAdminDto verifySuperAdmin)
        {
            var result = await _superAdminService.VerifySuperAdmin(verifySuperAdmin);
            return Ok(result);
        }
    }
}
