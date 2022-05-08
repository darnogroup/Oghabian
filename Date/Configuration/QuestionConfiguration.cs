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
    public class QuestionConfiguration:IEntityTypeConfiguration<QuestionEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionEntity> builder)
        {
            builder.HasKey(k => k.QuestionId);
            builder.Property(p => p.QuestionAnswer).IsRequired();
            builder.Property(p => p.QuestionTitle).IsRequired();
        }
    }
}
