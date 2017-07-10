using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Models.OpenWeatherMapModels
{
    public class SingleDayInfo
    {
        [NotMapped]
        public Dictionary<string, string> DayInfo { get; set; }

        public string Date { get; set; }

        public string IconPath { get; set; }
    }
}