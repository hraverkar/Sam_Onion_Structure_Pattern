using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {

        private double temp;
        public double Temp
        {
            get { return temp; }
            set { temp = (int)Math.Round(value, MidpointRounding.AwayFromZero) - 273.5; }
        }



        private double feelsLike;
        public double FeelsLike
        {
            get => feelsLike;
            set => feelsLike = value - 273.5;
        }

        private double tempMin;
        public double TempMin
        {
            get => tempMin;
            set => tempMin = value - 273.5;
        }
        private double tempMax;
        public double TempMax
        {
            get => tempMax;
            set => tempMax = value - 273.5;
        }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }

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

    public class WeatherDataInformation
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
