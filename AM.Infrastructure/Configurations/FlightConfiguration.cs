using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasMany(f => f.Passengers)
            .WithMany(p => p.Flights);

        builder.HasOne(f => f.Plane)
            .WithMany(p => p.Flights);
    }
}
