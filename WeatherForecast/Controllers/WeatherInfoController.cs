using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    public class WeatherInfoController : Controller
    {
        private readonly IWeatherService _infoService;
        private readonly IWeatherRepository _repository;
        private IDetailedWeatherInfo _detailedInfo;

        public WeatherInfoController(IWeatherService serviceParam, IDetailedWeatherInfo detailedInfo,
            IWeatherRepository repository)
        {
            _infoService = serviceParam;
            _detailedInfo = detailedInfo;
            _repository = repository;
        }

        public async Task<ActionResult> Index(string customCityName, int time = 1)
        {
            ViewBag.StartupCities = _repository.GetAllCities();

            try
            {
                if (customCityName != null)
                {
                    _detailedInfo = await _infoService.GetInfoByCity(customCityName, time);
                    _repository.AddHistoryItem(new RequestHistoryEntity
                    {
                        RequestTime = DateTime.Now,
                        WeatherEntity = _detailedInfo.GetEntity()
                    });
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