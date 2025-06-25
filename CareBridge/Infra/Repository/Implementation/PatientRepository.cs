using App.Core.Dtos;
using Domain.ReponseModel;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Implementation
{
    public class PatientRepository : IPatientRepository
    {
        public Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword)
        {
            throw new NotImplementedException();
        }

        public Task<JsonModel> GetPatientByIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<JsonModel> LoginPatientAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<JsonModel> RegisterPatientAsync(PatientRegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
