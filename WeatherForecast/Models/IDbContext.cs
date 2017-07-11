using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models
{
    public interface IDbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<WeatherEntity> Infos { get; set; }
    }
}
