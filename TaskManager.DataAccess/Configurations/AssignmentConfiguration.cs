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
    public class AssignmentConfiguration : IEntityTypeConfiguration<AssignmentEntity>
    {
        public void Configure(EntityTypeBuilder<AssignmentEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.GroupId)
                .IsRequired();

            builder
                .HasOne(a => a.Group)
                .WithMany(g => g.Tasks)
                .HasForeignKey(a => a.GroupId);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(70);
            
            builder.Property(a => a.Description)
                .HasMaxLength(200);
        }
    }
}
