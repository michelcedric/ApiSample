using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Features.WeatherForecast
{
    public class WeatherForecastHandler : IRequestHandler<WeatherForecastRequest, IReadOnlyList<WeatherForecastDto>>
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastHandler(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public async Task<IReadOnlyList<WeatherForecastDto>> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var result = await _weatherForecastService.GetAllAsync();
            return result;
        }
    }
}
