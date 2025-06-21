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
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
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
            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRoleEntity>(
                    l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(ur => ur.RoleId),
                    r => r.HasOne<UserEntity>().WithMany().HasForeignKey(ur => ur.UserId)
                );
        }
    }
}
