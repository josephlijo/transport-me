using System.Collections.Generic;
using System.Threading.Tasks;
using TransportMe.Entities;

namespace TransportMe.API.Services
{
    public interface ICityDataRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        Task<City> GetCityAsync(int cityId);

        void AddCityAsync(City city);

        Task<bool> SaveAsync();
    }
}
