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
    public class OrderDetailConfiguration:IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.HasKey(k => k.OrderDetailId);
            builder.Property(p => p.Count).IsRequired();
            builder.Property(p => p.Price).IsRequired();
        }
    }
}
