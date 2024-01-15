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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.user_id);
            builder.Property(e => e.user_id).IsRequired();
            builder.Property(e => e.user_name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.password).IsRequired().HasMaxLength(100);
            builder.Property(e => e.email).IsRequired();
            builder.Property(e => e.gender).IsRequired();
            builder.Property(e => e.role_id).IsRequired();
            builder.HasOne(e => e.role).WithMany(e => e.user).HasForeignKey(e => e.role_id);
        }
    }
}
