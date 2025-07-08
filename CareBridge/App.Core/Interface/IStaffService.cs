using App.Core.Dtos;
using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interface
{
    public interface IStaffService
    {
        public Task<JsonModel> RegisterStaffAsync(StaffRegistrationDto registerDto);
        public Task<JsonModel> VerifyOtpAsync(VerifyOtpDto verifyOtpDto);
        public Task<JsonModel> LoginStaffAsync(LoginDto loginDto);
        Task<List<StaffRegistrationDto>> GetAllStaffAsync();

        public Task<StaffRegistrationDto> GetStaffByIdAsync(int staffId);
        public Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);

    }
}
