using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UWP_WeatherClient.Models
{
    public class WeatherEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CityName { get; set; }

        public string CountryCode { get; set; }

        public int CountForecastDays { get; set; }

        [Required]
        public virtual ICollection<SingleDayInfoEntity> DayInfoEntities { get; set; }
    }
}