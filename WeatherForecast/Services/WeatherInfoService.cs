using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherForecast.HelperClasses;
using WeatherForecast.Models;

namespace WeatherForecast.Services
{
    public class WeatherInfoService
    {
        private WeatherInfo infos;

        public WeatherInfoService()
        {
            infos = new WeatherInfo();
            infos.infos.Add(new RootWeatherInfo { city = new City { name = "Kiev" } });
            infos.infos.Add(new RootWeatherInfo { city = new City { name = "Lviv" } });
            infos.infos.Add(new RootWeatherInfo { city = new City { name = "Kharkiv" } });
            infos.infos.Add(new RootWeatherInfo { city = new City { name = "Dnipropetrovsk" } });
            infos.infos.Add(new RootWeatherInfo { city = new City { name = "Odessa" } });
        }

        public WeatherInfo GetInfos()
        {
            return infos;
        }
    }
}