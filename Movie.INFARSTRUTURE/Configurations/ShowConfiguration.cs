using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.INFARSTRUTURE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Configurations
{
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {      
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.ToTable("Shows");
            builder.HasKey(e => e.show_id);
            builder.Property(e => e.show_id).IsRequired();
            builder.Property(e => e.start_time).IsRequired();
            builder.Property(e => e.end_time).IsRequired();
            builder.Property(e => e.show_date).IsRequired();
            builder.Property(e => e.mv_id).IsRequired();
            builder.HasOne(e => e.movie).WithMany(e => e.show).HasForeignKey(e => e.mv_id);
            builder.HasOne(e => e.movie_type).WithMany(e => e.show).HasForeignKey(e => e.mv_type_id);
            builder.HasOne(e => e.theater).WithMany(e => e.show).HasForeignKey(e => e.theater_id);

        }
    }
}
