using System.Collections.Generic;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models
{
    public interface IDetailedWeatherInfo
    {
        int Id { get; set; }

        ICollection<SingleDayInfo> WeatherParams { get; set; }

        string CityName { get; set; }

        string CountryCode { get; set; }

        int CountForecastDays { get; set; }
    }
}
