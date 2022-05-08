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
    public class ImageConfiguration:IEntityTypeConfiguration<GalleryEntity>
    {
        public void Configure(EntityTypeBuilder<GalleryEntity> builder)
        {
            builder.HasKey(k => k.ImageId);
            builder.Property(p => p.ImagePath).IsRequired();
        }
    }
}
