using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Models.OpenWeatherMapModels;
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

        public async Task<ActionResult> Index(int? cityId, int time = 1)
        {
            ViewBag.StartupCities = _context.Cities.ToList();

            try
            {
                var city = _context.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city != null)
                {
                    ViewBag.CurrentCityId = city.Id;
                    _detailedInfo = await _infoService.GetInfoByCity(city.Name, time);
                }
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