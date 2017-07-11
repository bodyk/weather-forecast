using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WeatherForecast.Models;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services;

namespace WeatherForecast.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IWeatherService>().To<OpenWeatherMapService>();
            kernel.Bind<IDetailedWeatherInfo>().To<OpenWeatherDetailedInfo>();
            kernel.Bind<IWeatherRepository>().To<WeatherRepository>();
        }
    }
}