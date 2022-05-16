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
    public class CommentFoodConfiguration:IEntityTypeConfiguration<CommentFoodEntity>
    {
        public void Configure(EntityTypeBuilder<CommentFoodEntity> builder)
        {
            builder.HasKey(k => k.CommentId);
          
            builder.Property(p => p.CommentText).IsRequired();
        }
    }
}
