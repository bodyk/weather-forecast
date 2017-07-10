namespace WeatherForecast.Models.OpenWeatherMapModels
{
    public class CurrentDayWeather
    {
        /// <summary>
        /// Day temperature
        /// </summary>
        public double day { get; set; }

        /// <summary>
        /// Min daily temperature
        /// </summary>
        public double min { get; set; }

        /// <summary>
        /// Max daily temperature
        /// </summary>
        public double max { get; set; }

        /// <summary>
        /// Night temperature
        /// </summary>
        public double night { get; set; }

        /// <summary>
        /// Evening temperature
        /// </summary>
        public double eve { get; set; }

        /// <summary>
        /// Morning temperature
        /// </summary>
        public double morn { get; set; }
    }
}