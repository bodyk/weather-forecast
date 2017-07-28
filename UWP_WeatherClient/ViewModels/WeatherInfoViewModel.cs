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
    class WeatherInfoViewModel : BaseViewModel
    {
        private List<City> _model;
        private readonly INavigationService _navigationService;
        private readonly ICityService _service;

        public WeatherInfoViewModel(INavigationService navigationService)
        {
            _model = new List<City>();

            _navigationService = navigationService;

            _service = new CityService();
            GetCities();
            Title = "Weather Info";
        }

        public async void GetCities()
        {
            var cities = await _service.GetCities();
            var res = await _service.PostCity(new City{Name = "Adler", Id = 10});

            int a = 2;
        }
    }
}
