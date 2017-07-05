using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast.Helpers;

namespace WeatherForecast.Models
{
    public class WeatherInfo
    {
        public WeekWeatherInfo weatherInfo { get; set; } = new WeekWeatherInfo();
    }
}