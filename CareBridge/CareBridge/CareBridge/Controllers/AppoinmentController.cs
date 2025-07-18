using App.Application.DTOs;
using App.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoinmentController : ControllerBase
    {
        private readonly IAppoinmentService _appoinmentService;

        public AppoinmentController(IAppoinmentService appoinmentService)
        {
            _appoinmentService = appoinmentService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BookAppoinment([FromBody] AppoinmentDto bookAppoinmentDto)
        {
            var result = await _appoinmentService.BookAppoinmentAsync(bookAppoinmentDto);
            return Ok(result);
        }

        [HttpGet("[action]/{staffId}")]
        public async Task<IActionResult> GetAppoinmenByStaffId(int staffId)
        {
            var result = await _appoinmentService.GetAppoinmenByStaffIdAsync(staffId);
            return Ok(result);
        }

        [HttpGet("[action]/{patientId}")]
        public async Task<IActionResult> GetPendingAppoinmenByPatientId(int patientId)
        {
            var result = await _appoinmentService.GetPendingAppoinmenByPatientIdAsync(patientId);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetConfirmedAppoinmentByPatientId(int id)
        {
            var result = await _appoinmentService.GetConfirmedAppoinmenByPatientIdAsync(id);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCancelledAppoinmentByPatientId(int id)
        {
            var result = await _appoinmentService.GetCancelledAppoinmenByPatientIdAsync(id);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> UpdateAppoinment(AppoinmentDto updateAppoinment)
        {
            var result = await _appoinmentService.UpdateAppoinmentAsync(updateAppoinment);
            return Ok(result);
        }

    }
}
