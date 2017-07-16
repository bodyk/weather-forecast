using System.Threading.Tasks;
using System.Web.Http;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Services.Implementations;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Api
{
    public class WeatherInfoController : ApiController
    {
        private readonly IWeatherService _weatherService;

        public WeatherInfoController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        // GET: api/WeatherInfo/{cityName}/{countDays}
        [Route("api/WeatherInfo/{cityName}/{countDays}")]
        public async Task<IDetailedWeatherInfo> GetWeather(string cityName, int countDays)
        {
            return await _weatherService.GetInfoByCity(cityName, countDays);
        }
    }
}
