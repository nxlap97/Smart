using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart.Core.Domain;
using Smart.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Data.Configurations
{
    public class ProductConfiguration : DbEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(128)
                .IsUnicode(false).HasMaxLength(128).IsRequired();
        }
    }
}
