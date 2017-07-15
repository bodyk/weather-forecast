using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Services.Interfaces
{
    public interface IUnitOfWorkService
    {
        void AddCity(City item);

        IEnumerable<City> GetAllCities();

        City FindCity(string cityName);

        void RemoveCity(City city);

        void UpdateCity(City item);

        void AddHistoryItem(RequestHistoryEntity item);

        void ClearHistory();

        IEnumerable<RequestHistoryEntity> GetHistory();
    }
}
