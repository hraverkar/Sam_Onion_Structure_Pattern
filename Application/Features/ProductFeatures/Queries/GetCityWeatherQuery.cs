using Application.Interfaces;
using MediatR;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetCityWeatherQuery : IRequest<WeatherDataInformation>
    {
        public string City { get; set; }
        public GetCityWeatherQuery(string city)
        {
            City = city;
        }
    }
}
