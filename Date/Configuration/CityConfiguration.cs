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
    public class CityConfiguration:IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.HasKey(k => k.CityId);
            builder.Property(p => p.CityName).IsRequired();
            builder.HasMany(m => m.Address)
                .WithOne(o => o.City)
                .HasForeignKey(f => f.CityId);
        }
    }
}
