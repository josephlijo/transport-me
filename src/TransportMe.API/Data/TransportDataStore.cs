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
                new TransportModeDto { Name = "Bus" },
                new TransportModeDto { Name = "Cable Car" },
                new TransportModeDto { Name = "Cycle Hire" },
                new TransportModeDto { Name = "Dlr"  },
                new TransportModeDto { Name = "National Rail" },
                new TransportModeDto { Name = "Overground" },
                new TransportModeDto { Name = "River Bus" },
                new TransportModeDto { Name = "TFL Rail" },
                new TransportModeDto { Name = "Tram" },
                new TransportModeDto { Name = "Tube" }
            };

            this.TransportServices = new List<TransportServiceDto>
            {
                new TransportServiceDto() { Name="Bakerloo", Description = "" },
                new TransportServiceDto() { Name="Central", Description = "" },
                new TransportServiceDto() { Name="Circle", Description = "" },
                new TransportServiceDto() { Name="District", Description = "" },
                new TransportServiceDto() { Name="Hammersmith & City", Description = "" },
                new TransportServiceDto() { Name="Jubilee", Description = "" },
                new TransportServiceDto() { Name="Metropolitan", Description = "" },
                new TransportServiceDto() { Name="Northern", Description = "" },
                new TransportServiceDto() { Name="Piccadilly", Description = "" },
                new TransportServiceDto() { Name="Victoria", Description = "" },
                new TransportServiceDto() { Name="Waterloo & City", Description = "" }
            };
        }
    }
}
