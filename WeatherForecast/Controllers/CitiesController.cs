using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public CitiesController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: Cities
        public async Task<ActionResult> Index()
        {
            return View(await _unitOfWorkService.GetAllCities());
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                _unitOfWorkService.AddCity(city);
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<ActionResult> Edit(string cityName)
        {
            if (cityName == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var city = await _unitOfWorkService.FindCity(cityName);
            if (city == null)
                return HttpNotFound();
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkService.UpdateCity(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<ActionResult> Delete(string cityName)
        {
            if (cityName == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var city = await _unitOfWorkService.FindCity(cityName);
            if (city == null)
                return HttpNotFound();
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string cityName)
        {
            if (cityName != null)
            {
                City city = await _unitOfWorkService.FindCity(cityName);

                if (city != null)
                {
                    await _unitOfWorkService.RemoveCity(city);
                }
            }

            return RedirectToAction("Index");
        }
    }
}