using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace App.Application.Services
{
    public class AppoinmentService : IAppoinmentService
    {
        private readonly IAppoinmentRepository _appoinmentRepository;
        public AppoinmentService(IAppoinmentRepository appoinmentRepository)
        {
            _appoinmentRepository = appoinmentRepository;
        }

        public Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            return _appoinmentRepository.BookAppoinmentAsync(appoinmentDto);
        }

        public Task<JsonResponseDto> GetAppoinmenByPatientIdAsync(int patientId)
        {
            return _appoinmentRepository.GetAppoinmenByPatientIdAsync(patientId);
        }

        public Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId)
        {
            return _appoinmentRepository.GetAppoinmenByStaffIdAsync(staffId);
        }

        public Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            return _appoinmentRepository.UpdateAppoinmentAsync(appoinmentDto);
        }
    }
}
