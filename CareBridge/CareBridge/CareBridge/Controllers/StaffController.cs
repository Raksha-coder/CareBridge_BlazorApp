using App.Application.DTOs;
using App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterStaff([FromBody] StaffRegistrationDto registerDto)
        {
            var result = await _staffService.RegisterStaffAsync(registerDto);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginStaff([FromBody] LoginDto loginDto)
        {
            var result = await _staffService.LoginStaffAsync(loginDto);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllStaffs()
        {
            var result = await _staffService.GetAllStaffAsync();
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _staffService.ForgotPasswordAsync(forgotPasswordDto);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto verifyOtpDto)
        {
            var result = await _staffService.VerifyOtpAsync(verifyOtpDto);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var result = await _staffService.GetStaffByIdAsync(id);
            return Ok(result);
        }
    }
}
