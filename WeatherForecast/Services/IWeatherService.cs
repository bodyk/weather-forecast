using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherForecast.Helpers;

namespace WeatherForecast.Services
{
    public interface IWeatherService
    {
        Task<DetailedWeatherInfo> GetInfoByCity(string cityName, int countDays);
    }
}