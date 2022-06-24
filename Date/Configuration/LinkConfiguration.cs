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
    public class LinkConfiguration:IEntityTypeConfiguration<LinkEntity>
    {
        public void Configure(EntityTypeBuilder<LinkEntity> builder)
        {
            builder.HasKey(k => k.LinkId);
            builder.Property(p => p.Link).IsRequired();
            builder.Property(p => p.LinkTitle).IsRequired();
        }
    }
}
