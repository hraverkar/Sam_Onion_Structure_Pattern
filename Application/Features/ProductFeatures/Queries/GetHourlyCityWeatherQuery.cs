using Domain.LocalDtos;
using MediatR;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetHourlyCityWeatherQuery : IRequest<WeatherForecastDetails>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public GetHourlyCityWeatherQuery(double latitude, double langitude)
        {
            Latitude = latitude;
            Longitude = langitude;
        }
    }
}
