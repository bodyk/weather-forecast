using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WeatherForecast.Controllers;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Services;

namespace WeatherForecast.Tests.Controllers.Tests
{
    [TestFixture]
    public class WeatherInfoControllerTests
    {
        private readonly Mock<IWeatherService> _serviceMock;
        private readonly Mock<IDetailedWeatherInfo> _infoMock;
        private readonly Mock<IWeatherRepository> _repoMock;

        public WeatherInfoControllerTests()
        {
            _serviceMock = new Mock<IWeatherService>();
            _infoMock = new Mock<IDetailedWeatherInfo>();
            _repoMock = new Mock<IWeatherRepository>();
        }

        [SetUp]
        public void TestSetup()
        {
            //Prepare fake dependencies
            var dayInfo1 = new SingleDayInfoEntity
            {
                Id = 1,
                Clouds = "5",
                Temperature = "25",
                Pressure = "989",
                Humidity = "97",
                WindSpeed = "8",
                Date = "07/13/2017 13:00:00"
            };

            var dayInfo2 = new SingleDayInfoEntity
            {
                Id = 2,
                Clouds = "10",
                Temperature = "50",
                Pressure = "1000",
                Humidity = "90",
                WindSpeed = "12",
                Date = "07/14/2017 13:00:00"
            };

            var dayInfo3 = new SingleDayInfoEntity
            {
                Id = 3,
                Clouds = "15",
                Temperature = "75",
                Pressure = "500",
                Humidity = "50",
                WindSpeed = "20",
                Date = "07/15/2017 13:00:00"
            };

            var cityName = "Lviv";

            var weatherInfo = new WeatherEntity
            {
                Id = 1,
                CityName = cityName,
                CountryCode = "UA",
                DayInfoEntities = new List<SingleDayInfoEntity>
                {
                    dayInfo1, dayInfo2, dayInfo3
                },
                CountForecastDays = 3
            };

            var requestHistoryEntity = new RequestHistoryEntity
            {
                Id = 1,
                WeatherEntity = weatherInfo,
                RequestTime = new DateTime(2017, 07, 13)
            };

            _repoMock.Object.AddHistoryItem(requestHistoryEntity);
            _infoMock.Setup(x => x.GetWeatherParams()).Returns(new List<SingleDayInfoEntity>
            {
                dayInfo1
            });
            _infoMock.Setup(x => x.GetEntity()).Returns(weatherInfo);
            _serviceMock.Setup(x => x.GetInfoByCity(cityName, 1)).Returns(Task.FromResult(_infoMock.Object));
        }

        [TearDown]
        public void TestTearDown()
        {
            //Clean up data in fake dependencies
            _repoMock.Reset();
            _infoMock.Reset();
            _serviceMock.Reset();
        }

        [Test]
        public void Index_When_pass_one_city_Then_history_has_one_city_entity()
        {
            //Arrange
            WeatherInfoController controller = new WeatherInfoController(_serviceMock.Object, _infoMock.Object, _repoMock.Object);

            //Act
            var actionRes = controller.Index("Lviv");

            //Assert
            Assert.That(_repoMock.Object.GetAllCities().Count(), Is.EqualTo(1));
        }
    }
}
