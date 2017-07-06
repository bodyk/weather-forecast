using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast.Helpers;

namespace WeatherForecast.Models
{
    public class WeatherInfo
    {
        public DetailedWeatherInfo detailedWeatherInfo { get; set; } = new DetailedWeatherInfo();
    }
}