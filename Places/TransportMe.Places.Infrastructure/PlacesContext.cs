using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransportMe.Places.Domain.AggregatesModel.LocationAggregate;
using TransportMe.Places.Domain.SeedWork;

namespace TransportMe.Places.Infrastructure
{
    public class PlacesContext 
        : DbContext, IUnitOfWork
    {
        public DbSet<Location> Locations { get; set; }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
