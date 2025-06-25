using App.Core.Dtos;
using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interface
{
    public interface IPatientRepository
    {
        Task<JsonModel> RegisterPatientAsync(PatientRegisterDto registerDto);
        Task<JsonModel> LoginPatientAsync(LoginDto loginDto);
        Task<JsonModel> GetPatientByIdAsync(int patientId);
        Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
