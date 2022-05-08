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
    public class CategoryConfiguration:IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(k => k.CategoryId);
            builder.Property(p => p.CategoryTitle);
            builder.HasMany(m => m.Articles)
                .WithOne(o => o.Category)
                .HasForeignKey(f => f.CategoryId);
        }
    }
}
