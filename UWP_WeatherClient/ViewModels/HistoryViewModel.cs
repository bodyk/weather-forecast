using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using UWP_WeatherClient.Models;
using UWP_WeatherClient.Services.Implementations;
using UWP_WeatherClient.Services.Interfaces;

namespace UWP_WeatherClient.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        private List<RequestHistoryEntity> _model;
        private readonly IHistoryService _service;

        public List<RequestHistoryEntity> History { get; private set; }

        public HistoryViewModel(INavigationService navigationService, IHistoryService service)
            : base(navigationService)
        {
            _model = new List<RequestHistoryEntity>();

            _service = service;

            ClearHistoryCommand = new RelayCommand(ClearHistory);

            Title = "History Info";
        }

        private async void GetHistory()
        {
            History =  await _service.GetHistory();
            RaisePropertyChanged(() => History);
        }

        public ICommand ClearHistoryCommand { get; set; }


        private async void ClearHistory()
        {
            await _service.ClearHistory();
            GetHistory();
        }

        protected override void OnPageLoad()
        {
            GetHistory();
        }
    }
}
