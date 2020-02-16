using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IWeatherForecastService
    {
        Task<IReadOnlyList<WeatherForecast>> GetAllAsync();
    }
}
