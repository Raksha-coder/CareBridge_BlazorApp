using App.Application.DTOs;
using App.Application.Interfaces;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class AppoinmentRes
    {
        private readonly IUnitOfWork _unitOfWork;

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
