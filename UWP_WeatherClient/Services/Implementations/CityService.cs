using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.Services.Implementations
{
    class CityService : OpenWeatherService, ICityService
    {
        public async Task<List<City>> GetCities()
        {
            var rootObject = await GetResponse(new List<City>(), $"{ApiPath}Cities/");
            return rootObject;
        }
    }
}
