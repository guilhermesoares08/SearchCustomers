using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchCustomers.Domain;
using static SearchCustomers.Repository.Utils.Constants;

namespace SearchCustomers.Repository.Mappings
{
    public sealed class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Customer");
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnName("Id").IsRequired().HasColumnType(SqlServerDbTypes.INT).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(50);
            builder.Property(t => t.Phone).HasColumnName("Phone").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(50);
            builder.Property(t => t.GenderId).HasColumnName("GenderId").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(t => t.CityId).HasColumnName("CityId").IsRequired(false).HasColumnType(SqlServerDbTypes.INT);
            builder.Property(t => t.RegionId).HasColumnName("RegionId").IsRequired(false).HasColumnType(SqlServerDbTypes.INT);
            builder.Property(t => t.LastPurchase).HasColumnName("LastPurchase").IsRequired(false).HasColumnType(SqlServerDbTypes.DATE);
            builder.Property(t => t.ClassificationId).HasColumnName("ClassificationId").IsRequired(false).HasColumnType(SqlServerDbTypes.INT);
            builder.Property(t => t.UserId).HasColumnName("UserId").IsRequired(false).HasColumnType(SqlServerDbTypes.INT);

            builder.HasOne(t => t.Gender).WithOne(p => p.Customer).HasForeignKey<Gender>(q => q.CustomerId);
            builder.HasOne(t => t.City).WithMany(p => p.Customers).HasForeignKey(q => q.CityId);
            builder.HasOne(t => t.Classification).WithOne(p => p.Customer).HasForeignKey<Classification>(q => q.CustomerId);
            builder.HasOne(t => t.Region).WithOne(p => p.Customer).HasForeignKey<Region>(q => q.CustomerId);
            builder.HasOne(t => t.User).WithMany(p => p.Customers).HasForeignKey(p => p.UserId);
        }
    }
}