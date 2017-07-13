using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WeatherForecast.Controllers;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Tests.Controllers.Tests
{
    [TestFixture]
    class CitiesControllerTests
    {
        private readonly Mock<IWeatherRepository> _repoMock;
        private readonly CitiesController _controller;

        public CitiesControllerTests()
        {
            _repoMock = new Mock<IWeatherRepository>();
            _controller = new CitiesController(_repoMock.Object);
        }

        [SetUp]
        public void TestSetup()
        {
            _repoMock.Setup(x => x.GetAllCities())
                .Returns(new List<City>
                {
                    new City{}
                });
        }

        [TearDown]
        public void TestTearDown()
        {
            _repoMock.Reset();
        }

        [Test]
        public void Index_Returns_ActionResult()
        {
            //Act
            var actual = _controller.Index();

            //Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [Test]
        public void Index_Always_returns_cities_to_view()
        {
            //Act
            var actual = ((ViewResult)_controller.Index()).Model;

            //Assert
            Assert.IsInstanceOf<List<City>>(actual);
        }
    }
}
