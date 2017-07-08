﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using WeatherForecast.Helpers;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class OpenWeatherMapService : IWeatherService
    {
        private readonly WeatherInfo _weatherInfo;

        public OpenWeatherMapService()
        {
            _weatherInfo = new WeatherInfo();
        }

        public WeatherInfo GetInfos()
        {
            return _weatherInfo;
        }

        public async Task<DetailedWeatherInfo> GetInfoByCity(string cityName, int countDays)
        {
            DetailedWeatherInfo rootObject = new DetailedWeatherInfo();
            if (!string.IsNullOrEmpty(cityName))
            {
                using (HttpClient client = new HttpClient())
                {
                    var apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["apiKey"]; ;
                    var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/forecast/daily?q={cityName}&appid={apiKey}&units=metric&cnt={countDays}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;

                        string responseString = responseContent.ReadAsStringAsync().Result;

                        rootObject = JsonConvert.DeserializeObject<DetailedWeatherInfo>(responseString);
                    }
                }
            }

            return rootObject;
        }
    }
}