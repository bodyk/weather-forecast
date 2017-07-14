using System.Collections.Generic;
using WeatherForecast.Models.Entities;

namespace WeatherForecast.Models.Interfaces
{
    public interface IDetailedWeatherInfo
    {
        int Id { get; set; }

        string CityName { get; set; }

        string CountryCode { get; set; }

        int CountForecastDays { get; set; }

        List<SingleDayInfoEntity> GetWeatherParams();

        WeatherEntity GetEntity();
    }
}