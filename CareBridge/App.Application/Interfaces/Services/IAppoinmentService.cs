using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;

namespace App.Application.Interfaces.Services
{
    public interface IAppoinmentService
    {
        Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId);
        Task<JsonResponseDto> GetAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto);
        Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto);
    }
}
