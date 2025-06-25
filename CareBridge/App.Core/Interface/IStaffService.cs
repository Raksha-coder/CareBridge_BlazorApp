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
        Task<JsonModel> RegisterStaffAsync(StaffRegistrationDto registerDto);
        Task<JsonModel> LoginStaffAsync(LoginDto loginDto);
        Task<JsonModel> GetStaffByIdAsync(int staffId);
        Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
