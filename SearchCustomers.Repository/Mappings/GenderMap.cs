using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchCustomers.Domain;
using static SearchCustomers.Repository.Utils.Constants;

namespace SearchCustomers.Repository.Mappings
{
    public sealed class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Gender");
            builder.Property(p => p.Id).ValueGeneratedOnAdd().UseIdentityColumn().HasColumnName("Id").IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(20);
        }
    }
}