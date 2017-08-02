using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;

namespace WeatherForecast.Models.Implementations
{
    public class RequestHistoryRepository : IRepository<RequestHistoryEntity>
    {
        private readonly WeatherContext _context;

        public RequestHistoryRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RequestHistoryEntity>> GetAll()
        {
            return await _context.HistoryOfRequests.ToArrayAsync();
        }

        async Task<RequestHistoryEntity> IRepository<RequestHistoryEntity>.Get(int id)
        {
            return await _context.HistoryOfRequests.FirstOrDefaultAsync(h => h.Id == id);
        }

        public Task<RequestHistoryEntity> Get(string name)
        {
            throw new NotImplementedException();
        }

        public void Create(RequestHistoryEntity item)
        {
            _context.HistoryOfRequests.Add(item);
        }

        public void Update(RequestHistoryEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(RequestHistoryEntity item)
        {
            _context.HistoryOfRequests.Remove(item);
        }

        public void Clear()
        {
            _context.HistoryOfRequests.RemoveRange(_context.HistoryOfRequests);
        }
    }
}