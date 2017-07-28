using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services;
using UWP_WeatherClient.Services.Implementations;

namespace UWP_WeatherClient.ViewModels
{
    class CitiesViewModel : BaseViewModel
    {
        private List<City> _model;
        private readonly INavigationService _navigationService;
        private readonly WeatherDataService _service;

        public CitiesViewModel(INavigationService navigationService)
        {
            _model = new List<City>();

            _navigationService = navigationService;

            _service = new WeatherDataService();
            Title = "Default Cities";
        }

    }
}
