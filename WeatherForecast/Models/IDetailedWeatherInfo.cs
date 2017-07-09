using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public interface IDetailedWeatherInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Detailed weather info by several days</returns>
        List<SingleDayInfo> GetWeatherParams();

        string GetCityName();

        string GetCountryCode();

        int GetForecastCountDays();
    }
}
