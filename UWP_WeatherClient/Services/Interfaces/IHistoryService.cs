using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_WeatherClient.Models;

namespace UWP_WeatherClient.Services.Interfaces
{
    interface IHistoryService
    {
        Task<List<RequestHistoryEntity>> GetHistory();
    }
}
