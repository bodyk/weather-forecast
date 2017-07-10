using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Configuration;

namespace WeatherForecast.Models.OpenWeatherMapModels
{
    public class OpenWeatherDetailedInfo : IDetailedWeatherInfo
    {
        public int Id { get; set; }

        public string CityName
        {
            get
            {
                return city?.Name ?? "";
            }
            set
            {
                if (city != null && city.Name != null)
                {
                    city.Name = value;
                }
            }
        }

        public string CountryCode
        {
            get
            {
                return city?.country ?? "";
            }
            set
            {
                if (city != null && city.country != null)
                {
                    city.country = value;
                }
            }
        }
        public int CountForecastDays
        {
            get
            {
                return cnt;
            }
            set
            {
                cnt = value;
            }
        }
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }

        /// <summary>
        /// Number of lines returned by this API call
        /// </summary>
        public int cnt { get; set; }

        /// <summary>
        /// Detailed daily weather
        /// </summary>
        public List<ListWeather> list { get; set; }
        public ICollection<SingleDayInfo> WeatherParams
        {
            get
            {
                return GetWeatherParams();
            }
            set
            {

            }
        }

        private List<SingleDayInfo> GetWeatherParams()
        {
            var allDaysWeather = new List<SingleDayInfo>();
            if (list == null)
                return allDaysWeather;
            foreach (var info in list)
            {
                SingleDayInfo dayInfo = new SingleDayInfo
                {
                    Date = UnixTimeStampToDateTime(info.dt),
                    IconPath = FormIconPath(info.weather[0].icon),
                    DayInfo = new Dictionary<string, string>
                    {
                        {"Temperature", $@"{info.temp.day.ToString(CultureInfo.InvariantCulture)} °С"},
                        {"Humidity", $"{info.humidity.ToString()} %"},
                        {"Pressure", $"{info.pressure.ToString(CultureInfo.InvariantCulture)} hPa"},
                        {"Wind Speed", $"{info.speed.ToString(CultureInfo.InvariantCulture)} meter/sec"},
                        {"Clouds", $"{info.clouds.ToString(CultureInfo.InvariantCulture)} %"}
                    }
                };

                allDaysWeather.Add(dayInfo);
            }

            return allDaysWeather;
        }

        private string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime();
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToString(CultureInfo.InvariantCulture);
        }

        private string FormIconPath(string iconName)
        {
            return $"{WebConfigurationManager.AppSettings["iconPath"]}" +
                   $"{iconName}" +
                   $"{WebConfigurationManager.AppSettings["iconExtension"]}";
        }

        public int GetForecastCountDays()
        {
            return cnt;
        }
    }
}