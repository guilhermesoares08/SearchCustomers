using System;
using Microsoft.EntityFrameworkCore;
using Domain;
using static Repository.Utils.Constants;

namespace Repository.Mappings
{
    public sealed class ClassificationMap : IEntityTypeConfiguration<Classification>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Classification> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Classification");
            builder.Property(p => p.Id).UseIdentityColumn().HasColumnName("Id").HasColumnType(SqlServerDbTypes.INT).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasColumnType(SqlServerDbTypes.VARCHAR).HasMaxLength(20);
        }
    }
}