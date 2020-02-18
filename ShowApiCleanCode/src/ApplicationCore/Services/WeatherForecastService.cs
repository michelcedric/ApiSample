using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<IReadOnlyList<WeatherForecastDto>> GetAllAsync()
        {
            var data = await _weatherForecastRepository.ListAllAsync();
            return data.Select(d => new WeatherForecastDto
            {
                Date = d.Date,
                Summary = d.Summary,
                TemperatureC = d.TemperatureC
            }).ToList();
        }
    }
}
