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
    public class TicketConfiguration:IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.HasKey(k => k.TicketId);
            builder.HasMany(m => m.Ticket)
                .WithOne(o => o.Ticket)
                .HasForeignKey(f => f.TicketId);
        }
    }
}
