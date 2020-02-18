using MediatR;
using System.Collections.Generic;
using WeatherForecastDomain = ApplicationCore.Entities.WeatherForecast;

namespace Api.Features.WeatherForecast
{
    public class WeatherForecastRequest : IRequest<IReadOnlyList<WeatherForecastDomain>>
    {

    }
}
