using App.Core.Dtos;
using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interface
{
    public interface IPatientService
    {
        public Task<JsonModel> RegisterPatientAsync(PatientRegisterDto registerDto);
        public Task<JsonModel> VerifyOtpAsync(VerifyOtpDto verifyOtpDto);
        public Task<JsonModel> LoginPatientAsync(LoginDto loginDto);
        public Task<JsonModel> GetPatientByIdAsync(int patientId);
        public Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
