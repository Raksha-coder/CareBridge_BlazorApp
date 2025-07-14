using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Domain.Entities;
using App.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Infrastructure.Repositories
{
    public class AppoinmentRepository : IAppoinmentRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AppoinmentRepository> _logger;
        public AppoinmentRepository(AppDbContext context, ILogger<AppoinmentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<JsonResponseDto> BookAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            try
            {
                var bookAppoinment = await _context.Appoinment.FirstOrDefaultAsync(a => a.Id == appoinmentDto.Id);
                if (bookAppoinment != null)
                {
                    _logger.LogInformation("Appoinment Already Exists");
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
                _logger.LogInformation("Appoinment Booked Successfully");
                return new JsonResponseDto(200, "Appoinment Booked Successfully", newAppoinment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while booking appoinment.");
                return new JsonResponseDto(500, "Internal Server Error", null);
            }

        }
        public async Task<JsonResponseDto> GetAppoinmenByPatientIdAsync(int patientId)
        {
            try
            {
                var getappoinmentByPatientId = await _context.Appoinment.Where(a => a.PatientId == patientId).ToListAsync();

                if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Pending))
                {
                    _logger.LogInformation("Retrived list of Pending Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
                }
                if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Confirmed))
                {
                    _logger.LogInformation("Retrived list of Confirmed Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
                }
                if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Completed))
                {
                    _logger.LogInformation("Retrived list of Completed Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
                }
                if (getappoinmentByPatientId != null && getappoinmentByPatientId.Any(a => a.Status == AppointmentStatus.Cancelled))
                {
                    _logger.LogInformation("Retrived list of Cancelled Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByPatientId);
                }
                _logger.LogWarning("No Appoinment Found for this Patient");
                return new JsonResponseDto(404, "No Appoinment Found for this Patient", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting appoinment by patient id.");
                return new JsonResponseDto(500, "Internal Server Error", null);
            }
        }

        public async Task<JsonResponseDto> GetAppoinmenByStaffIdAsync(int staffId)
        {
            try
            {
                var getappoinmentByStaffId = await _context.Appoinment.Where(a => a.StaffId == staffId).ToListAsync();

                if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Pending))
                {
                    _logger.LogInformation("Retrived list of Pending Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
                }
                if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Confirmed))
                {
                    _logger.LogInformation("Retrived list of Confirmed Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
                }
                if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Completed))
                {
                    _logger.LogInformation("Retrived list of Completed Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
                }
                if (getappoinmentByStaffId != null && getappoinmentByStaffId.Any(a => a.Status == AppointmentStatus.Cancelled))
                {
                    _logger.LogInformation("Retrived list of Cancelled Appoinments");
                    return new JsonResponseDto(200, "Appoinment List", getappoinmentByStaffId);
                }
                _logger.LogWarning("No Appoinment Found for this Staff");
                return new JsonResponseDto(404, "No Appoinment Found for this Staff", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting appoinment by staff id.");
                return new JsonResponseDto(500, "Internal Server Error", null);
            }
        }

        public async Task<JsonResponseDto> UpdateAppoinmentAsync(AppoinmentDto appoinmentDto)
        {
            try
            {
                var checkAppoinment = await _context.Appoinment.FirstOrDefaultAsync(a => a.Id == appoinmentDto.Id);

                if (checkAppoinment == null)
                {
                    _logger.LogWarning("Appoinment Not Found");
                    return new JsonResponseDto(404, "Appoinment Not Found", null);
                }
                checkAppoinment.Status = appoinmentDto.Status;
                _context.Appoinment.Update(checkAppoinment);
                _context.SaveChanges();
                _logger.LogInformation("Appoinment Updated Successfully");
                return new JsonResponseDto(200, "Appoinment Updated Successfully", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating appoinment.");
                return new JsonResponseDto(500, "Internal Server Error", null);
            }

        }
    }
}
