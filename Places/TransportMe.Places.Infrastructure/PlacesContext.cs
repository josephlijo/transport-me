using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TransportMe.Places.Domain.AggregatesModel.LocationAggregate;
using TransportMe.Places.Domain.SeedWork;
using TransportMe.Places.Infrastructure.EntityConfigurations;

namespace TransportMe.Places.Infrastructure
{
    public class PlacesContext
        : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "places";

        public DbSet<Location> Locations { get; set; }

        private readonly IMediator _mediator;

        // TODO:// Make this private after solving DI for IMediator
        public PlacesContext(DbContextOptions<PlacesContext> options)
            : base(options)
        {
        }

        public PlacesContext(DbContextOptions<PlacesContext> options, IMediator mediator)
            : this(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // Using Configurations
        // https://docs.microsoft.com/en-us/ef/core/modeling/#methods-of-configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 

            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
