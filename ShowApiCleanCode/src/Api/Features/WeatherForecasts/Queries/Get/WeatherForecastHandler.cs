using ApplicationCore.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Features.WeatherForecasts.Queries.Get
{
    /// <summary>
    /// Handler use to manage a WeatherForecastRequest
    /// </summary>
    public class WeatherForecastHandler : IRequestHandler<WeatherForecastRequest, IReadOnlyList<WeatherForecastDto>>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        /// <summary>
        /// Initialize this one
        /// </summary>
        /// <param name="weatherForecastRepository"></param>
        public WeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        /// <summary>
        /// Start the handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<WeatherForecastDto>> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var result = await _weatherForecastRepository.ListAllAsync(cancellationToken);
            return result.Select(r => WeatherForecastGetDtoConverter.Convert(r)).ToList();
        }
    }
};
