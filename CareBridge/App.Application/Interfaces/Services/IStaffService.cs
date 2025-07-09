using App.Application.DTOs;

namespace App.Application.Interfaces.Services
{
    public interface IStaffService
    {
        public Task<JsonResponseDto> RegisterStaffAsync(StaffRegistrationDto registerDto);
        public Task<JsonResponseDto> VerifyOtpAsync(VerifyOtpDto verifyOtpDto);
        public Task<JsonResponseDto> LoginStaffAsync(LoginDto loginDto);
        Task<List<StaffRegistrationDto>> GetAllStaffAsync();
        public Task<StaffRegistrationDto> GetStaffByIdAsync(int staffId);
        public Task<JsonResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
