using Api.Features.WeatherForecasts.Queries.Get;
using MediatR;
using System.Collections.Generic;

namespace Api.Features.WeatherForecasts
{
    /// <summary>
    /// Represent the defintion of the request
    /// </summary>
    public class WeatherForecastRequest : IRequest<IReadOnlyList<WeatherForecastDto>>
    {

    }
}
