using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class WeatherInfo
    {
        public string apiResponse { get; set; } = "";

        public RootWeatherInfo weatherInfo { get; set; } = new RootWeatherInfo();

        public List<string> strartupCities = new List<string>
        {
            "Kiev",
            "Lviv",
            "Kharkiv",
            "Dnipropetrovsk",
            "Odessa"
        };
    }
}