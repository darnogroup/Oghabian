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
    public class SliderConfiguration:IEntityTypeConfiguration<SliderEntity>
    {
        public void Configure(EntityTypeBuilder<SliderEntity> builder)
        {
            builder.HasKey(k => k.SliderId);
            builder.Property(p => p.SliderImagePath).IsRequired();
        }
    }
}
