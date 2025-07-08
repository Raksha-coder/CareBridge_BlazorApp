using App.Core.Dtos;
using App.Core.Interface;
using Domain.ReponseModel;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword)
        {
            return _staffRepository.ForgotPasswordAsync(forgotPassword);
        }

        public Task<List<StaffRegistrationDto>> GetAllStaffAsync()
        {
            return _staffRepository.GetAllStaffAsync();
        }

        public Task<StaffRegistrationDto> GetStaffByIdAsync(int staffId)
        {
            return _staffRepository.GetStaffByIdAsync(staffId);
        }

        public Task<JsonModel> LoginStaffAsync(LoginDto loginDto)
        {
            return _staffRepository.LoginStaffAsync(loginDto);
        }

        public Task<JsonModel> RegisterStaffAsync(StaffRegistrationDto registerDto)
        {
            return _staffRepository.RegisterStaffAsync(registerDto);
        }

        public Task<JsonModel> VerifyOtpAsync(VerifyOtpDto verifyOtpDto)
        {
            return _staffRepository.VerifyOtpAsync(verifyOtpDto);
        }
    }
}
