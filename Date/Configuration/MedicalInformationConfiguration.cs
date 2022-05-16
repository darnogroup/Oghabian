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
    public class MedicalInformationConfiguration:IEntityTypeConfiguration<MedicalInformationEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalInformationEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.UserWeight).IsRequired();
            builder.Property(p => p.UserHeight).IsRequired();
            builder.Property(p => p.UserAge).IsRequired();
            builder.Property(p => p.UserGender).IsRequired();
        
        }
    }
}
