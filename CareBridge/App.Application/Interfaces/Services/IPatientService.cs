using App.Application.DTOs;

namespace App.Application.Interfaces.Services
{
    public interface IPatientService
    {
        public Task<JsonResponseDto> RegisterPatientAsync(PatientRegisterDto registerDto);
        public Task<JsonResponseDto> VerifyOtpAsync(VerifyOtpDto verifyOtpDto);
        public Task<JsonResponseDto> LoginPatientAsync(LoginDto loginDto);
        public Task<JsonResponseDto> GetPatientByIdAsync(int patientId);
        public Task<JsonResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
        Task<JsonResponseDto> UpdatePatientAsync(PatientRegisterDto updatePatientDto);

    }
}
