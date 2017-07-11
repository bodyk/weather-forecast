using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class SingleDayInfoEntity
    {
        public int Id { get; set; }

        public string Temperature { get; set; }

        public string Humidity { get; set; }

        public string Pressure { get; set; }

        public string WindSpeed { get; set; }

        public string Clouds { get; set; }

        public string Date { get; set; }

        public string IconPath { get; set; }
    }
}