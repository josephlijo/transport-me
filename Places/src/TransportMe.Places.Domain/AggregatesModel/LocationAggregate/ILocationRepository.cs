using System.Threading.Tasks;
using TransportMe.Places.Domain.SeedWork;

namespace TransportMe.Places.Domain.AggregatesModel.LocationAggregate
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location Add(Location location);

        Location Update(Location location);

        Task<Location> FindAsync(string locationIdentityGuid);
    }
}
