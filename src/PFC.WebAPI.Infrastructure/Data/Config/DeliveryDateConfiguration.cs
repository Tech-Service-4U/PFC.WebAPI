using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFC.WebAPI.Core.DeliveryDateAggregate;

namespace PFC.WebAPI.Infrastructure.Data.Config;
public class DeliveryDateConfiguration : IEntityTypeConfiguration<DeliveryDate>
{
  public void Configure(EntityTypeBuilder<DeliveryDate> builder)
  {
    builder
      .Property(p => p.DeliveryDates)
      .HasColumnType("date");
  }
}
