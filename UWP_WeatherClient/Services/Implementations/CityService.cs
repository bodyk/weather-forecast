using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.Services.Implementations
{
    class CityService : WeatherBaseService, ICityService
    {
        private static string _detailedPath = "Cities";

        public async Task<List<City>> GetCities()
        {
            var rootObject = await GetResponse(new List<City>(), $"{ApiPath}{_detailedPath}/");
            return rootObject;
        }

        public async Task<City> GetCity(string cityName)
        {
            var rootObject = await GetResponse(new City(), $"{ApiPath}{_detailedPath}/{cityName}");
            return rootObject;
        }

        public async Task<bool> PutCity(City city)
        {
            return await PutResponse(new Dictionary<string, string> {
                {
                    nameof(city.Name), city.Name
                },
                {
                    nameof(city.Id), city.Id.ToString()
                }
            }, $"{ApiPath}{_detailedPath}/{city.Id}");
        }

        public async Task<bool> PostCity(City city)
        {
            return await PostResponse(new Dictionary<string, string>{{nameof(city.Name), city.Name }}, $"{ApiPath}{_detailedPath}/0");
        }

        public async Task<bool> DeleteCity(string cityName)
        {
            return await DeleteResponse($"{ApiPath}{_detailedPath}/{cityName}/");
        }
    }
}
