using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Models.Entities
{
    public class WeatherEntity
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }*/

        public string CityName { get; set; }

        public string CountryCode { get; set; }

        public int CountForecastDays { get; set; }

        //[ForeignKey("DayInfoEntities")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DayInfoEntities_Id { get; set; }

        [Required]
        public virtual ICollection<SingleDayInfoEntity> DayInfoEntities { get; set; }
    }
}