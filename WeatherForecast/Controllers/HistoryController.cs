﻿using System.Threading.Tasks;
using System.Web.Mvc;
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
        public async Task<ActionResult> Index(bool bClear = false)
        {
            if (bClear)
            {
                await _unitOfWorkService.ClearHistory();
            }
            var history = _unitOfWorkService.GetHistory();
            if (history == null)
                return HttpNotFound();

            return View(await history);
        }
    }
}