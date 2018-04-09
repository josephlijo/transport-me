using System.Collections.Generic;
using TransportMe.API.Models;

namespace TransportMe.API.Data
{
    public class TransportDataStore
    {
        public static TransportDataStore Current { get; } = new TransportDataStore();

        public IList<TransportModeDto> TransportModes { get; private set; }

        public IList<TransportServiceDto> TransportServices { get; private set; }

        public TransportDataStore()
        {
            this.TransportModes = new List<TransportModeDto>
            {
                new TransportModeDto { Id = 1, Name = "Bus" },
                new TransportModeDto { Id = 2, Name = "Cable Car" },
                new TransportModeDto { Id = 3, Name = "Cycle Hire" },
                new TransportModeDto { Id = 4, Name = "Dlr"  },
                new TransportModeDto { Id = 5, Name = "National Rail" },
                new TransportModeDto { Id = 6, Name = "Overground" },
                new TransportModeDto { Id = 7, Name = "River Bus" },
                new TransportModeDto { Id = 8, Name = "TFL Rail" },
                new TransportModeDto { Id = 9, Name = "Tram" },
                new TransportModeDto { Id = 10, Name = "Tube" }
            };

            this.TransportServices = new List<TransportServiceDto>
            {
                new TransportServiceDto() { Id = 1, Name="Bakerloo", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 2, Name="Central", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 3, Name="Circle", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 4, Name="District", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 5, Name="Hammersmith & City", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 6, Name="Jubilee", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 7, Name="Metropolitan", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 8, Name="Northern", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 9, Name="Piccadilly", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 10, Name="Victoria", Description = "", CityId = 1, TransportModeId = 10 },
                new TransportServiceDto() { Id = 11, Name="Waterloo & City", Description = "", CityId = 1, TransportModeId = 10 },
            };
        }
    }
}
