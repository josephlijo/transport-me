using System.Collections.Generic;
using TransportMe.Entities;

namespace TransportMe.API.Services
{
    public interface ICityDataRepository
    {
        IEnumerable<City> GetCities();

        City GetCity(int cityId);

        void AddCity(City city);

        bool Save();
    }
}
