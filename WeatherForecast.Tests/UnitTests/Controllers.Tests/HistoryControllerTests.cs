using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WeatherForecast.Controllers;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Tests.UnitTests.Controllers.Tests
{
    [TestFixture]
    class HistoryControllerTests
    {
        private readonly Mock<IWeatherRepository> _repoMock;
        private readonly HistoryController _controller;

        public HistoryControllerTests()
        {
            _repoMock = new Mock<IWeatherRepository>();
            _controller = new HistoryController(_repoMock.Object);
        }

        [SetUp]
        public void TestSetup()
        {
            _repoMock.Setup(x => x.GetAllCities())
                .Returns(new List<City>
                {
                    new City{Name = "Lviv"}
                });

            _repoMock.Setup(x => x.GetHistory())
                .Returns(new List<RequestHistoryEntity>());
        }

        [TearDown]
        public void TestTearDown()
        {
            _repoMock.Reset();
        }

        [Test]
        public void Index_View_Contains_ICollectionOfRequestHistoryEntity_Model()
        {
            //Act
            var result = ((ViewResult)_controller.Index()).Model;

            //Assert
            Assert.IsInstanceOf<ICollection<RequestHistoryEntity>>(result);
        }
    }
}
