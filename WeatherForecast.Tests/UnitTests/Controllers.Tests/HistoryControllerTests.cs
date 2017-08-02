using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WeatherForecast.Controllers;
using WeatherForecast.Models.Entities;
using WeatherForecast.Models.Interfaces;
using WeatherForecast.Models.OpenWeatherMapModels;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Tests.UnitTests.Controllers.Tests
{
    [TestFixture]
    class HistoryControllerTests
    {
        private readonly Mock<IUnitOfWorkService> _unitOfWorkMock;
        private readonly HistoryController _controller;

        public HistoryControllerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWorkService>();
            _controller = new HistoryController(_unitOfWorkMock.Object);
        }

        [SetUp]
        public void TestSetup()
        {
            _unitOfWorkMock.Setup(x => (x.GetAllCities()))
                .ReturnsAsync(new List<City>
                {
                    new City{Name = "Lviv"}
                });

            _unitOfWorkMock.Setup(x => x.GetHistory())
                .ReturnsAsync(new List<RequestHistoryEntity>());
        }

        [TearDown]
        public void TestTearDown()
        {
            _unitOfWorkMock.Reset();
        }

        [Test]
        public async Task Index_View_Contains_ICollectionOfRequestHistoryEntity_Model()
        {
            //Act
            var result = ((ViewResult) await _controller.Index()).Model;

            //Assert
            Assert.IsInstanceOf<ICollection<RequestHistoryEntity>>(result);
        }
    }
}
