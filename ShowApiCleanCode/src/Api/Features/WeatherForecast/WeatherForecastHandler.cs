using ApplicationCore.Interfaces.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WeatherForecastDomain = ApplicationCore.Entities.WeatherForecast;

namespace Api.Features.WeatherForecast
{
    public class WeatherForecastHandler : IRequestHandler<WeatherForecastRequest, IReadOnlyList<WeatherForecastDomain>>
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastHandler(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        public async Task<IReadOnlyList<WeatherForecastDomain>> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var result = await _weatherForecastService.GetAllAsync();
            return result;
        }
    }
}
