using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using WeatherForecast.Models;
using System.Web.Configuration;

namespace WeatherForecast.Services
{
    public class OpenWeatherMapService : IWeatherService
    {
        public async Task<IDetailedWeatherInfo> GetInfoByCity(string cityName, int countDays)
        {
            IDetailedWeatherInfo rootObject = new OpenWeatherDetailedInfo();
            if (!string.IsNullOrEmpty(cityName))
            {
                using (HttpClient client = new HttpClient())
                {
                    var apiKey = WebConfigurationManager.AppSettings["apiKey"]; ;
                    var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/forecast/daily?q={cityName}&appid={apiKey}&units=metric&cnt={countDays}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;

                        string responseString = responseContent.ReadAsStringAsync().Result;

                        rootObject = JsonConvert.DeserializeObject<OpenWeatherDetailedInfo>(responseString);
                    }
                }
            }

            return rootObject;
        }
    }
}