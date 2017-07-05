﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class WeatherInfoService
    {
        private WeatherInfo weatherInfo;

        public WeatherInfoService()
        {
            weatherInfo = new WeatherInfo();
        }

        public WeatherInfo GetInfos()
        {
            return weatherInfo;
        }

        public RootWeatherInfo GetInfoByCity(string cityName, int countDays)
        {
            RootWeatherInfo rootObject = new RootWeatherInfo();
            if (cityName != null)
            {
                /*Calling API http://openweathermap.org/api */
                string apiKey = "af9f860fa9d00a8c953339a9a354d6b4";
                HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + cityName + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
                /*End*/

                /*http://json2csharp.com*/
                rootObject = JsonConvert.DeserializeObject<RootWeatherInfo>(apiResponse);
            }

            return rootObject;
        }
    }
}