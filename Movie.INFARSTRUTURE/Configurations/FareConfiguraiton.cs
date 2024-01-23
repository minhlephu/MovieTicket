using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.INFARSTRUTURE.Entities;

namespace Movie.INFARSTRUTURE.Configurations
{
    public class FareConfiguraiton: IEntityTypeConfiguration<Fare>
    {
        public void Configure(EntityTypeBuilder<Fare> builder)
        {
            builder.ToTable("Fare");
            builder.HasKey(e => e.FareID);
            builder.Property(e => e.FareID).IsRequired();
            builder.Property(e => e.FareName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.UnitPrice).IsRequired();         
        }
    }
}
