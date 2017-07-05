using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.HelperClasses
{
    public class RootWeatherInfo
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<ListWeather> list { get; set; }
    }
}