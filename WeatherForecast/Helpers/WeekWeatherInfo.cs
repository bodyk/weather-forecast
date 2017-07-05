using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Helpers
{
    public class WeekWeatherInfo
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<ListWeather> list { get; set; }
    }
}