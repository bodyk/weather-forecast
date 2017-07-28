using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UWP_WeatherClient.Models
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