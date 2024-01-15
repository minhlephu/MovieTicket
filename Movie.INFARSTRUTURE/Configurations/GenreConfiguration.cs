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
    public class GenreConfiguration: IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre");
            builder.HasKey(x => x.genre_id);
            builder.Property(e=>e.genre_name).IsRequired().HasMaxLength(250); 
        }
    }
}
