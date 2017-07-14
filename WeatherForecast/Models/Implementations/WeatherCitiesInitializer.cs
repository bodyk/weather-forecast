using System.Collections.Generic;
using System.Data.Entity;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Implementations
{
    public class WeatherCitiesInitializer : CreateDatabaseIfNotExists<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            IList<City> defaultCities = new List<City>
            {
                new City {Name = "Kiev"},
                new City {Name = "Lviv"},
                new City {Name = "Kharkiv"},
                new City {Name = "Dnipropetrovsk"},
                new City {Name = "Odessa"}
            };

            context.Cities.AddRange(defaultCities);
            base.Seed(context);
        }
    }
}