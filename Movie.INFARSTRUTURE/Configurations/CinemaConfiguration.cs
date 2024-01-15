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
    public class CinemaConfiguration: IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.ToTable("Cinemas");
            builder.HasKey(e => e.cinema_id);
            builder.Property(e => e.cinema_id).IsRequired();
            builder.Property(e => e.cinema_name).IsRequired();
            builder.HasOne(e => e.city).WithMany(e => e.cinema).HasForeignKey(e => e.city_id);
        }
    }
}
