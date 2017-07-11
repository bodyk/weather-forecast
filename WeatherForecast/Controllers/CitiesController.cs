using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IWeatherRepository _repository;

        public CitiesController(IWeatherRepository repository)
        {
            _repository = repository;
        }

        // GET: Cities
        public ActionResult Index()
        {
            return View(_repository.GetAllCities().ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(string cityName)
        {
            if (cityName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = _repository.FindCity(cityName);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
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
                _repository.AddCity(city);
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(string cityName)
        {
            if (cityName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = _repository.FindCity(cityName);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateCity(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(string cityName)
        {
            if (cityName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = _repository.FindCity(cityName);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string cityName)
        {
            _repository.RemoveCity(cityName);
            return RedirectToAction("Index");
        }
    }
}
