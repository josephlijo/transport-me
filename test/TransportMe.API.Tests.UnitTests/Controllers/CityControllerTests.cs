using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using TransportMe.API.Controllers;
using TransportMe.API.Services;
using TransportMe.Entities;
using Xunit;

namespace TransportMe.API.Tests.UnitTests.Controllers
{
    public class CityControllerTests : IClassFixture<CityControllerFixture>
    {
        [Fact]
        public async Task GetCity_ReturnsOk_WhenCityIsFound()
        {
            // Arrange
            int testCityId = 20;
            var fakeCity = new City() { Id = testCityId };
            var mockCityDataRepo = new Mock<ICityDataRepository>();
            mockCityDataRepo.Setup(repo => repo.GetCityAsync(testCityId))
                            .Returns(Task.FromResult<City>(fakeCity));
            var controller = new CityController(mockCityDataRepo.Object);

            // Act
            var response = await controller.GetCityAsync(testCityId);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetCity_ReturnsNotFound_WhenCityNotFound()
        {
            // Arrange
            int testCityId = 20;
            var mockCityDataRepo = new Mock<ICityDataRepository>();
            mockCityDataRepo.Setup(repo => repo.GetCityAsync(testCityId))
                            .Returns(Task.FromResult((City)null));
            var controller = new CityController(mockCityDataRepo.Object);

            // Act
            var response = await controller.GetCityAsync(testCityId);

            // Assert
            Assert.IsType<NotFoundResult>(response);
        }
    }
}
