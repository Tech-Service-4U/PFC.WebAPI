using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFC.WebAPI.Core.EventAggregate;

namespace PFC.WebAPI.Infrastructure.Data.Config;
public class EventConfiguration : IEntityTypeConfiguration<Event>
{
  public void Configure(EntityTypeBuilder<Event> builder)
  {
    builder
        .HasOne(e => e.Location)
        .WithMany()
        .HasForeignKey(e => e.LocationOid)
        .OnDelete(DeleteBehavior.Restrict);
  }
}
