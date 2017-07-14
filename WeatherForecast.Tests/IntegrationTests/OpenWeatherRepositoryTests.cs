using Effort;
using NUnit.Framework;
using System.Linq;
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
        public void GetAllCities_Returns_empty_cities_collection_When_not_add_cities_before()
        {
            // Arrange
            // Empty

            //Act
            var citiesCount = _repository.GetAllCities().Count();

            // Assert
            Assert.AreEqual(0, citiesCount);
        }

        [Test]
        public void GetAllCities_Returns_exactly_one_city_instance_When_Call_AddCity_funtion_once()
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
    }
}
