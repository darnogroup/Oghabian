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
    public class SicknessConfiguration:IEntityTypeConfiguration<SicknessEntity>
    {
        public void Configure(EntityTypeBuilder<SicknessEntity> builder)
        {
            builder.HasKey(k => k.SicknessId);
            builder.Property(p => p.SicknessImagePath).IsRequired();
            builder.Property(p => p.SicknessTitle).IsRequired();
            builder.HasMany(m => m.Food)
                .WithOne(o => o.Sickness)
                .HasForeignKey(f => f.SicknessId);
           builder.HasMany(m=>m.MedicalInformation)
               .WithOne(o=>o.Sickness)
               .HasForeignKey(f=>f.SicknessId);

        }
    }
}
