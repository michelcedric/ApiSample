using FluentValidation;

namespace Api.Features.WeatherForecasts.Commands.Create
{
    public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommandRequest>
    {
        public CreateWeatherForecastCommandValidator()
        {
            RuleFor(x => x.Summary).NotEmpty();
        }
    }
}
