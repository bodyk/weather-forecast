using System.Web.Mvc;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public HistoryController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: History/Index
        public ActionResult Index(bool bClear = false)
        {
            if (bClear)
            {
                _unitOfWorkService.ClearHistory();
            }
            var history = _unitOfWorkService.GetHistory();
            if (history == null)
                return HttpNotFound();

            return View(history);
        }
    }
}