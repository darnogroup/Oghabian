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
    public class OrderConfiguration:IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(k => k.OrderId);
            builder.Property(p => p.Code).IsRequired();
            builder.HasMany(m => m.Detail)
                .WithOne(o => o.Order)
                .HasForeignKey(f => f.OrderId);
        }
    }
}
