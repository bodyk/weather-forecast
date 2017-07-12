using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace WeatherForecast.Models.Entities
{
    public class RequestHistoryEntity
    {
        public int Id { get; set; }

        public DateTime RequestTime { get; set; }

        [ForeignKey("WeatherEntity")]
        public int WeatherEntity_Id { get; set; }
        public virtual WeatherEntity WeatherEntity { get; set; }
    }
}