using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Models.OpenWeatherMapModels
{
    public class City
    {
        /// <summary>
        ///     City identification
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     City name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     City coordinate
        /// </summary>
        [NotMapped]
        public Coord coord { get; set; }

        /// <summary>
        ///     Country code (GB, JP etc.)
        /// </summary>
        [NotMapped]
        public string country { get; set; }

        /// <summary>
        ///     Country population
        /// </summary>
        [NotMapped]
        public int population { get; set; }
    }
}