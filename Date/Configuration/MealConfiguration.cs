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
    public class MealConfiguration:IEntityTypeConfiguration<MealEntity>
    {
        public void Configure(EntityTypeBuilder<MealEntity> builder)
        {
            builder.HasKey(k => k.MealId);
            builder.Property(p => p.MealTitle).IsRequired();
            builder.HasMany(m => m.Food)
                .WithOne(o => o.Meal)
                .HasForeignKey(f => f.MealId);

        }
    }
}
