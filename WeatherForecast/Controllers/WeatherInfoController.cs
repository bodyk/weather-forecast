using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeatherForecast.HelperClasses;
using WeatherForecast.Models;
using WeatherForecast.Services;

namespace WeatherForecast.Controllers
{
    public class WeatherInfoController : Controller
    {
        private WeatherInfoService infoService;

        public WeatherInfoController()
        {
            infoService = new WeatherInfoService();
        }

        // GET: OpenWeatherMap
        public ActionResult Index()
        {
            var weatherInfo = infoService.GetInfos();
            return View(weatherInfo);
        }

        [HttpPost]
        public ActionResult Index(WeatherInfo weatherInfo, string city)
        {
            weatherInfo = infoService.GetInfos();
            if (city != null)
            {
                /*Calling API http://openweathermap.org/api */
                string apiKey = "af9f860fa9d00a8c953339a9a354d6b4";
                HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

                string apiResponse = "";
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }
                /*End*/

                /*http://json2csharp.com*/
                RootWeatherInfo rootObject = JsonConvert.DeserializeObject<RootWeatherInfo>(apiResponse);

                StringBuilder sb = new StringBuilder();
                sb.Append("<table><tr><th>Weather Description</th></tr>");
                sb.Append("<tr><td>City:</td><td>" + rootObject.city.name + "</td></tr>");
                sb.Append("<tr><td>Message:</td><td>" + rootObject.message + "</td></tr>");
                sb.Append("</table>");
                weatherInfo.apiResponse = sb.ToString();
            }
            else
            {
                if (Request.Form["submit"] != null)
                {
                    weatherInfo.apiResponse = "► Select City";
                }
            }
            return View(weatherInfo);
        }
    }

    
}