using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UWP_WeatherClient.Models
{
    public class OpenWeatherDetailedInfo : IDetailedWeatherInfo
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }

        /// <summary>
        ///     Number of lines returned by this API call
        /// </summary>
        public int cnt { get; set; }

        /// <summary>
        ///     Detailed daily weather
        /// </summary>
        public List<ListWeather> list { get; set; }

        public int Id { get; set; }

        public string CityName
        {
            get { return city?.Name ?? ""; }
            set
            {
                if (city?.Name != null)
                    city.Name = value;
            }
        }

        public string CountryCode
        {
            get { return city?.country ?? ""; }
            set
            {
                if (city?.country != null)
                    city.country = value;
            }
        }

        public int CountForecastDays
        {
            get { return cnt; }
            set { cnt = value; }
        }

        public WeatherEntity GetEntity()
        {
            return new WeatherEntity
            {
                CityName = CityName,
                CountForecastDays = CountForecastDays,
                CountryCode = CountryCode,
                DayInfoEntities = GetWeatherParams()
            };
        }

        public List<SingleDayInfoEntity> GetWeatherParams()
        {
            var allDaysWeather = new List<SingleDayInfoEntity>();

            return allDaysWeather;
        }

        private string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString(CultureInfo.InvariantCulture);
        }

        public int GetForecastCountDays()
        {
            return cnt;
        }
    }
}