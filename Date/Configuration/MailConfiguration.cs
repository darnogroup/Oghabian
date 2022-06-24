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
    public class MailConfiguration:IEntityTypeConfiguration<MailEntity>
    {
        public void Configure(EntityTypeBuilder<MailEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Mail).IsRequired();
        }
    }
}
