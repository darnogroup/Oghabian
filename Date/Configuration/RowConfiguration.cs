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
    public class RowConfiguration:IEntityTypeConfiguration<RowEntity>
    {
        public void Configure(EntityTypeBuilder<RowEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.TableName).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Rows).IsRequired();
            builder.Property(p => p.Count).IsRequired();
            builder.HasMany(m => m.Columns)
                .WithOne(o => o.Row)
                .HasForeignKey(f => f.RowId);
        }
    }
}
