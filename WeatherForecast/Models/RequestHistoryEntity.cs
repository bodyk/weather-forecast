using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models
{
    public class RequestHistoryEntity
    {
        public int Id { get; set; }

        public DateTime RequestTime { get; set; }

        public virtual ICollection<WeatherEntity> WeatherEntities { get; set; }
    }
}