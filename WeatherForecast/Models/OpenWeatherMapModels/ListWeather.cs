using System.Collections.Generic;

namespace WeatherForecast.Models.OpenWeatherMapModels
{
    public class ListWeather
    {
        /// <summary>
        ///     Data receiving time (unix, UTC)
        /// </summary>
        public int dt { get; set; }

        /// <summary>
        ///     Temperature
        /// </summary>
        public CurrentDayWeather temp { get; set; }

        /// <summary>
        ///     Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data)
        /// </summary>
        public double pressure { get; set; }

        /// <summary>
        ///     Humidity in %
        /// </summary>
        public int humidity { get; set; }

        public List<Weather> weather { get; set; }

        /// <summary>
        ///     Wind speed
        /// </summary>
        public double speed { get; set; }

        /// <summary>
        ///     Wind direction
        /// </summary>
        public int deg { get; set; }

        /// <summary>
        ///     Cloudiness in %
        /// </summary>
        public int clouds { get; set; }

        public double? rain { get; set; }
    }
}