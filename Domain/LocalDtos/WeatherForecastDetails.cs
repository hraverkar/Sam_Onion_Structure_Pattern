using System;
using System.Collections.Generic;

namespace Domain.LocalDtos
{
    public class WeatherForecastDetails
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<WeatherDetails> List { get; set; }
        public City City { get; set; }
    }

    public class WeatherDetails
    {

        private string dt;
        public string Dt
        {
            get { return dt; }
            set { dt = getLocalTime(value); }
        }
        public string getLocalTime(string value)
        {
            DateTime sunriseDateTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(value)).DateTime;
            TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianSunrise = TimeZoneInfo.ConvertTimeFromUtc(sunriseDateTime, indianTimeZone);
            // string formattedSunrise = indianSunrise.ToString("hh:mm:ss tt");
            return indianSunrise.ToString();
        }
        public MainData Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public int Pop { get; set; }
        public Sys Sys { get; set; }
        public string DtTxt { get; set; }


    }

    public class MainData
    {
        private double temp;
        public double Temp
        {
            get { return temp; }
            set { temp = (int)Math.Round(value, MidpointRounding.AwayFromZero) - 273.5; }
        }

        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public int Humidity { get; set; }
        public double TempKf { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Sys
    {
        public string Pod { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        
        private string sunrise;
        public string Sunrise
        {
            get { return sunrise; }
            set { sunrise = getLocalTime(value); }
        }

        private string sunset;
        public string Sunset
        {
            get { return sunset; }
            set { sunset = getLocalTime(value); }
        }
        public string getLocalTime(string value)
        {
            DateTime sunriseDateTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(value)).DateTime;
            TimeZoneInfo indianTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianSunrise = TimeZoneInfo.ConvertTimeFromUtc(sunriseDateTime, indianTimeZone);
            string formattedSunrise = indianSunrise.ToString("hh:mm:ss tt");
            return formattedSunrise;
        }
    }

    public class Coord
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
