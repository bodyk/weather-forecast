using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.Services.Implementations
{
    class WeatherDataService : OpenWeatherService, IWeatherDataService
    {
        public async Task<IDetailedWeatherInfo> GetInfoByCity(string cityName, int countDays)
        {
            var rootObject = await GetResponse(new OpenWeatherDetailedInfo(), $"{ApiPath}/WeatherInfo/{cityName}/{countDays}");
            return rootObject;
        }
    }
}
