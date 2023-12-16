using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
