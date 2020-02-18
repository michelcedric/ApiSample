using ApplicationCore.Models.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Api.Features.WeatherForecast
{
    public class WeatherForecastRequest : IRequest<IReadOnlyList<WeatherForecastDto>>
    {

    }
}
