using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.UserName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Email)
                .IsRequired();
            builder.Property(a => a.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
