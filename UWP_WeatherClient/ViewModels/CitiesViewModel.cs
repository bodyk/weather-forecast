using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services;
using UWP_WeatherClient.Services.Implementations;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.ViewModels
{
    class CitiesViewModel : BaseViewModel
    {
        private List<City> _model;
        private readonly INavigationService _navigationService;
        private readonly ICityService _service;


        public CitiesViewModel(INavigationService navigationService)
        {
            _model = new List<City>();

            _navigationService = navigationService;

            _service = new CityService();
            Title = "Default Cities";
        }

        public async Task<List<City>> GetCities()
        {
            return await _service.GetCities();
        }
    }
}
