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
    public class UserConfiguration:IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(p => p.UserWeight).IsRequired();
            builder.Property(p => p.LoginCode).IsRequired();
            builder.Property(p => p.UserAvatar).IsRequired();
            builder.Property(p => p.UserFullName).IsRequired();
            builder.Property(p => p.UserHeight).IsRequired();
            builder.Property(p => p.LoginKey).IsRequired();
            builder.Property(p => p.Role).IsRequired();
            builder.HasOne(o => o.Address)
                .WithOne(o => o.User)
                .HasForeignKey<AddressEntity>(f => f.UserId);
            builder.HasMany(m => m.CommentArticle)
                .WithOne(o => o.User)
                .HasForeignKey(f => f.UserId);    
            builder.HasMany(m => m.CommentFood)
                .WithOne(o => o.User)
                .HasForeignKey(f => f.UserId);
        }
    }
}
