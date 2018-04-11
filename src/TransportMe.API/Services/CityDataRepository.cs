using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async void AddCityAsync(City city)
        {
            await this.context.Cities.AddAsync(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await this.context.Cities.ToListAsync<City>();
        }

        public async Task<City> GetCityAsync(int cityId)
        {
            return await this.context.Cities.Where(c => c.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
