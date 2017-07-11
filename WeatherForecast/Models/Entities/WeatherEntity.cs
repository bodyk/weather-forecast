using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Models.Entities
{
    public class WeatherEntity
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public string CountryCode { get; set; }

        public int CountForecastDays { get; set; }

        public ICollection<SingleDayInfoEntity> DayInfoEntities { get; set; }

        public virtual RequestHistoryEntity HistoryInfo { get; set; }
    }
}