using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _weatherForecastRepository.ListAllAsync();
            return Ok(result);
        }
    }
}
