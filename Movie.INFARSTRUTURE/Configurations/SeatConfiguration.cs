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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");
            builder.HasKey(e => e.SeatID);
            builder.Property(e => e.SeatID).IsRequired();
            builder.Property(e => e.SeatName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Status).IsRequired();
            builder.HasOne(e => e.Theater).WithMany(e => e.Seat).HasForeignKey(e => e.SeatID);
            builder.HasOne(e => e.SeatType).WithMany(e => e.Seat).HasForeignKey(e => e.SeatTypeID);
        }
    }
}
