using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UWP_WeatherClient.Models;
using HttpClient = System.Net.Http.HttpClient;
using HttpResponseMessage = System.Net.Http.HttpResponseMessage;

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

        public async Task<bool> PostResponse(Dictionary<string, string> dict, string request)
        {
            using (var client = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(dict))
                {
                    using (var response = await client.PostAsync(request, content))
                    {
                        try
                        {
                            response.EnsureSuccessStatusCode();
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                        return response.StatusCode == System.Net.HttpStatusCode.OK;
                    }
                }
            }
        }

        public async Task<bool> PutResponse(Dictionary<string, string> dict, string request)
        {
            using (var client = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(dict))
                {
                    using (var response = await client.PutAsync(request, content))
                    {
                        try
                        {
                            response.EnsureSuccessStatusCode();
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                        return response.StatusCode == System.Net.HttpStatusCode.OK;
                    }
                }
            }
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
