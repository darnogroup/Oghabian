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
    public class AdsConfiguration:IEntityTypeConfiguration<AdsEntity>
    {
        public void Configure(EntityTypeBuilder<AdsEntity> builder)
        {
            builder.HasKey(k => k.AdsId);
            builder.Property(p => p.ImageOne);
            builder.Property(p => p.ImageOneAlt).IsRequired();
            builder.Property(p => p.ImageOneLink).IsRequired();
            builder.Property(p => p.ImageTwo).IsRequired();
            builder.Property(p => p.ImageTwoAlt).IsRequired();
            builder.Property(p => p.ImageTwoLink).IsRequired();
            builder.Property(p => p.ImageSidebar).IsRequired();
            builder.Property(p => p.ImageSidebarAlt).IsRequired();
            builder.Property(p => p.ImageSidebarAlt).IsRequired();
        
        }
    }
}
