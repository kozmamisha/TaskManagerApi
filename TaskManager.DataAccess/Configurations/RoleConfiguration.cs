using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Enums;

namespace TaskManager.DataAccess.Configurations
{
    public partial class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<RolePermissionEntity>(
                    l => l.HasOne<PermissionEntity>()
                        .WithMany()
                        .HasForeignKey(rp => rp.PermissionId),
                    r => r.HasOne<RoleEntity>()
                        .WithMany()
                        .HasForeignKey(rp => rp.RoleId)
                );

            var roles = Enum
                .GetValues<RoleEnum>()
                .Select(r => new RoleEntity
                {
                    // converting "r" to "int" type, taking data from enum and convert it to string
                    Id = (int)r,
                    Name = r.ToString()
                });

            builder.HasData(roles);
        }
    }
}
