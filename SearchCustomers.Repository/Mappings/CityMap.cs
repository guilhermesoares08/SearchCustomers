using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchCustomers.Domain;
using static SearchCustomers.Repository.Utils.Constants;

namespace SearchCustomers.Repository.Mappings
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
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR);
            builder.Property(t => t.RegionId).HasColumnName("RegionId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.HasOne(p => p.Region).WithOne().HasForeignKey<City>(p => p.RegionId);
        }
    }
}