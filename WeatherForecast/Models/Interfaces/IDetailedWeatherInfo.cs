using System.Collections.Generic;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Models.Interfaces
{
    public interface IDetailedWeatherInfo
    {
        int Id { get; set; }

        List<SingleDayInfoEntity> GetWeatherParams();

        string CityName { get; set; }

        string CountryCode { get; set; }

        int CountForecastDays { get; set; }

        WeatherEntity GetEntity();
    }
}
