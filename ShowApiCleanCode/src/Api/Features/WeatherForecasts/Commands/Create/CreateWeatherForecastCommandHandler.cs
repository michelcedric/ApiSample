using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Features.WeatherForecasts.Commands.Create
{
    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommandRequest, Guid>
    {
        public Task<Guid> Handle(CreateWeatherForecastCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
