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
        }

        [TearDown]
        public void TestTearDown()
        {
            //Clean up data in fake dependencies
            _repoMock.Reset();
            _infoMock.Reset();
            _serviceMock.Reset();
        }

        /*[Test]
        public void Index_When_pass_one_city_Then_history_has_one_city_entity()
        {
            //Arrange
            WeatherInfoController controller = new WeatherInfoController(_serviceMock.Object, _infoMock.Object, _repoMock.Object);

            //Act
            var actionRes = controller.Index("Lviv");

            //Assert
            Assert.That(_repoMock.Object.GetAllCities().Count(), Is.EqualTo(1));
        }*/
    }
}
