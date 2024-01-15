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
    public class BookingConfiguration: IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(e => e.bk_id);
            builder.Property(e => e.bk_id).IsRequired();
            builder.Property(e => e.price).IsRequired();
            builder.HasOne(e => e.seat).WithMany(e => e.booking).HasForeignKey(e => e.seat_id);
            builder.HasOne(e => e.fare).WithMany(e => e.booking).HasForeignKey(e => e.fare_id);
            builder.HasOne(e => e.user).WithMany(e => e.booking).HasForeignKey(e => e.user_id);

        }
    }
}
