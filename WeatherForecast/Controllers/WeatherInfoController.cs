﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Index(WeatherInfo weatherInfo, string city, int time = 1)
        {
            ViewBag.StartupCities = new List<string>
            {
                "Kiev",
                "Lviv",
                "Kharkiv",
                "Dnipropetrovsk",
                "Odessa"
            };

            try
            {
                weatherInfo.detailedWeatherInfo = await _infoService.GetInfoByCity(city, time);
            }
            catch (Exception)
            {
                return View("Error");
            }
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