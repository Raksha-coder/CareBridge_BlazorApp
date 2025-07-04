using App.Core.Dtos;
using App.Core.Interface;
using Domain.ReponseModel;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Service
{
    public class AppoinmentService : IAppoinmentService
    {
        private readonly IAppoinmentRepository _appoinmentRepository;

        public AppoinmentService(IAppoinmentRepository appoinmentRepository)
        {
            _appoinmentRepository = appoinmentRepository;
        }

        public Task<JsonModel> BookAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            return _appoinmentRepository.BookAppoinmentAsync(appoinmentDto);
        }

        public Task<JsonModel> GetAppoinmenByPatientIdAsync(int patientId)
        {
            return _appoinmentRepository.GetAppoinmenByPatientIdAsync(patientId);
        }

        public Task<JsonModel> GetAppoinmenByStaffIdAsync(int staffId)
        {
            return _appoinmentRepository.GetAppoinmenByStaffIdAsync(staffId);
        }

        public Task<JsonModel> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            return _appoinmentRepository.UpdateAppoinmentAsync(appoinmentDto);
        }
    }
}
