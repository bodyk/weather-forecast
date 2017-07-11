using System.Data.Entity;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models
{
    public class WeatherContext : DbContext, IDbContext
    {
        public WeatherContext() : base()
        {
            Database.SetInitializer(new WeatherCitiesInitializer());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherEntity> Infos { get; set; }
    }
}