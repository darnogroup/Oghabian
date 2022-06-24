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
    public class ChatMessageConfiguration:IEntityTypeConfiguration<ChatMessageEntity>
    {
        public void Configure(EntityTypeBuilder<ChatMessageEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Sender).IsRequired();
            builder.Property(p => p.Text).IsRequired();
            builder.HasOne(o => o.Chat)
                .WithMany(m => m.Message)
                .HasForeignKey(f => f.ChatId);
        }
    }
}
