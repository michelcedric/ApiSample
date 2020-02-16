using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IWeatherForecastRepository : IAsyncRepository<WeatherForecast>
    {
    }
}
