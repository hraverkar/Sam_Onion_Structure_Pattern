using Domain.LocalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherDataInformation> CityAsync(string city);
        Task<WeatherForecastDetails> GetHourlLatLongAsync(double latitude, double longitude);
    }
}
