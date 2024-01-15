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
    public class Seat_typeConfiguration: IEntityTypeConfiguration<Seat_type>
    {
        public void Configure(EntityTypeBuilder<Seat_type> builder)
        {
            builder.ToTable("Seat_type");
            builder.HasKey(e => e.seat_type_id);
            builder.Property(e => e.seat_type_id).IsRequired();
            builder.Property(e => e.seat_name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.surcharge).IsRequired();
        }
    }
}
