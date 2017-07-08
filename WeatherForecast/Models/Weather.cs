using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Helpers
{
    public class Weather
    {
        /// <summary>
        /// Weather condition id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        public string main { get; set; }

        /// <summary>
        /// Weather condition within the group
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Weather icon id
        /// </summary>
        public string icon { get; set; }
    }
}