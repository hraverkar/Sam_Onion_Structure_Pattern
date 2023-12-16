using Application.Features.ProductFeatures.Queries;
using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.QueryHandlers
{
    internal class GetCityWeatherQueryHandler : IRequestHandler<GetCityWeatherQuery, WeatherDataInformation>
    {
        public IWeatherService _weatherService { get; set; }
        public GetCityWeatherQueryHandler(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        public Task<WeatherDataInformation> Handle(GetCityWeatherQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var result = _weatherService.CityAsync(request.City);
            return result;
        }
    }
}
