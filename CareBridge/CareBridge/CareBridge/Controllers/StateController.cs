using App.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateService;

        public StateController(IStateRepository stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var result = await _stateService.GetAllStatesAsync();
            return Ok(result);
        }

        [HttpGet("GetStateByCountryId/{id}")]
        public async Task<IActionResult> GetStateByCountryId(int id)
        {
            var result = await _stateService.GetStateByCountryIdAsync(id);
            return Ok(result);
        }
    }
}
