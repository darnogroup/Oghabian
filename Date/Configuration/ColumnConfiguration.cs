using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Date.Configuration
{
    public class ColumnConfiguration:IEntityTypeConfiguration<ColumnEntity>
    {
        public void Configure(EntityTypeBuilder<ColumnEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Columns).IsRequired();
        }
    }
}
