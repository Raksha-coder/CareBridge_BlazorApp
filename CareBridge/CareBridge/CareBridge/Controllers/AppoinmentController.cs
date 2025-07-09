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

        [HttpPost("BookAppoinment")]
        public async Task<IActionResult> BookAppoinment([FromBody] AppoinmentDto bookAppoinmentDto)
        {
            var result = await _appoinmentService.BookAppoinmentAsync(bookAppoinmentDto);
            return Ok(result);
        }
    }
}
