using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast.HelperClasses;

namespace WeatherForecast.Models
{
    public class WeatherInfo
    {
        public string apiResponse { get; set; } = "";

        public List<RootWeatherInfo> infos { get; set; } = new List<RootWeatherInfo>();
    }
}