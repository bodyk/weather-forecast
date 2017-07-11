using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models.Entities
{
    public class RequestHistoryEntity
    {
        public int Id { get; set; }

        public DateTime RequestTime { get; set; }

        public virtual WeatherEntity WeatherEntity { get; set; }
    }
}