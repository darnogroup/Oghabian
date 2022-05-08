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
    public class FoodConfiguration:IEntityTypeConfiguration<FoodEntity>
    {
        public void Configure(EntityTypeBuilder<FoodEntity> builder)
        {
            builder.HasKey(k => k.FoodId);
            builder.Property(p => p.FoodCalories).IsRequired();
            builder.Property(p => p.FoodCarbohydrate).IsRequired();
            builder.Property(p => p.FoodCount).IsRequired();
            builder.Property(p => p.FoodDescription).IsRequired();
            builder.Property(p => p.FoodPrice).IsRequired();
            builder.Property(p => p.FoodFat).IsRequired();
            builder.Property(p => p.FoodImage).IsRequired();
            builder.Property(p => p.FoodLink).IsRequired();
            builder.Property(p => p.FoodProtein).IsRequired();
            builder.Property(p => p.FoodTags).IsRequired();
            builder.Property(p => p.FoodTitle).IsRequired();
            builder.Property(p => p.FoodSummary).IsRequired();
            builder.HasMany(m => m.Favorite)
                .WithOne(o => o.Food)
                .HasForeignKey(f => f.FoodId);
            builder.HasMany(m => m.Gallery)
                .WithOne(o => o.Food)
                .HasForeignKey(f => f.FoodId);
            builder.HasMany(m => m.Properties)
                .WithOne(o => o.Food)
                .HasForeignKey(f => f.FoodId);      
            builder.HasMany(m => m.Comment)
                .WithOne(o => o.Food)
                .HasForeignKey(f => f.FoodId);        
          
        }
    }
}
