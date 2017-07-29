using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UWP_WeatherClient.Models
{
    public interface IDetailedWeatherInfo
    {
        int Id { get; set; }

        string CityName { get; set; }

        string CountryCode { get; set; }

        int CountForecastDays { get; set; }

        List<SingleDayInfoEntity> WeatherParams { get; set; }
    }
}