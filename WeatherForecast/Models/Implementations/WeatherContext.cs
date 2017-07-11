using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base()
        {
            Database.SetInitializer(new WeatherCitiesInitializer());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherEntity> Infos { get; set; }
        public DbSet<RequestHistoryEntity> HistoryOfRequests { get; set; }
    }
}