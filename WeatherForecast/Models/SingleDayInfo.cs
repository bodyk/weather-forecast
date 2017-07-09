using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class SingleDayInfo
    {
        public Dictionary<string, string> DayInfo { get; set; }

        public string Date { get; set; }

        public string IconPath { get; set; }
    }
}