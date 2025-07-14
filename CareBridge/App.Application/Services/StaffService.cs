using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;

namespace App.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public Task<JsonResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword)
        {
            return _staffRepository.ForgotPasswordAsync(forgotPassword);
        }

        public Task<List<StaffRegistrationDto>> GetAllStaffAsync()
        {
            return _staffRepository.GetAllStaffAsync();
        }

        public Task<JsonResponseDto> GetStaffByIdAsync(int staffId)
        {
            return _staffRepository.GetStaffByIdAsync(staffId);
        }

        public Task<JsonResponseDto> LoginStaffAsync(LoginDto loginDto)
        {
            return _staffRepository.LoginStaffAsync(loginDto);
        }

        public Task<JsonResponseDto> RegisterStaffAsync(StaffRegistrationDto registerDto)
        {
            return _staffRepository.RegisterStaffAsync(registerDto);
        }

        public Task<JsonResponseDto> VerifyOtpAsync(VerifyOtpDto verifyOtpDto)
        {
            return _staffRepository.VerifyOtpAsync(verifyOtpDto);
        }
    }
}
