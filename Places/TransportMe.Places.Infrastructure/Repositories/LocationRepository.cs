using System;
using System.Threading.Tasks;
using TransportMe.Places.Domain.AggregatesModel.LocationAggregate;
using TransportMe.Places.Domain.SeedWork;

namespace TransportMe.Places.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly PlacesContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public LocationRepository(PlacesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Location Add(Location location)
        {
            return _context.Locations.Add(location).Entity;
        }

        public Task<Location> GetAsync(string locationIdentityGuid)
        {
            return _context.Locations.FindAsync(locationIdentityGuid);
        }

        public Location Update(Location location)
        {
            return _context.Locations
                           .Update(location)
                           .Entity;
        }
    }
}
