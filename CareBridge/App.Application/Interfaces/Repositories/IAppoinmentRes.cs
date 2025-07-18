using App.Application.DTOs;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Repositories
{
    public interface IAppoinmentRes 
    {
        Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId);
        Task<JsonResponseDto> GetConfirmedAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> GetPendingAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> GetCancelledAppoinmenByPatientIdAsync(int patientId);
        Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto);
        Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto);
    }
}
