using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using UWP_WeatherClient.Commands;
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

            DeleteCityCommand = new DelegateCommand(ExecuteDeleteCommand);
            AddCityCommand = new RelayCommand(AddCity);

            _service = service;
            Title = "Default Cities";
        }

        public ICommand GetCitiesCommand { get; set; }
        public ICommand AddCityCommand { get; set; }
        public ICommand DeleteCityCommand { set; get; }

        public string NewCityName { get; set; }

        private void ExecuteDeleteCommand(object param)
        {
            _service.DeleteCity((string) param);
            GetCities();
        }

        public List<City> Cities { get; set; }

        public async void GetCities()
        {
            Cities = await _service.GetCities();
            RaisePropertyChanged(() => Cities);
        }

        public async void AddCity()
        {
            if (!string.IsNullOrEmpty(NewCityName))
            {
                await _service.PostCity(new City { Name = NewCityName });
                GetCities();
                NewCityName = "";
                RaisePropertyChanged(() => NewCityName);
            }
        }



        protected override void OnPageLoad()
        {
            GetCities();
        }
    }
}
