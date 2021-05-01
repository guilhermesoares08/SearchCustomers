using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchCustomers.Domain;
using System.Linq;
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

            builder.HasOne(t => t.Gender).WithOne().HasForeignKey<Customer>(q => q.GenderId);
            builder.HasOne(t => t.City).WithMany().HasForeignKey(q => q.CityId);
            builder.HasOne(t => t.Classification).WithOne().HasForeignKey<Customer>(q => q.ClassificationId);
            
            builder.HasOne(t => t.Region).WithOne().HasForeignKey<Customer>(q => q.RegionId);
            builder.HasOne(t => t.User).WithMany().HasForeignKey(p => p.UserId);
        }
    }
}