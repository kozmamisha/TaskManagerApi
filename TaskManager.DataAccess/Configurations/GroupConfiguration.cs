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
    public class GroupConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder
                .HasMany(g => g.Tasks)
                .WithOne(a => a.Group)
                .HasForeignKey(a => a.GroupId);
        }
    }
}
