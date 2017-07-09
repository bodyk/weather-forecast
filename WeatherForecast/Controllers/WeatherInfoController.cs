using System;
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
        private readonly IWeatherService _infoService;
        private IDetailedWeatherInfo _detailedInfo;

        public WeatherInfoController(IWeatherService serviceParam, IDetailedWeatherInfo detailedInfo)
        {
            _infoService = serviceParam;
            _detailedInfo = detailedInfo;
        }

        public async Task<ActionResult> Index(string city, int time = 1)
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
                _detailedInfo = await _infoService.GetInfoByCity(city, time);
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(_detailedInfo);
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