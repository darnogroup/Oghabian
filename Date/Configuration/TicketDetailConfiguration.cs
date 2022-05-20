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
    public class TicketDetailConfiguration:IEntityTypeConfiguration<TicketDetailEntity>
    {
        public void Configure(EntityTypeBuilder<TicketDetailEntity> builder)
        {
            builder.HasKey(k => k.TicketDetailId);
            builder.Property(p => p.Text).IsRequired();
            
        }
    }
}
