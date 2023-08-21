using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PFC.WebAPI.Core.SessionAggregate;

namespace PFC.WebAPI.Infrastructure.Data.Config;
public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
  public void Configure(EntityTypeBuilder<Session> builder)
  {
    builder
            .HasIndex(b => b.AccountOid)
                .IsUnique();

    builder
        .HasIndex(b => b.SessionOid)
            .IsUnique();
  }
}
