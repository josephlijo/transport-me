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

            // Seed data
            var londonCity = new City() { Id = 1, Name = "London", Country = "England" };
            modelBuilder.Entity<City>().SeedData(
                londonCity,
                new City() { Id = 2, Name = "Tokyo", Country = "Japan" }
                );
            var tubeTransport = new TransportMode { Id = 10, Name = "Tube" };
            modelBuilder.Entity<TransportMode>().SeedData(
                new TransportMode { Id = 1, Name = "Bus" },
                new TransportMode { Id = 2, Name = "Cable Car" },
                new TransportMode { Id = 3, Name = "Cycle Hire" },
                new TransportMode { Id = 4, Name = "Dlr" },
                new TransportMode { Id = 5, Name = "National Rail" },
                new TransportMode { Id = 6, Name = "Overground" },
                new TransportMode { Id = 7, Name = "River Bus" },
                new TransportMode { Id = 8, Name = "TFL Rail" },
                new TransportMode { Id = 9, Name = "Tram" },
                tubeTransport
                );
            modelBuilder.Entity<TransportService>().SeedData(
                new TransportService { Id = 1, Name = "Bakerloo", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 2, Name = "Central", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 3, Name = "Circle", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 4, Name = "District", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 5, Name = "Hammersmith & City", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 6, Name = "Jubilee", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 7, Name = "Metropolitan", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 8, Name = "Northern", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 9, Name = "Piccadilly", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 10, Name = "Victoria", CityId = 1, TransportModeId = 10 },
                new TransportService { Id = 11, Name = "Waterloo & City", CityId = 1, TransportModeId = 10 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
