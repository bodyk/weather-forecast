using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models
{
    public class WeatherEntityConfiguration : EntityTypeConfiguration<IDetailedWeatherInfo>
    {
        public WeatherEntityConfiguration()
        {
            this.ToTable("WeatherInfo");

            this.HasKey(w => w.Id);

            this.Property(p => p.CityName);
            this.Property(p => p.CountryCode);
            this.Property(p => p.CountForecastDays);

        }
    }
}