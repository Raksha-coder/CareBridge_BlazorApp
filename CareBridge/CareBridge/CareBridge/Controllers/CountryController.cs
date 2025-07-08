using App.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CareBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryService;

        public CountryController(ICountryRepository countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _countryService.GetAllCountryAsync();
            return Ok(result);
        }
    }
}
