using App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _roleService.GetAllRoleAsync();
            return Ok(result);
        }
    }
}
