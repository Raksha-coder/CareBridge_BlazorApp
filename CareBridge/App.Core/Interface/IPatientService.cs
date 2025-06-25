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
        Task<JsonModel> RegisterPatientAsync(PatientRegisterDto registerDto);
        Task<JsonModel> LoginPatientAsync(LoginDto loginDto);
        Task<JsonModel> GetPatientByIdAsync(int patientId);
        Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
