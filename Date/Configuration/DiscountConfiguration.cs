using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Date.Configuration
{
    public class DiscountConfiguration:IEntityTypeConfiguration<DiscountEntity>
    {
        public void Configure(EntityTypeBuilder<DiscountEntity> builder)
        {
            builder.HasKey(k => k.DiscountId);
            builder.Property(p => p.DiscountCode).IsRequired();
            builder.Property(p => p.DiscountPrice).IsRequired();
            builder.Property(p => p.DiscountTitle).IsRequired();
            builder.Property(p => p.StartTime).IsRequired();
            builder.Property(p => p.EndTime).IsRequired();
        }
    }
}
