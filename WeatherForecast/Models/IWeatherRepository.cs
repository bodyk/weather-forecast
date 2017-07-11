using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models
{
    public interface IWeatherRepository
    {
        void AddCity(City item);
        IEnumerable<City> GetAllCities();
        City FindCity(int? key);
        void RemoveCity(int? key);
        void UpdateCity(City item);
    }
}
