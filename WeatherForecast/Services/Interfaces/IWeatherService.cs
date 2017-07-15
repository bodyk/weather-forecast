using System.Threading.Tasks;
using WeatherForecast.Models.Interfaces;

namespace WeatherForecast.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<IDetailedWeatherInfo> GetInfoByCity(string cityName, int countDays);
    }
}