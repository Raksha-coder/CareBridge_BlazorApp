using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;

namespace App.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<JsonResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword)
        {
            return _patientRepository.ForgotPasswordAsync(forgotPassword);
        }

        public Task<JsonResponseDto> GetPatientByIdAsync(int patientId)
        {
            return _patientRepository.GetPatientByIdAsync(patientId);
        }

        public Task<JsonResponseDto> LoginPatientAsync(LoginDto loginDto)
        {
            return _patientRepository.LoginPatientAsync(loginDto);
        }

        public Task<JsonResponseDto> RegisterPatientAsync(PatientRegisterDto registerDto)
        {
            return _patientRepository.RegisterPatientAsync(registerDto);
        }

        public Task<JsonResponseDto> VerifyOtpAsync(VerifyOtpDto verifyOtpDto)
        {
            return _patientRepository.VerifyOtpAsync(verifyOtpDto);
        }
    }
}
