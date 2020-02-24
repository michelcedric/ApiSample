using MediatR;
using System;

namespace Api.Features.WeatherForecasts.Commands.Create
{
    public class CreateWeatherForecastCommandRequest : IRequest<Guid>
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
