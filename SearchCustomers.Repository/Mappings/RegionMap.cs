using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchCustomers.Domain;
using static SearchCustomers.Repository.Utils.Constants;

namespace SearchCustomers.Repository.Mappings
{
    public sealed class RegionMap : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Region");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(20);
        }
    }
}
