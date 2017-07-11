using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherContext _context;

        public WeatherRepository(WeatherContext context)
        {
            _context = context;
        }
        public void AddCity(City item)
        {
            _context.Cities.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities.ToList();
        }

        public City FindCity(int? key)
        {
            return _context.Cities.FirstOrDefault(t => t.Id == key);
        }

        public void RemoveCity(int? key)
        {
            var entity = _context.Cities.First(t => t.Id == key);
            _context.Cities.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateCity(City item)
        {
            //_context.Cities.AddOrUpdate(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}