using System;
using System.Collections.Generic;
using Effort;
using NUnit.Framework;
using System.Linq;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Implementations;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Tests.IntegrationTests
{
    class OpenWeatherRepositoryTests
    {
        private WeatherContext _context;
        private IWeatherRepository _repository;

        [SetUp]
        public void TestSetup()
        {
            var connection = DbConnectionFactory.CreateTransient();
            _context = new WeatherContext(connection);
            _repository = new OpenWeatherRepository(_context);
        }

        [Test]
        public void GetAllCities_When_not_add_cities_before_Then_Returns_empty_collection()
        {
            // Arrange
            // Empty

            //Act
            var citiesCount = _repository.GetAllCities().Count();

            // Assert
            Assert.AreEqual(0, citiesCount);
        }

        [Test]
        public void GetAllCities_When_call_AddCity_funtion_once_Thenn_Returns_exactly_one_city_instance()
        {

            // Arrange
            City city = new City { Name = "Lviv" };

            //Act
            _repository.AddCity(city);
            var cities = _repository.GetAllCities();

            // Assert
            Assert.AreEqual(1, cities.Count());
        }

        [Test]
        public void RemoveCity_When_remove_valid_city_Then_cities_amount_correctly_updated()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName };
            _repository.AddCity(city);

            //Act
            _repository.RemoveCity(cityName);
            var cities = _repository.GetAllCities();

            // Assert
            Assert.AreEqual(0, cities.Count());
        }

        [Test]
        public void UpdateCity_When_pass_updating_city_Then_cities_info_correctly_updated()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName, country = "UA" };
            _repository.AddCity(city);
            var newCountryCode = "EU";
            city.country = newCountryCode;

            //Act
            _repository.UpdateCity(city);
            var cities = _repository.GetAllCities();

            // Assert
            Assert.AreNotEqual(null, cities.FirstOrDefault(c => c.country == newCountryCode));
        }

        [Test]
        public void FindCity_When_search_already_existing_city_Then_function_return_it()
        {
            // Arrange
            var cityName = "Lviv";
            City city = new City { Name = cityName, country = "UA" };
            _repository.AddCity(city);

            //Act
            var returnedCity = _repository.FindCity(cityName);

            // Assert
            Assert.AreEqual(city, returnedCity);
        }

        [Test]
        public void GetHistory_When_not_add_history_before_Then_Returns_empty_collection()
        {
            // Arrange
            // Empty

            //Act
            var history = _repository.GetHistory();

            // Assert
            Assert.AreEqual(0, history.Count);
        }

        [Test]
        public void GetHistory_When_Call_AddHistoryItem_funtion_once_Then_Returns_exactly_one_history_instance()
        {
            // Arrange
            _repository.AddWeatherEntity(new WeatherEntity()
            {
                DayInfoEntities_Id = 1,
                CityName = "Lviv",
                CountryCode = "UA",
                CountForecastDays = 1,
                DayInfoEntities = new List<SingleDayInfoEntity>()
            });

            _repository.AddHistoryItem(new RequestHistoryEntity()
            {
                WeatherEntity_Id = 1
            });

            //Act
            var history = _repository.GetHistory();

            // Assert
            Assert.AreEqual(1, history.Count);
        }

        [Test]
        public void ClearHistory_When_clear_not_empty_history_collection_Then_history_info_correctly_updated()
        {
            // Arrange
            _repository.AddWeatherEntity(new WeatherEntity()
            {
                DayInfoEntities_Id = 1, CityName = "Lviv", CountryCode = "UA",
                CountForecastDays = 1, DayInfoEntities = new List<SingleDayInfoEntity>()
            });
            _repository.AddHistoryItem(new RequestHistoryEntity(){WeatherEntity_Id = 1});

            //Act
            _repository.ClearHistory();

            // Assert
            Assert.AreEqual(0, _repository.GetHistory().Count);
        }
    }
}
