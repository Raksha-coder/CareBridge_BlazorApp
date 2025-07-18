using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

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
                return await _appoinmentRepository.BookAppoinmentAsync(newAppoinment.Adapt<AppoinmentDto>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while booking appoinment.");
                return new JsonResponseDto(500, "Internal Server Error", null);
            }
        }

        public async Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId)
        {
            return await _appoinmentRepository.GetAppoinmenByStaffIdAsync(staffId);
        }

        public async Task<JsonResponseDto> GetCancelledAppoinmenByPatientIdAsync(int patientId)
        {
            return await _appoinmentRepository.GetCancelledAppoinmenByPatientIdAsync(patientId);
        }

        public async Task<JsonResponseDto> GetConfirmedAppoinmenByPatientIdAsync(int patientId)
        {
            return await _appoinmentRepository.GetConfirmedAppoinmenByPatientIdAsync(patientId);
        }

        public async Task<JsonResponseDto> GetPendingAppoinmenByPatientIdAsync(int patientId)
        {
            return await _appoinmentRepository.GetPendingAppoinmenByPatientIdAsync(patientId);
        }

        public Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinment)
        {
            return _appoinmentRepository.UpdateAppoinmentAsync(appoinment);
        }
    }
}
