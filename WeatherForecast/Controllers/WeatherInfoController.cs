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

        public ActionResult Index(WeatherInfo weatherInfo, string city, int time = 1)
        {
            weatherInfo.weatherInfo = _infoService.GetInfoByCity(city, time);
            return View(weatherInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }

    
}