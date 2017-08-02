using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Services.Interfaces
{
    public interface IUnitOfWorkService : IDisposable
    {
        Task AddCity(City item);

        Task<IEnumerable<City>> GetAllCities();

        Task<City> FindCity(string cityName);

        Task RemoveCity(City city);

        Task UpdateCity(City item);

        Task AddHistoryItem(RequestHistoryEntity item);

        Task ClearHistory();

        Task<IEnumerable<RequestHistoryEntity>> GetHistory();
    }
}
