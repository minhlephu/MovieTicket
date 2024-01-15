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
    public class Movie_typeConfiguration: IEntityTypeConfiguration<Movie_type>
    {
        public void Configure(EntityTypeBuilder<Movie_type> builder)
        {
            builder.ToTable("Movie_type");
            builder.HasKey(e => e.mv_type_id);
            builder.Property(e => e.mv_type_id).IsRequired();
            builder.Property(e => e.mv_type_name).IsRequired();        
        }
    }
}
