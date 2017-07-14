using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WeatherForecast.Controllers;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;

namespace WeatherForecast.Tests.UnitTests.Controllers.Tests
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
                    new City{Name = "Lviv"}
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
        public void EditPost_Returns_ViewResult_When_ModelState_Is_Invalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("CityName", "Required");

            //Act
            var actual = _controller.Edit(city:new City());

            //Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }

        [Test]
        public void EditPost_Returns_RedirectToAction_Index_WhenModelState_Is_Valid()
        {
            //Act
            var actual = _controller.Edit(city: new City());

            //Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(actual);
        }

        [Test]
        public void Delete_Returns_HttpStatusCodeResult_When_cityName_Is_Null()
        {
            //Act
            var actual = _controller.Delete(null);

            //Assert
            Assert.IsInstanceOf<HttpStatusCodeResult>(actual);
        }
    }
}
