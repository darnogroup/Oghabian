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
    public class UserQuestionConfiguration:IEntityTypeConfiguration<UserQuestionEntity>
    {
        public void Configure(EntityTypeBuilder<UserQuestionEntity> builder)
        {
            builder.HasKey(k => k.UserQuestionId);
            builder.Property(p => p.UserQuestionTitle).IsRequired();
            builder.Property(p => p.UserQuestionBody).IsRequired();
            builder.Property(p => p.CreateTime).IsRequired();
            builder.HasMany(m => m.Answers)
                .WithOne(o => o.Question)
                .HasForeignKey(f => f.QuestionId);
        }
    }
}
