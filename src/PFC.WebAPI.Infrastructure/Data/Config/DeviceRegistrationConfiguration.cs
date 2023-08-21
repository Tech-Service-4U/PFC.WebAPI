using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFC.WebAPI.Core.DeviceRegistrationAggregate;

namespace PFC.WebAPI.Infrastructure.Data.Config;
public class DeviceRegistrationConfiguration : IEntityTypeConfiguration<DeviceRegistration>
{
  public void Configure(EntityTypeBuilder<DeviceRegistration> builder)
  {
    builder
            .Property(b => b.VenderDeviceId)
                .HasMaxLength(32);

    builder
        .Property(b => b.DeviceType)
            .HasMaxLength(32);

    builder
        .Property(b => b.PlatformId)
            .HasMaxLength(32);

    builder
        .Property(b => b.Idiom)
            .HasMaxLength(32);

    builder
        .Property(b => b.Manufacturer)
            .HasMaxLength(32);

    builder
        .Property(b => b.Model)
            .HasMaxLength(32);

    builder
        .Property(b => b.OperatingSystemVersion)
            .HasMaxLength(32);

    builder
        .Property(b => b.FirebaseToken)
            .HasMaxLength(256);
  }
}
