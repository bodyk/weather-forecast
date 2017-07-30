using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.Services.Implementations
{
    class HistoryService : WeatherBaseService, IHistoryService
    {
        public async Task<List<RequestHistoryEntity>> GetHistory()
        {
            var rootObject = await GetResponse(new List<RequestHistoryEntity>(), $"{ApiPath}History/");
            return rootObject;
        }

        public async Task<bool> ClearHistory()
        {
            return await DeleteResponse($"{ApiPath}History/");
        }
    }
}
