using App.Application.DTOs;
using App.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class AppoinmentServ : IAppoinmentServ
    {
        public Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            throw new NotImplementedException();
        }

        public Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId)
        {
            throw new NotImplementedException();
        }

        public Task<JsonResponseDto> GetCancelledAppoinmenByPatientIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<JsonResponseDto> GetConfirmedAppoinmenByPatientIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<JsonResponseDto> GetPendingAppoinmenByPatientIdAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            throw new NotImplementedException();
        }
    }
}
