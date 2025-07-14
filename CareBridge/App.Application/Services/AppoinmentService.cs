using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Application.Services
{
    public class AppoinmentService : IAppoinmentService
    {
        private readonly IAppoinmentRepository _appoinmentRepository;
        private readonly ILogger<AppoinmentService> _logger;

        public AppoinmentService(IAppoinmentRepository appoinmentRepository, ILogger<AppoinmentService> logger)
        {
            _appoinmentRepository = appoinmentRepository;
            _logger = logger;
        }

        public async Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            return new JsonResponseDto(500, "Internal Server Error", null);
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
