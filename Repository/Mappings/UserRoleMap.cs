using System;
using Microsoft.EntityFrameworkCore;
using Domain;
using static Repository.Utils.Constants;

namespace Repository.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserRole> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("UserRole");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(20);
            builder.Property(p => p.IsAdmin).HasColumnName("IsAdmin").IsRequired().HasColumnType(SqlServerDbTypes.BIT);
        }
    }
}