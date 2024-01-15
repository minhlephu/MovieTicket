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
    public class TheaterConfiguration: IEntityTypeConfiguration<Theater>
    {
        public void Configure(EntityTypeBuilder<Theater> builder)
        {
            builder.ToTable("Theaters");
            builder.HasKey(e => e.theater_id);
            builder.Property(e => e.theater_id).IsRequired();
            builder.Property(e => e.row_qty).IsRequired();
            builder.Property(e => e.col_qty).IsRequired();
            builder.Property(e => e.cinema_id).IsRequired();
            builder.HasOne(e => e.cinema).WithMany(e => e.theater).HasForeignKey(e => e.theater_id);

        }
    }
}
