using Api.Features.WeatherForecast;
using ApplicationCore.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// Controller to manage WeatherForecast
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initialize this one
        /// </summary>
        /// <param name="mediator"></param>
        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all existing <see cref="WeatherForecastDto"/>
        /// </summary>
        /// <returns>A list of WeatherForecastDto</returns>
        [ProducesResponseType(typeof(IReadOnlyList<WeatherForecastDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new WeatherForecastRequest());
            return StatusResultCode(result);
        }
    }
}
