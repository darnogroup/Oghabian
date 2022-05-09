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
    public class MessageConfiguration:IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.HasKey(k => k.MessageId);
            builder.Property(p => p.MessageBody).IsRequired();
            builder.Property(p => p.MessageMail).IsRequired();
            builder.Property(p => p.MessageNumber).IsRequired();
            builder.Property(p => p.MessageSender).IsRequired();
            builder.Property(p => p.MessageTitle).IsRequired();
        }
    }
}
