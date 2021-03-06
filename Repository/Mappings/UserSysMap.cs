using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;
using static Repository.Utils.Constants;

namespace Repository.Mappings
{
    public class UserSysMap : IEntityTypeConfiguration<UserSys>
    {
        public void Configure(EntityTypeBuilder<UserSys> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("UserSys");
            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn().ValueGeneratedOnAdd().IsRequired().HasColumnType(SqlServerDbTypes.INT);
            builder.Property(p => p.Login).HasColumnName("Login").HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Email).HasColumnName("Email").HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Password).HasColumnName("Password").HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(40).IsRequired();
            builder.Property(p => p.UserRoleId).HasColumnName("UserRoleId").HasColumnType(SqlServerDbTypes.INT).IsRequired();

            builder.HasOne(p => p.UserRole).WithOne().HasForeignKey<UserSys>(p => p.UserRoleId);
        }
    }
}