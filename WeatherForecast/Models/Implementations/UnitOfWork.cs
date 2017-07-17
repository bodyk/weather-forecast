using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecast.Models.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly WeatherContext _context;

        public UnitOfWork()
        {
            _context = new WeatherContext();
        }

        public UnitOfWork(WeatherContext context)
        {
            _context = context;
        }

        private CityRepository _cityRepository;
        private RequestHistoryRepository _historyRepository;
        private WeatherRepository _weatherRepository;

        public CityRepository Cities => 
            _cityRepository ?? (_cityRepository = new CityRepository(_context));

        public RequestHistoryRepository HistoryItems => 
            _historyRepository ?? (_historyRepository = new RequestHistoryRepository(_context));

        public WeatherRepository WetherInfos => 
            _weatherRepository ?? (_weatherRepository = new WeatherRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}