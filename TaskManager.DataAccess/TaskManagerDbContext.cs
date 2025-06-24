using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Configurations;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess
{
    public class TaskManagerDbContext(
        DbContextOptions<TaskManagerDbContext> options, 
        IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
        public DbSet<AssignmentEntity> Assignments { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));

            base.OnModelCreating(modelBuilder);
        }
    }
}
