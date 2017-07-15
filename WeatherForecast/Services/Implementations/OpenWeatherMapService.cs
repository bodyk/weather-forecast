using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using Newtonsoft.Json;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Services.Implementations
{
    public class OpenWeatherMapService : IWeatherService
    {
        public async Task<IDetailedWeatherInfo> GetInfoByCity(string cityName, int countDays)
        {
            IDetailedWeatherInfo rootObject = new OpenWeatherDetailedInfo();
            if (!string.IsNullOrEmpty(cityName))
                using (var client = new HttpClient())
                {
                    var apiKey = WebConfigurationManager.AppSettings["apiKey"];

                    var response = await client.GetAsync(
                        $"http://api.openweathermap.org/data/2.5/forecast/daily?q={cityName}&appid={apiKey}&units=metric&cnt={countDays}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;

                        var responseString = responseContent.ReadAsStringAsync().Result;

                        rootObject = JsonConvert.DeserializeObject<OpenWeatherDetailedInfo>(responseString);
                    }
                }

            return rootObject;
        }
    }
}