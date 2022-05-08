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
    public class FavoriteConfiguration:IEntityTypeConfiguration<FavoriteEntity>
    {
        public void Configure(EntityTypeBuilder<FavoriteEntity> builder)
        {
            builder.HasKey(k => k.FavoriteId);
            builder.HasOne(o => o.User)
                .WithMany(m => m.Favorite)
                .HasForeignKey(f => f.UserId);
        }
    }
}
