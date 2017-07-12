using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services;

namespace WeatherForecast.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

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
            kernel.Bind<IWeatherRepository>().To<OpenWeatherRepository>();
        }
    }
}