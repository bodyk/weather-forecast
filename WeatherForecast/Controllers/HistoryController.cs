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
            var h = _repository.GetHistory();
            foreach (var requestHistoryEntity in h)
            {
                var ent = requestHistoryEntity.WeatherEntity;
                var time = requestHistoryEntity.RequestTime;
                var dinfos = ent.DayInfoEntities;
            }
            return View(_repository.GetHistory());
        }
    }
}