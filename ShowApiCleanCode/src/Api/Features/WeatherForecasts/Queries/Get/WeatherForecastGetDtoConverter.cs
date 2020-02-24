using ApplicationCore.Entities;

namespace Api.Features.WeatherForecasts.Queries.Get
{
    public class WeatherForecastGetDtoConverter
    {
        public static WeatherForecastDto Convert(WeatherForecast weatherForecast)
        {
            return new WeatherForecastDto
            {
                Date = weatherForecast.Date,
                Summary = weatherForecast.Summary,
                TemperatureC = weatherForecast.TemperatureC
            };
        }
    }
}
