using App.Core.Dtos;
using App.Core.Interface;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("RegisterPatient")]
        public async Task<IActionResult> RegisterPatient(PatientRegisterDto registerDto)
        {
            var result = await _patientService.RegisterPatientAsync(registerDto);
            return Ok(result);
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto verifyOtpDto)
        {
            var result = await _patientService.VerifyOtpAsync(verifyOtpDto);
            return Ok(result);
        }

        [HttpPost("LoginPatient")]
        public async Task<IActionResult> LoginPatient([FromBody] LoginDto loginDto)
        {
            var result = await _patientService.LoginPatientAsync(loginDto);
            return Ok(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _patientService.ForgotPasswordAsync(forgotPasswordDto);
            return Ok(result);
        }
    }
}
