using System;

namespace TransportMe.API.Tests.UnitTests.Controllers
{
    public class CityControllerFixture : IDisposable
    {
        public CityControllerFixture()
        {
            // Automapper configuration
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Entities.City, Models.CityDto>();
                config.CreateMap<Models.CityDto, Entities.City>();
            });
        }

        public void Dispose()
        {
        }
    }
}
