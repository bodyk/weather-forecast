using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UWP_WeatherClient.Services.Implementations
{
    public abstract class OpenWeatherService
    {
        protected static string ApiPath = "http://localhost:3344/api/";

        public async Task<T> GetResponse<T>(T responseInstance, string request)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    var responseString = responseContent.ReadAsStringAsync().Result;

                    responseInstance = JsonConvert.DeserializeObject<T>(responseString);
                }
            }

            return responseInstance;
        }
    }
}
