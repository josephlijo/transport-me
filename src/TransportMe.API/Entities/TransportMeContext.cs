using Microsoft.EntityFrameworkCore;

namespace TransportMe.Entities
{
    public class TransportMeContext : DbContext
    {
        public TransportMeContext(DbContextOptions<TransportMeContext> options) 
            : base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<TransportMode> TransportModes { get; set; }

        public DbSet<TransportService> TransportServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<TransportMode>().ToTable("TransportMode");
            modelBuilder.Entity<TransportService>().ToTable("TransportService");

            base.OnModelCreating(modelBuilder);
        }
    }
}
