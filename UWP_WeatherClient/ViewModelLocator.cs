using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UWP_WeatherClient.ViewModels;

namespace UWP_WeatherClient
{
    class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(CitiesViewModel), typeof(CitiesView));
            navigationService.Configure(nameof(HistoryViewModel), typeof(HistoryView));
            navigationService.Configure(nameof(WeatherInfoViewModel), typeof(WeatherInfoView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<CitiesViewModel>();
            SimpleIoc.Default.Register<HistoryViewModel>();
            SimpleIoc.Default.Register<WeatherInfoViewModel>();

            ServiceLocator.Current.GetInstance<WeatherInfoViewModel>();
        }


        // <summary>
        // Gets the City view model.
        // </summary>
        // <value>
        // The City view model.
        // </value>
        public CitiesViewModel CityVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CitiesViewModel>();
            }
        }

        // <summary>
        // Gets the History view model.
        // </summary>
        // <value>
        // The History view model.
        // </value>
        public HistoryViewModel HistoryVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HistoryViewModel>();
            }
        }

        // <summary>
        // Gets the WeatherInfo view model.
        // </summary>
        // <value>
        // The WeatherInfo view model.
        // </value>
        public WeatherInfoViewModel WeatherInfoVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WeatherInfoViewModel>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
