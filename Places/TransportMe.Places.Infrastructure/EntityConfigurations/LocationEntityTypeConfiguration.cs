using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportMe.Places.Domain.AggregatesModel.LocationAggregate;

namespace TransportMe.Places.Infrastructure.EntityConfigurations
{
    internal class LocationEntityTypeConfiguration
        : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location", PlacesContext.DEFAULT_SCHEMA);

            builder.HasKey(location => location.Id);

            builder.Ignore(location => location.DomainEvents);

            builder.Property(location => location.Id)
                   .ForSqlServerUseSequenceHiLo("LocationSequence", PlacesContext.DEFAULT_SCHEMA);

            builder.Property(location => location.IdentityGuid)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.HasIndex("IdentityGuid")
                   .IsUnique();

            builder.Property(location => location.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(location => location.Description)
                   .IsRequired(false) // This is not required as string can be null and EF by convention make it nullable
                   .HasMaxLength(500);

            // Owned Entity Types
            // Address value object persisted as owned entity type supported since EF Core 2.0
            // Table splitting - address entity details goes to same table as Location
            // https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities
            builder.OwnsOne(location => location.Address);
        }
    }
}
