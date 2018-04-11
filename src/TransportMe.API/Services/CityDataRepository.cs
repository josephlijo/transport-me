using System.Collections.Generic;
using System.Linq;
using TransportMe.Entities;

namespace TransportMe.API.Services
{
    public class CityDataRepository : ICityDataRepository
    {
        private readonly TransportMeContext context;

        public CityDataRepository(TransportMeContext context)
        {
            this.context = context;
        }

        public void AddCity(City city)
        {
            this.context.Cities.Add(city);
        }

        public IEnumerable<City> GetCities()
        {
            return this.context.Cities.ToList<City>();
        }

        public City GetCity(int cityId)
        {
            return this.context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public bool Save()
        {
            return this.context.SaveChanges() > 0;
        }
    }
}
