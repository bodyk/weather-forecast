using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation.Metadata;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services;
using UWP_WeatherClient.Services.Implementations;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.ViewModels
{
    class WeatherInfoViewModel : BaseViewModel
    {
        private List<IDetailedWeatherInfo> _model;
        private readonly INavigationService _navigationService;
        private readonly IWeatherDataService _service;

        public string CityName { get; set; }

        public int CountDays { get; set; }

        public WeatherInfoViewModel(INavigationService navigationService)
        {
            _model = new List<IDetailedWeatherInfo>();

            _navigationService = navigationService;

            _service = new WeatherDataService();

            ShowWeatherCommand = new RelayCommand(showWeather);

            Title = "Weather Info";
        }

        public async Task<IDetailedWeatherInfo> GetInfoByCity(string cityName, int countDays)
        {
            return await _service.GetInfoByCity(cityName, countDays);
        }

        public ICommand ShowWeatherCommand { get; set; }

        public IDetailedWeatherInfo WeatherForecast { get; private set; }


        private async void showWeather()
        {
            WeatherForecast = await GetInfoByCity(CityName, CountDays);
            RaisePropertyChanged(() => WeatherForecast);
        }
    }
}
