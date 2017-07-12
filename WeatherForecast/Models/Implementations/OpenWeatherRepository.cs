using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Implementations
{
    public class OpenWeatherRepository : IWeatherRepository
    {
        private readonly WeatherContext _context;

        public OpenWeatherRepository(WeatherContext context)
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
            return _context.Cities?.ToList();
        }

        public City FindCity(string cityName)
        {
            return _context.Cities.FirstOrDefault(t => t.Name == cityName);
        }

        public void RemoveCity(string cityName)
        {
            var entity = _context.Cities.First(t => t.Name == cityName);
            _context.Cities.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateCity(City item)
        {
            //_context.Cities.AddOrUpdate(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddHistoryItem(RequestHistoryEntity item)
        {
            _context.HistoryOfRequests.Add(item);
            _context.SaveChanges();
        }

        public void ClearHistory()
        {
            foreach (var entity in _context.HistoryOfRequests)
                _context.HistoryOfRequests.Remove(entity);
            _context.SaveChanges();
        }

        public ICollection<RequestHistoryEntity> GetHistory()
        {
            return _context.HistoryOfRequests.ToList();
        }
    }
}