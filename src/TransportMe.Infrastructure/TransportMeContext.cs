using Microsoft.EntityFrameworkCore;
using TransportMe.Infrastructure.Entities;

namespace TransportMe.Infrastructure
{
    public class TransportMeContext : DbContext
    {
        public TransportMeContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        public DbSet<City> City { get; set; }

        public DbSet<TransportMode> TransportMode { get; set; }

        public DbSet<TransportService> TransportService { get; set; }
    }
}
