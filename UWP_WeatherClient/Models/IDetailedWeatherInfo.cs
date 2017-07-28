using System.Collections.Generic;

namespace UWP_WeatherClient.Models
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