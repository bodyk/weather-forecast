using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_WeatherClient.Models;

namespace UWP_WeatherClient.Services.Interfaces
{
    interface IWeatherDataService
    {
        Task<IDetailedWeatherInfo> GetInfoByCity(string cityName, int countDays);
    }
}
