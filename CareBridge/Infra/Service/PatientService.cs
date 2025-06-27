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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword)
        {
            return _patientRepository.ForgotPasswordAsync(forgotPassword);
        }

        public Task<JsonModel> GetPatientByIdAsync(int patientId)
        {
            return _patientRepository.GetPatientByIdAsync(patientId);
        }

        public Task<JsonModel> LoginPatientAsync(LoginDto loginDto)
        {
            return _patientRepository.LoginPatientAsync(loginDto);
        }

        public Task<JsonModel> RegisterPatientAsync(PatientRegisterDto registerDto)
        {
            return _patientRepository.RegisterPatientAsync(registerDto);
        }

        public Task<JsonModel> VerifyOtpAsync(VerifyOtpDto verifyOtpDto)
        {
            return _patientRepository.VerifyOtpAsync(verifyOtpDto);
        }
    }
}
