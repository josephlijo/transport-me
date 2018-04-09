using System.Collections.Generic;
using TransportMe.API.Models;

namespace TransportMe.API.Data
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; private set; } = new CityDataStore();

        public IList<CityDto> Cities { get; private set; }

        public CityDataStore()
        {
            this.Cities = new List<CityDto>
            {
                new CityDto() { Id = 1, Name = "London", Country = "England" },
                new CityDto() { Id = 2, Name = "Tokyo", Country = "Japan" }
            };
        }
    }
}
