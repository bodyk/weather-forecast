using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Services;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Controllers
{
    public class WeatherInfoController : Controller
    {
        private readonly IWeatherService _infoService;
        private readonly IUnitOfWorkService _unitOfWorkService;
        private IDetailedWeatherInfo _detailedInfo;

        public WeatherInfoController(IWeatherService serviceParam, IDetailedWeatherInfo detailedInfo,
            IUnitOfWorkService unitOfWorkService)
        {
            _infoService = serviceParam;
            _detailedInfo = detailedInfo;
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<ActionResult> Index(string customCityName, int time = 1)
        {
            ViewBag.StartupCities = _unitOfWorkService.GetAllCities();

            try
            {
                if (customCityName != null)
                {
                    _detailedInfo = await _infoService.GetInfoByCity(customCityName, time);

                    _unitOfWorkService.AddHistoryItem(new RequestHistoryEntity
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