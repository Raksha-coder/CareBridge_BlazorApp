using App.Application.DTOs;
using App.Application.Interfaces;
using App.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAppoinment([FromBody] AppoinmentDto genericDto)
        {
            var result = await _unitOfWork.GenericRepository<Appoinment>().AddAsync(genericDto);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetGenericData()
        {
            var result = await _unitOfWork.GenericRepository<Appoinment>().GetAllAsync<Appoinment>();
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetGenericDataById(int id)
        {
            var result = await _unitOfWork.GenericRepository<Appoinment>().GetByIdAsync<Appoinment>(id);
            return Ok(result);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteGenericData(int id)
        {
            var result = await _unitOfWork.GenericRepository<Appoinment>().DeleteAsync<Appoinment>(id);
            return Ok(new { Message = "Deleted successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGenericData([FromBody] AppoinmentDto genericDto)
        {
            var result = await _unitOfWork.GenericRepository<Appoinment>().UpdateAsync(genericDto);
            return Ok(result);
        }


    }
}
