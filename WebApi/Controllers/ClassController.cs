using Application.Features.ProductFeatures.Queries;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {

        private readonly IMediator _mediator;
        private IWeatherService _weatherService;
        public ClassController(IMediator mediator, IWeatherService weatherService)
        {
            _mediator = mediator;
            _weatherService = weatherService;
        }

        /// <summary>
        /// Get all classes details.
        /// </summary>
        /// <param></param>
        /// <returns>Get all classes</returns>
        [HttpGet("get-all-class")]
        public async Task<IActionResult> GetAllClassAsync()
        {
            try
            {
                var query = new GetAllClassQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the weather details of city.
        /// </summary>
        /// <param>city</param>
        /// <returns>WeatherDataInformation</returns>
        [HttpGet("city")]
        public async Task<IActionResult> GetCityWeatherInformation([FromQuery] string city)
        {
            try
            {
                var query = new GetCityWeatherQuery(city);
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the 3 hourly 5 days weather details of city.
        /// </summary>
        /// <param>latiture, longitude</param>
        /// <returns>WeatherForecastDetails</returns>
        [HttpGet("hourly-forcast")]
        public async Task<IActionResult> GetHourlyCityWeatherInformation([FromQuery] double latitude, [FromQuery] double longitude)
        {
            try
            {
                var query = new GetHourlyCityWeatherQuery(latitude, longitude);
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
