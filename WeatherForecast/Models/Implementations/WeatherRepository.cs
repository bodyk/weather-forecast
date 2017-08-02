using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Implementations
{
    public class WeatherRepository : IRepository<WeatherEntity>
    {
        private readonly WeatherContext _context;

        public WeatherRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherEntity>> GetAll()
        {
            return await _context.Infos.ToArrayAsync();
        }

        async Task<WeatherEntity> IRepository<WeatherEntity>.Get(int id)
        {
            return await _context.Infos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<WeatherEntity> Get(string name)
        {
            throw new NotImplementedException();
        }

        public void Create(WeatherEntity item)
        {
            _context.Infos.Add(item);
        }

        public void Update(WeatherEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(WeatherEntity item)
        {
            _context.Infos.Remove(item);
        }

        public void Clear()
        {
            _context.Infos.RemoveRange(_context.Infos);
        }
    }
}