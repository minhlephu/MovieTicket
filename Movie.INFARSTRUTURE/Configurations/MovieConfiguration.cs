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
    public class MovieConfiguration: IEntityTypeConfiguration<Entities.Movie>
    {
        public void Configure(EntityTypeBuilder<Entities.Movie> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(e => e.mv_id);
            builder.Property(e => e.mv_name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(e => e.release_date)
                .IsRequired();
            builder.Property(e => e.duration)
                .IsRequired();
            builder.HasOne(e => e.genre).WithMany(e => e.movies).HasForeignKey(e => e.genre_id);
        }
    }
}
