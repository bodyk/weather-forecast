using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddCity(City item)
        {
            _unitOfWork.Cities.Create(item);
            _unitOfWork.Save();
        }

        public IEnumerable<City> GetAllCities()
        {
            return _unitOfWork.Cities.GetAll();
        }

        public City FindCity(string cityName)
        {
            return _unitOfWork.Cities.Get(cityName);
        }

        public void RemoveCity(City city)
        {
            _unitOfWork.Cities.Delete(city);
            _unitOfWork.Save();
        }

        public void UpdateCity(City item)
        {
            _unitOfWork.Cities.Update(item);
            _unitOfWork.Save();
        }

        public void AddHistoryItem(RequestHistoryEntity item)
        {
            _unitOfWork.HistoryItems.Create(item);
            _unitOfWork.Save();
        }

        public void ClearHistory()
        {
            _unitOfWork.HistoryItems.Clear();
            _unitOfWork.Save();
        }

        public IEnumerable<RequestHistoryEntity> GetHistory()
        {
            return _unitOfWork.HistoryItems.GetAll();
        }
    }
}