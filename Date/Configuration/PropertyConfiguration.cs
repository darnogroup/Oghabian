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
    public class PropertyConfiguration:IEntityTypeConfiguration<PropertyEntity>
    {
        public void Configure(EntityTypeBuilder<PropertyEntity> builder)
        {
            builder.HasKey(k => k.PropertyId);
            builder.Property(p => p.PropertyTitle).IsRequired();
            builder.Property(p => p.PropertyValue).IsRequired();
        }
    }
}
