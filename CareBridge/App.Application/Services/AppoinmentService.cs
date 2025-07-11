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
            try
            {
                var bookAppoinment = await _context.Appoinment.FirstOrDefaultAsync(a => a.Id == appoinmentDto.Id);
                if (bookAppoinment != null)
                {
                    _logger.LogInformation("Appoinment Already Exists");
                    return new JsonResponseDto(400, "Appoinment Already Exists", null);
                }

                var newAppoinment = new Appoinment
                {
                    Id = appoinmentDto.Id,
                    PatientId = appoinmentDto.PatientId,
                    StaffId = appoinmentDto.StaffId,
                    Status = AppointmentStatus.Pending,
                    Date = appoinmentDto.Date,
                    StartTime = appoinmentDto.StartTime,
                    EndTime = appoinmentDto.EndTime,
                    Reason = appoinmentDto.Reason
                };
                await _context.Appoinment.AddAsync(newAppoinment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while booking appoinment.");
                return new JsonResponseDto(500, "Internal Server Error", null);
            }
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
