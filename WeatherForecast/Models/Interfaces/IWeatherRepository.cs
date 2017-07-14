using System.Collections.Generic;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Interfaces
{
    public interface IWeatherRepository
    {
        City AddCity(City item);
        IEnumerable<City> GetAllCities();
        City FindCity(string cityName);
        void RemoveCity(string cityName);
        void UpdateCity(City item);
        void AddHistoryItem(RequestHistoryEntity item);
        void ClearHistory();
        void AddWeatherEntity(WeatherEntity weather);
        IEnumerable<WeatherEntity> GetWeatherInfo();
        ICollection<RequestHistoryEntity> GetHistory();
    }
}