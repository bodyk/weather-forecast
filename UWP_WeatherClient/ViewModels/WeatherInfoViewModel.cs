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
        private readonly IWeatherDataService _service;
        private readonly ICityService _cityService;

        public string CityName { get; set; }

        public int CountDays { get; set; } = 1;

        public WeatherInfoViewModel(INavigationService navigationService, IWeatherDataService service, ICityService cityService)
            : base(navigationService)
        {
            _model = new List<IDetailedWeatherInfo>();

            _service = service;
            _cityService = cityService;

            ShowWeatherCommand = new RelayCommand(showWeather);
            FilterCitiesCommand = new RelayCommand(FilterCities);
            FillCities();

            Title = "Weather Info";
        }

        public async Task<IDetailedWeatherInfo> GetInfoByCity(string cityName, int countDays)
        {
            return await _service.GetInfoByCity(cityName, countDays);
        }

        public ICommand ShowWeatherCommand { get; set; }
        public ICommand FilterCitiesCommand { get; set; }

        public IDetailedWeatherInfo WeatherForecast { get; private set; }

        public List<string> Cities { get; set; }
        public string SearchText { get; set; }
        private async void showWeather()
        {
            if (!string.IsNullOrEmpty(CityName))
            {
                WeatherForecast = await GetInfoByCity(CityName, CountDays);
                RaisePropertyChanged(() => WeatherForecast);
                CityName = "";
                RaisePropertyChanged(() => CityName);
            }
            
        }

        public void FilterCities()
        {
            // the search string is in SearchText Example:
            Cities = Cities.Where(c => c.Contains(SearchText.ToLower())).ToList();
        }

        public async void FillCities()
        {
            Cities = (await _cityService.GetCities()).Select(c => c.Name).ToList();
            RaisePropertyChanged(() => Cities);
        }

        protected  override void OnPageLoad()
        {
            FillCities();
            showWeather();
        }
    }
}
