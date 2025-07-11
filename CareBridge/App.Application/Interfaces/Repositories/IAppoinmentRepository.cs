using App.Application.DTOs;
using App.Domain.Entities;

namespace App.Application.Interfaces.Repositories
{
    public interface IAppoinmentRepository
    {
        Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId);
        Task<JsonResponseDto> GetAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto);
        Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto);
    }
}
