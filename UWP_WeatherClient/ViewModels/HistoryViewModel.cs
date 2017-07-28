using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using UWP_WeatherClient.Models;

namespace UWP_WeatherClient.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        private List<RequestHistoryEntity> _model;
        private readonly INavigationService _navigationService;

        public HistoryViewModel(INavigationService navigationService)
        {
            _model = new List<RequestHistoryEntity>();

            _navigationService = navigationService;

            Title = "History Info";
        }
    }
}
