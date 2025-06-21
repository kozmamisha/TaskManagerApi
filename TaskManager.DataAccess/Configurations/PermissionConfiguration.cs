using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.Enums;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Configurations
{
    public partial class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.HasKey(p => p.Id);

            var permissions = Enum
                .GetValues<PermissionEnum>()
                .Select(p => new PermissionEntity
                {
                    // converting "p" to "int" type, taking data from enum and convert it to string
                    Id = (int)p,
                    Name = p.ToString()
                });

            builder.HasData(permissions);
        }
    }
}
