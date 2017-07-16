﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using NUnit.Framework;
using WeatherForecast.Controllers;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Implementations;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Tests.UnitTests.Controllers.Tests
{
    class OpenWeatherRepositoryTests
    {
        private WeatherContext _context;
        private IUnitOfWorkService _service;


        [SetUp]
        public void TestSetup()
        {
            var connection = DbConnectionFactory.CreateTransient();
            _context = new WeatherContext(connection);
            _service = new UnitOfWorkService(new UnitOfWork(_context));
        }

        [Test]
        public void GetAllCities_When_not_add_cities_before_Then_Returns_empty_collection()
        {
            // Arrange
            // Empty

            //Act
            var citiesCount = _service.GetAllCities().Count();

            // Assert
            Assert.AreEqual(0, citiesCount);
        }

        [Test]
        public void GetAllCities_When_call_AddCity_funtion_once_Thenn_Returns_exactly_one_city_instance()
        {

            // Arrange
            City city = new City { Name = "Lviv" };

            //Act
            _service.AddCity(city);
            var cities = _service.GetAllCities();

            // Assert
            Assert.AreEqual(1, cities.Count());
        }

        [Test]
        public void RemoveCity_When_remove_valid_city_Then_cities_amount_correctly_updated()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName };
            _service.AddCity(city);

            //Act
            _service.RemoveCity(city);
            var cities = _service.GetAllCities();

            // Assert
            Assert.AreEqual(0, cities.Count());
        }

        [Test]
        public void UpdateCity_When_pass_updating_city_Then_cities_info_correctly_updated()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName, country = "UA" };
            _service.AddCity(city);
            var newCountryCode = "EU";
            city.country = newCountryCode;

            //Act
            _service.UpdateCity(city);
            var cities = _service.GetAllCities();

            // Assert
            Assert.AreNotEqual(null, cities.FirstOrDefault(c => c.country == newCountryCode));
        }

        [Test]
        public void FindCity_When_search_already_existing_city_Then_function_return_it()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName, country = "UA" };
            _service.AddCity(city);

            //Act
            var returnedCity = _service.FindCity(cityName);

            // Assert
            Assert.AreEqual(city, returnedCity);
        }

        [Test]
        public void GetHistory_When_not_add_history_before_Then_Returns_empty_collection()
        {
            // Arrange
            // Empty

            //Act
            var history = _service.GetHistory();

            // Assert
            Assert.AreEqual(0, history.Count());
        }
    }
}
