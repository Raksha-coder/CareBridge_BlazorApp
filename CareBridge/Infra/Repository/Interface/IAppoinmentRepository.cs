using App.Core.Dtos;
using Domain.ReponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interface
{
    public interface IAppoinmentRepository
    {
        Task<JsonModel> GetAppoinmenByStaffIdAsync(int staffId);
        Task<JsonModel> GetAppoinmenByPatientIdAsync(int patientId);
        Task<JsonModel> BookAppoinmentAsync(AppoinmentDto appoinmentDto);
        Task<JsonModel> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto);
    }
}
