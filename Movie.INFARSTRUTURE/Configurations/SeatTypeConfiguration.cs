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
    public class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
    {
        public void Configure(EntityTypeBuilder<SeatType> builder)
        {
            builder.ToTable("SeatType");
            builder.HasKey(e => e.SeatTypeID);
            builder.Property(e => e.SeatTypeID).IsRequired();
            builder.Property(e => e.SeatName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Surcharge).IsRequired();
        }
    }
}
