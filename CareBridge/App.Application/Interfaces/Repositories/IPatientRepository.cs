using App.Application.DTOs;

namespace App.Application.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<JsonResponseDto> RegisterPatientAsync(PatientRegisterDto registerDto);
        Task<JsonResponseDto> VerifyOtpAsync(VerifyOtpDto verifyOtpDto);
        Task<JsonResponseDto> LoginPatientAsync(LoginDto loginDto);
        Task<JsonResponseDto> GetPatientByIdAsync(int patientId);
        Task<JsonResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);

        Task<JsonResponseDto> UpdatePatientAsync(PatientRegisterDto updatePatientDto);
    }
}
