using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore.ModelConfigurations
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
    where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<int>("CreatedBy")
                .IsRequired().HasDefaultValue(1);
            builder.Property<int?>("ModifiedBy");
                
            builder.Property<byte[]>("RowVersion")
            .IsRowVersion();
            builder.Property<DateTime>("CreateDate")
                .IsRequired().HasDefaultValueSql("SYSDATETIME()")
            .ValueGeneratedOnAdd();
            builder.Property<DateTime?>("UpdateDate");
        }
    }
}
