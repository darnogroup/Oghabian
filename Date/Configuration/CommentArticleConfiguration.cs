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
    public class CommentArticleConfiguration:IEntityTypeConfiguration<CommentArticleEntity>
    {
        public void Configure(EntityTypeBuilder<CommentArticleEntity> builder)
        {
            builder.HasKey(k => k.CommentId);
            builder.Property(p => p.CommentBody).IsRequired();
        }
    }
}
