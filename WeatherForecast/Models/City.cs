using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class City
    {
        /// <summary>
        /// City identification
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// City coordinate
        /// </summary>
        public Coord coord { get; set; }

        /// <summary>
        /// Country code (GB, JP etc.)
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// Country population
        /// </summary>
        public int population { get; set; }
    }
}