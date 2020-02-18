using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Features.WeatherForecast
{
    /// <summary>
    /// Handler use to manage a WeatherForecastRequest
    /// </summary>
    public class WeatherForecastHandler : IRequestHandler<WeatherForecastRequest, IReadOnlyList<WeatherForecastDto>>
    {
        private readonly IWeatherForecastService _weatherForecastService;

        /// <summary>
        /// Initialize this one
        /// </summary>
        /// <param name="weatherForecastService"></param>
        public WeatherForecastHandler(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        /// <summary>
        /// Start the handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<WeatherForecastDto>> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var result = await _weatherForecastService.GetAllAsync();
            return result;
        }
    }
}
