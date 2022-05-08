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
    public class ArticleConfiguration:IEntityTypeConfiguration<ArticleEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleEntity> builder)
        {
            builder.HasIndex(i => i.ArticleTitle);
            builder.HasKey(k => k.ArticleId);
            builder.Property(p => p.ArticleBody).IsRequired();
            builder.Property(p => p.ArticleTitle).IsRequired();
            builder.Property(p => p.CreatedTime).IsRequired();
            builder.Property(p => p.TimeStudy).IsRequired();
            builder.Property(p => p.ArticleImage).IsRequired();
            builder.HasMany(m => m.Comments)
                .WithOne(o => o.Article)
                .HasForeignKey(f => f.ArticleId);
        }
    }
}
