using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Implementations
{
    public class WeatherContext : DbContext
    {
        public WeatherContext()
        {
            Database.SetInitializer(new WeatherCitiesInitializer());
        }

        public WeatherContext(DbConnection connection)
            : base(connection, true)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherEntity> Infos { get; set; }
        public DbSet<RequestHistoryEntity> HistoryOfRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}