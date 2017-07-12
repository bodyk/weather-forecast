using System.Collections.Generic;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Interfaces
{
    public interface IWeatherRepository
    {
        void AddCity(City item);
        IEnumerable<City> GetAllCities();
        City FindCity(string cityName);
        void RemoveCity(string cityName);
        void UpdateCity(City item);
        void AddHistoryItem(RequestHistoryEntity item);
        void ClearHistory();
        ICollection<RequestHistoryEntity> GetHistory();
    }
}