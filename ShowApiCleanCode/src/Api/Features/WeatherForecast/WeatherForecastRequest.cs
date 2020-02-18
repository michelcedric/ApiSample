using ApplicationCore.Models.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Api.Features.WeatherForecast
{
    /// <summary>
    /// Represent the defintion of the request
    /// </summary>
    public class WeatherForecastRequest : IRequest<IReadOnlyList<WeatherForecastDto>>
    {

    }
}
