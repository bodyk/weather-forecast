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
            var history = _repository.GetHistory();
            if (history == null)
                return HttpNotFound();

            return View(history);
        }
    }
}