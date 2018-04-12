using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

// References: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-2.1
// http://www.dotnetcurry.com/aspnet-core/1420/integration-testing-aspnet-core
namespace TransportMe.API.Tests.IntegrationTests.Controllers
{
    public class CityControllerTests : IClassFixture<TransportMeTestFixture<TransportMe.API.Startup>>
    {
        private readonly HttpClient _client;

        public CityControllerTests(TransportMeTestFixture<TransportMe.API.Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task GetCityNames_ReturnsOk_WhenSuccessful()
        {
            var response = await _client.GetAsync("/api/v1/city/names");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
