using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace UWP_WeatherClient.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected readonly INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OnLoadCommand = new RelayCommand(OnPageLoad);
        }

        public ICommand OnLoadCommand { get; set; }

        protected abstract void OnPageLoad();

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }
    }
}
