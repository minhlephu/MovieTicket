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
    public class MovieTypeConfiguration: IEntityTypeConfiguration<MovieType>
    {
        public void Configure(EntityTypeBuilder<MovieType> builder)
        {
            builder.ToTable("MovieType");
            builder.HasKey(e => e.MovieTypeID);
            builder.Property(e => e.MovieTypeID).IsRequired();
            builder.Property(e => e.MovieTypeName).IsRequired();        
        }
    }
}
