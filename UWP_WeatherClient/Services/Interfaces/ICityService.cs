using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_WeatherClient.Models;

namespace UWP_WeatherClient.Services.Interfaces
{
    interface ICityService
    {
        Task<List<City>> GetCities();

        Task<City> GetCity(string cityName);

        Task<bool> PutCity(City cityName);

        Task<bool> PostCity(City city);

        Task<bool> DeleteCity(string cityName);
    }
}
