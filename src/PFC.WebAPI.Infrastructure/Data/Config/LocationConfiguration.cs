using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PFC.WebAPI.Infrastructure.Data.Config;
public class LocationConfiguration : IEntityTypeConfiguration<Core.LocationAggregate.Location>
{
  public void Configure(EntityTypeBuilder<Core.LocationAggregate.Location> builder)
  {
    builder
            .Property(b => b.Latitude)
                .HasColumnType("decimal(8,6)");

    builder
        .Property(b => b.Longitude)
            .HasColumnType("decimal(9,6)");

    builder
        .Property(b => b.Accuracy)
            .HasColumnType("decimal(5,2)");
  }
}
