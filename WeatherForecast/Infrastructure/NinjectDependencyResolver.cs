using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Implementations;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IWeatherService>().To<OpenWeatherMapService>();
            _kernel.Bind<IDetailedWeatherInfo>().To<OpenWeatherDetailedInfo>();
            _kernel.Bind<IUnitOfWorkService>().To<UnitOfWorkService>();
        }
    }
}