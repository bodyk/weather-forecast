using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services.Implementations;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        private List<RequestHistoryEntity> _model;
        private readonly INavigationService _navigationService;
        private readonly IHistoryService _service;


        public HistoryViewModel(INavigationService navigationService)
        {
            _model = new List<RequestHistoryEntity>();

            _navigationService = navigationService;
            _service = new HistoryService();
            Title = "History Info";
        }

        public async Task<List<RequestHistoryEntity>> GetHistory()
        {
            return await _service.GetHistory();
        }
    }
}
