using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Helpers
{
    public class Coord
    {
        /// <summary>
        /// City geo location, longitude
        /// </summary>
        public double lon { get; set; }

        /// <summary>
        /// City geo location, latitude
        /// </summary>
        public double lat { get; set; }
    }
}