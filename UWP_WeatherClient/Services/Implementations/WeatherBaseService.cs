using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UWP_WeatherClient.Services.Implementations
{
    public abstract class WeatherBaseService
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

        public async Task<bool> PostResponse<T>(T data, string request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(data);
                response = await client.PostAsync(request, new StringContent(json));

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> DeleteResponse(string request)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                response = await client.DeleteAsync(request);

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
