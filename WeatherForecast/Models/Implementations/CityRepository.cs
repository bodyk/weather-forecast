using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Implementations
{
    public class CityRepository : IRepository<City>
    {
        private readonly WeatherContext _context;

        public CityRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities;
        }

        City IRepository<City>.Get(int id)
        {
            return _context.Cities.FirstOrDefault(c => c.Id == id);
        }

        public City Get(string name)
        {
            return _context.Cities.FirstOrDefault(c => c.Name == name);
        }

        public void Create(City item)
        {
            _context.Cities.Add(item);
        }

        public void Update(City item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(City item)
        {
            _context.Cities.Remove(item);
        }

        public void Clear()
        {
            _context.Cities.RemoveRange(_context.Cities);
        }
    }
}