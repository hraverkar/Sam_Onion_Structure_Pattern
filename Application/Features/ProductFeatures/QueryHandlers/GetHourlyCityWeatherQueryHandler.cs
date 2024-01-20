using Application.Features.ProductFeatures.Queries;
using Application.Interfaces;
using Domain.LocalDtos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.QueryHandlers
{
    public class GetHourlyCityWeatherQueryHandler : IRequestHandler<GetHourlyCityWeatherQuery, WeatherForecastDetails>
    {
        private readonly IWeatherService _weatherService;
        public GetHourlyCityWeatherQueryHandler(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        Task<WeatherForecastDetails> IRequestHandler<GetHourlyCityWeatherQuery, WeatherForecastDetails>.Handle(GetHourlyCityWeatherQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var result = _weatherService.GetHourlLatLongAsync(Math.Round(request.Latitude, 2), Math.Round(request.Longitude, 2));
            return result;
        }
    }
}
