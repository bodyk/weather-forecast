using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Models.Interfaces;

namespace WeatherForecast.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IWeatherRepository _repository;

        public HistoryController(IWeatherRepository repository)
        {
            _repository = repository;
        }

        // GET: History/Index
        public ActionResult Index(bool bClear = false)
        {
            if (bClear)
                _repository.ClearHistory();
            return View(_repository.GetHistory());
        }
    }
}