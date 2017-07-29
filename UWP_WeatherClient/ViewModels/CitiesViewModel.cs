using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
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
        private readonly ICityService _service;


        public CitiesViewModel(INavigationService navigationService, ICityService service)
            :base(navigationService)
        {
            _model = new List<City>();

            GetCitiesCommand = new RelayCommand(GetCities);

            _service = service;
            Title = "Default Cities";
        }

        public ICommand GetCitiesCommand { get; set; }

        public List<City> Cities { get; private set; }

        public async void GetCities()
        {
            Cities = await _service.GetCities();
            RaisePropertyChanged(() => Cities);
        }

        protected override void OnPageLoad()
        {
            GetCities();
        }
    }
}
