using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IWeatherForecastRepository : IAsyncRepository<WeatherForecast>
    {
    }
}
