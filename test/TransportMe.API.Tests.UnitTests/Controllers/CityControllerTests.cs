using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMe.API.Controllers;
using TransportMe.API.Models;
using TransportMe.API.Services;
using TransportMe.Entities;
using Xunit;

// Referenes: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-2.1
namespace TransportMe.API.Tests.UnitTests.Controllers
{
    public class CityControllerTests : IClassFixture<CityControllerFixture>
    {
        [Fact]
        public async Task GetCities_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var mockCityDataRepo = new Mock<ICityDataRepository>();
            var fakeCities = Enumerable.Range(0, 1).Select(i => new City() { Id = i });
            mockCityDataRepo.Setup(repo => repo.GetCitiesAsync())
                            .Returns(Task.FromResult<IEnumerable<City>>(fakeCities));
            var controller = new CityController(mockCityDataRepo.Object);

            // Act
            var response = await controller.GetCitiesAsync();

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

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

        [Fact]
        public async Task AddCity_ReturnsNewCityInfo_WhenSuccessful()
        {
            // Arrange
            var fakeCity = new City() { Id = 1, Name = "Liverpool", Country = "England" };
            var mockCityDataRepo = new Mock<ICityDataRepository>();
            mockCityDataRepo.Setup(repo => repo.AddCityAsync(fakeCity))
                            .Returns(Task.CompletedTask)
                            .Verifiable();
            mockCityDataRepo.Setup(repo => repo.SaveAsync())
                            .Returns(Task.FromResult(true));
            var controller = new CityController(mockCityDataRepo.Object);

            // Act
            var response = await controller.AddCityAsync(AutoMapper.Mapper.Map<CityDto>(fakeCity));

            // Assert
            Assert.IsType<CreatedAtRouteResult>(response);
        }
    }
}
