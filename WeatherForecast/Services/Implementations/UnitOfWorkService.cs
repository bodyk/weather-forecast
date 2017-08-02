using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Services.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly UnitOfWork _unitOfWork;
        public UnitOfWorkService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public UnitOfWorkService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCity(City item)
        {
            _unitOfWork.Cities.Create(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _unitOfWork.Cities.GetAll();
        }

        public async Task<City> FindCity(string cityName)
        {
            return await _unitOfWork.Cities.Get(cityName);
        }

        public async Task RemoveCity(City city)
        {
            _unitOfWork.Cities.Delete(city);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCity(City item)
        {
            _unitOfWork.Cities.Update(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddHistoryItem(RequestHistoryEntity item)
        {
            _unitOfWork.HistoryItems.Create(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task ClearHistory()
        {
            _unitOfWork.HistoryItems.Clear();
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RequestHistoryEntity>> GetHistory()
        {
            return await _unitOfWork.HistoryItems.GetAll();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}