using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class AppoinmentRepository : IAppoinmentRepository
    {
        private readonly AppDbContext _context;

        public AppoinmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            var bookAppoinment = await _context.Appoinment.FirstOrDefaultAsync(a => a.Id == appoinmentDto.Id);
            if (bookAppoinment != null)
            {
                return new JsonResponseDto(400, "Appoinment Already Exists", null);
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
            return new JsonResponseDto(200, "Appoinment Booked Successfully", newAppoinment);
        }

        public async Task<JsonResponseDto> GetAppoinmenByPatientIdAsync(int patientId)
        {
            var getappoinmentByPatientId = await _context.Appoinment.Where(a => a.PatientId == patientId).ToListAsync();

            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Pending))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
            }
            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Confirmed))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
            }
            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Completed))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
            }
            if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Cancelled))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
            }
            return new JsonResponseDto(404, "No Appoinment Found for this Patient", null);
        }

        public async Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId)
        {
            var getappoinmentByStaffId = await _context.Appoinment.Where(a => a.StaffId == staffId).ToListAsync();

            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Pending))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
            }
            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Confirmed))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
            }
            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Completed))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
            }
            if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Cancelled))
            {
                return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
            }
            return new JsonResponseDto(404, "No Appoinment Found for this Staff", null);
        }

        public async Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            var checkAppoinment = await _context.Appoinment.FirstOrDefaultAsync(a => a.Id == appoinmentDto.Id);

            if (checkAppoinment == null)
            {
                return new JsonResponseDto(404, "Appoinment Not Found", null);
            }
            checkAppoinment.Status = appoinmentDto.Status;
            _context.Appoinment.Update(checkAppoinment);
            _context.SaveChanges();
            return new JsonResponseDto(200, "Appoinment Updated Successfully", null);
        }
    }
}
