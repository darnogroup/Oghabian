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
    public class UserAnswerConfiguration:IEntityTypeConfiguration<UserAnswerEntity>
    {
        public void Configure(EntityTypeBuilder<UserAnswerEntity> builder)
        {
            builder.HasKey(k => k.UserAnswerId);
            builder.Property(p => p.UserAnswerBody).IsRequired();
        }
    }
}
