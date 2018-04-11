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
                new CityDto() { Name = "London", Country = "England" },
                new CityDto() { Name = "Tokyo", Country = "Japan" }
            };
        }
    }
}
