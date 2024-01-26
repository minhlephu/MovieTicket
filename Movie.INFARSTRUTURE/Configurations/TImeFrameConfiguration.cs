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
    public class TImeFrameConfiguration: IEntityTypeConfiguration<TimeFrame>
    {
        public void Configure(EntityTypeBuilder<TimeFrame> builder)
        {
            builder.ToTable("TimeFrames");
            builder.HasKey(e => e.TimeFrameID);
            builder.Property(e => e.TimeFrameID).IsRequired();
            builder.Property(e => e.StartTime).IsRequired();
            builder.Property(e => e.EndTime).IsRequired();
            builder.HasMany(s => s.Show).WithMany(e => e.TimeFrame).UsingEntity(j => j.ToTable("ShowTimeFrame"));

        }
    }
}
