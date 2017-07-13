using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services;

namespace WeatherForecast.Tests.Service.Tests
{
    [TestFixture]
    class OpenWeatherMapServiceTests
    {
        private readonly OpenWeatherMapService _service;

        public OpenWeatherMapServiceTests()
        {
            _service = new OpenWeatherMapService();
        }

        [SetUp]
        public void TestSetup()
        {
            
        }

        [TearDown]
        public void TestTearDown()
        {
            
        }

        /*[Test]
        public async Task GetInfoByCity_When_pass_valid_parameters_Then_returns_valid_result()
        {
            //Arange
            const string cityName = "Lviv";

            //Act
            var res = await _service.GetInfoByCity(cityName, 1);

            //Assert
            Assert.IsTrue(res.CityName == cityName);
        }*/
    }
}
