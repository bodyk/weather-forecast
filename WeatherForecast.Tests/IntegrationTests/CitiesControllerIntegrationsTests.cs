using System;
using System.Collections.Generic;
using Effort;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Controllers;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Implementations;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Tests.IntegrationTests
{
    class CitiesControllerIntegrationsTests
    {
        private WeatherContext _context;
        private IUnitOfWorkService _service;
        private CitiesController _citiesController;


        [SetUp]
        public void TestSetup()
        {
            var connection = DbConnectionFactory.CreateTransient();
            _context = new WeatherContext(connection);
            _service = new UnitOfWorkService(new UnitOfWork(_context));
            _citiesController = new CitiesController(_service);
        }

        [Test]
        public async Task Create_When_call_funtion_with_null_Then_database_still_empty()
        {
            // Arrange
            City city = new City { Name = "Lviv" };

            //Act
            try
            {
                _citiesController.Create(null);
            }
            catch (Exception e)
            {
                // Expected exception
            }
            var cities = await _service.GetAllCities();

            // Assert
            Assert.AreEqual(0, cities.Count());
        }

        [Test]
        public async Task Create_When_call_funtion_once_Then_database_will_have_exactly_one_city_instance()
        {
            // Arrange
            City city = new City { Name = "Lviv" };

            //Act
            _citiesController.Create(city);
            var cities = await _service.GetAllCities();

            // Assert
            Assert.AreEqual(1, cities.Count());
        }

        [Test]
        public async Task DeleteConfirmed_When_remove_valid_city_Then_cities_amount_correctly_updated()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName };
            _citiesController.Create(city);

            //Act
            await _citiesController.DeleteConfirmed(cityName);
            var cities = await _service.GetAllCities();

            // Assert
            Assert.AreEqual(0, cities.Count());
        }

        [Test]
        public async Task Edit_When_edit_city_Then_cities_info_correctly_updated()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName, country = "UA" };
            _citiesController.Create(city);
            var newCountryCode = "EU";
            city.country = newCountryCode;

            //Act
            await _citiesController.Edit(city);
            var cities = await _service.GetAllCities();

            // Assert
            Assert.AreNotEqual(null, cities.FirstOrDefault(c => c.country == newCountryCode));
        }

        [Test]
        public async Task DeleteConfirmed_When_call_funtion_with_null_Then_database_still_have_one_city()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName };
            _citiesController.Create(city);

            //Act
            await _citiesController.DeleteConfirmed(null);
            var cities = await _service.GetAllCities();

            // Assert
            Assert.AreEqual(1, cities.Count());
        }
    }
}
