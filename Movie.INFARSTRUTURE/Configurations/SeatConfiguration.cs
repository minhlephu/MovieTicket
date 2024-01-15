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
    public class SeatConfiguration: IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");
            builder.HasKey(e => e.seat_id);
            builder.Property(e => e.seat_id).IsRequired();
            builder.Property(e => e.row_loc).IsRequired().HasMaxLength(20);
            builder.Property(e => e.col_loc).IsRequired();
            builder.Property(e => e.status).IsRequired();
            builder.Property(e => e.theater_id).IsRequired();
            builder.HasOne(e => e.theater).WithMany(e => e.seat).HasForeignKey(e => e.seat_id);
            builder.HasOne(e => e.seat_type).WithMany(e => e.seat).HasForeignKey(e => e.seat_type_id);
        }
    }
}
