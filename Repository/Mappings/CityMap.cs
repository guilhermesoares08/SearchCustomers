using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;
using static Repository.Utils.Constants;

namespace Repository.Mappings
{
    public sealed class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("City");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(20);
            builder.Property(t => t.RegionId).HasColumnName("RegionId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.HasOne(p => p.Region).WithOne().HasForeignKey<City>(p => p.RegionId);
        }
    }
}