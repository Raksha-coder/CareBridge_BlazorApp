using App.Core.Dtos;
using Domain.DataModel.Entity;
using Domain.ReponseModel;
using Infra.Context;
using Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Implementation
{
    public class AppoinmentRepository : IAppoinmentRepository
    {
        private readonly AppDbContext _context;

        public AppoinmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JsonModel> BookAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            var bookAppoinment = await _context.Appoinment.FirstOrDefaultAsync(a => a.Id == appoinmentDto.Id);
            if (bookAppoinment != null)
            {
                return new JsonModel(400, "Appoinment Already Exists", null);
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
            await _context.SaveChangesAsync();
            return new JsonModel(200, "Appoinment Booked Successfully", newAppoinment);
        }

        public async Task<JsonModel> GetAppoinmenByPatientIdAsync(int patientId)
        {
            var getappoinmentByPatientId = await _context.Appoinment.Where(a => a.PatientId == patientId).ToListAsync();

            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Pending))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByPatientId);
            }
            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Confirmed))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByPatientId);
            }
            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Completed))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByPatientId);
            }
            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Cancelled))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByPatientId);
            }
            return new JsonModel(404, "No Appoinment Found for this Patient", null);
        }

        public async Task<JsonModel> GetAppoinmenByStaffIdAsync(int staffId)
        {
            var getappoinmentByStaffId = await _context.Appoinment.Where(a => a.StaffId == staffId).ToListAsync();

            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Pending))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByStaffId);
            }
            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Confirmed))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByStaffId);
            }
            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Completed))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByStaffId);
            }
            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Cancelled))
            {
                return new JsonModel(200, "Appoinment List", getappoinmentByStaffId);
            }
            return new JsonModel(404, "No Appoinment Found for this Staff", null);
        }

        public async Task<JsonModel> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            var checkAppoinment = await _context.Appoinment.FirstOrDefaultAsync(a => a.Id == appoinmentDto.Id);

            if (checkAppoinment == null)
            {
                return new JsonModel(404, "Appoinment Not Found", null);
            }
            checkAppoinment.Status = appoinmentDto.Status;
            _context.Appoinment.Update(checkAppoinment);
            _context.SaveChanges();
            return new JsonModel(200, "Appoinment Updated Successfully", null);
        }
    }
}
