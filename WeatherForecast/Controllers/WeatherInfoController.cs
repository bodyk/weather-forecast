using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    public class WeatherInfoController : Controller
    {
        private readonly WeatherInfoService _infoService;

        public WeatherInfoController()
        {
            _infoService = new WeatherInfoService();
        }

        // GET: OpenWeatherMap
        public ActionResult Index()
        {
            var weatherInfo = _infoService.GetInfos();
            return View(weatherInfo);
        }

        [HttpPost]
        public ActionResult Index(WeatherInfo weatherInfo, string city)
        {
            if (city != null)
            {
                weatherInfo.weatherInfo = _infoService.GetInfoByCity(city, 1);
                return View("CurrentDayWeather", weatherInfo);
            }
            else
            {
                if (Request.Form["submit"] != null)
                {
                    weatherInfo.apiResponse = "► Select City";
                }
                return View();
            }
            
        }

    }

    
}