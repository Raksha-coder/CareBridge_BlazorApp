﻿using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;

namespace App.Application.Interfaces.Services
{
    public interface IAppoinmentService
    {
        Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId);
        Task<JsonResponseDto> GetConfirmedAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> GetPendingAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> GetCancelledAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto);
        Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto);
    }
}
