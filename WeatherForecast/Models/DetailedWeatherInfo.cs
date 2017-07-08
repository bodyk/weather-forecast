using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Helpers
{
    public class DetailedWeatherInfo
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }

        /// <summary>
        /// Number of lines returned by this API call
        /// </summary>
        public int cnt { get; set; }

        /// <summary>
        /// Detailed daily weather
        /// </summary>
        public List<ListWeather> list { get; set; }
    }
}