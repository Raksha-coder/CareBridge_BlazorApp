using App.Application.DTOs;
using App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterPatient(PatientRegisterDto registerDto)
        {
            var result = await _patientService.RegisterPatientAsync(registerDto);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto verifyOtpDto)
        {
            var result = await _patientService.VerifyOtpAsync(verifyOtpDto);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginPatient([FromBody] LoginDto loginDto)
        {
            var result = await _patientService.LoginPatientAsync(loginDto);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _patientService.ForgotPasswordAsync(forgotPasswordDto);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var result = await _patientService.GetPatientByIdAsync(id);
            return Ok(result);
        }
    }
}
