﻿using System.Linq;
using System.Web.Http;
using WeatherForecast.Models.Entities;
using WeatherForecast.Services.Implementations;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Api
{
    public class HistoryController : ApiController
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public HistoryController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/History
        public IQueryable<RequestHistoryEntity> GetHistory()
        {
            return (IQueryable<RequestHistoryEntity>)_unitOfWorkService.GetHistory();
        }
    }
}
