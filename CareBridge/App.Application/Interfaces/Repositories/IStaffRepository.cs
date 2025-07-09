using App.Application.DTOs;

namespace App.Application.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        Task<JsonResponseDto> RegisterStaffAsync(StaffRegistrationDto registerDto);
        Task<JsonResponseDto> VerifyOtpAsync(VerifyOtpDto verifyOtpDto);
        Task<JsonResponseDto> LoginStaffAsync(LoginDto loginDto);
        Task<StaffRegistrationDto> GetStaffByIdAsync(int staffId);
        Task<List<StaffRegistrationDto>> GetAllStaffAsync();
        Task<JsonResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
