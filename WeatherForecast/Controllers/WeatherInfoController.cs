using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    public class WeatherInfoController : Controller
    {
        private readonly IWeatherService _infoService;
        private IDetailedWeatherInfo _detailedInfo;
        private readonly IDbContext _context;

        public WeatherInfoController(IWeatherService serviceParam, IDetailedWeatherInfo detailedInfo, IDbContext context)
        {
            _infoService = serviceParam;
            _detailedInfo = detailedInfo;
            _context = context;
        }

        public async Task<ActionResult> Index(string city, int time = 1)
        {
            ViewBag.StartupCities = _context.Cities.Select(c => c.Name).ToList();

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