using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PFC.WebAPI.Infrastructure.Data.Config;
public class DataSetConfiguration : IEntityTypeConfiguration<Core.DataSetAggregate.DataSet>
{
  public void Configure(EntityTypeBuilder<Core.DataSetAggregate.DataSet> builder)
  {
    builder
        .HasIndex(b => b.AccountOid)
            .IsUnique();

    builder
    .HasIndex(b => b.Oid)
        .IsUnique();
  }
}
