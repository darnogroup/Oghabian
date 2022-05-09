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
    public class StateConfiguration:IEntityTypeConfiguration<StateEntity>
    {
        public void Configure(EntityTypeBuilder<StateEntity> builder)
        {
            builder.HasKey(k => k.StateId);
            builder.Property(p => p.StateName).IsRequired();
            builder.HasMany(m => m.Cities).WithOne(o => o.State)
                .HasForeignKey(f => f.StateId);
            builder.HasMany(m => m.Address)
                .WithOne(o => o.State)
                .HasForeignKey(f => f.StateId);
        }
    }
}
