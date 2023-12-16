using Application.Interfaces;
using Domain.LocalDtos;
using ExcelDataReader.Log;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "a3f07567f71036c71a8e7a860b66a706";
        public WeatherService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
            };
        }
        public async Task<WeatherDataInformation> CityAsync(string city)
        {
            WeatherDataInformation? weatherDataInformation = null;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"weather?appid={this._apiKey}&q={city}");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherDataInformation>(stringResult);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return weatherDataInformation;
        }

        public async Task<WeatherForecastDetails> GetHourlLatLongAsync(double latitude, double longitude)
        {
            WeatherForecastDetails? weatherDataInformation = null;
            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync($"forecast?lat={latitude}&lon={longitude}&appid={this._apiKey}");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<WeatherForecastDetails>(stringResult);
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return weatherDataInformation;
        }
    }
}
