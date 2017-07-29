using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Services.Implementations;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Api
{
    public class WeatherInfoController : ApiController
    {
        private readonly IWeatherService _weatherService;
        private readonly IUnitOfWorkService _unitOfWorkService;


        public WeatherInfoController(IWeatherService weatherService, IUnitOfWorkService unitOfWorkService)
        {
            _weatherService = weatherService;
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/WeatherInfo/{cityName}/{countDays}
        [Route("api/WeatherInfo/{cityName}/{countDays}")]
        public async Task<HttpResponseMessage> GetWeather(string cityName, int countDays)
        {
            if (string.IsNullOrEmpty(cityName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "City name can not be empty");

            if (countDays < 1 || countDays > 7)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The forecast can only be given in the next 1-7 days");

            var res = await _weatherService.GetInfoByCity(cityName, countDays);

            _unitOfWorkService.AddHistoryItem(new RequestHistoryEntity
            {
                RequestTime = DateTime.Now,
                WeatherEntity = res.GetEntity()
            });

            if (res == null)
            {
                HttpError err = new HttpError($"City with name = {cityName} not found");
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}
