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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAppoinmenByStaffId(int staffId)
        {
            var result = await _appoinmentService.GetAppoinmenByStaffIdAsync(staffId);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAppoinmentByPatientId(int staffId)
        {
            var result = await _appoinmentService.GetAppoinmenByPatientIdAsync(staffId);
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
