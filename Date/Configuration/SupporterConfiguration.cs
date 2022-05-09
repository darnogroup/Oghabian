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
   public class SupporterConfiguration:IEntityTypeConfiguration<SupporterEntity>
    {
        public void Configure(EntityTypeBuilder<SupporterEntity> builder)
        {
            builder.HasKey(k => k.SupporterId);
            builder.Property(p => p.SupporterActivity).IsRequired();
            builder.Property(p => p.SupporterAddress).IsRequired();
            builder.Property(p => p.SupporterDescription).IsRequired();
            builder.Property(p => p.SupporterImage).IsRequired();
            builder.Property(p => p.SupporterMail).IsRequired();
            builder.Property(p => p.SupporterNumber).IsRequired();
            builder.Property(p => p.SupporterName).IsRequired();
        }
    }
}
