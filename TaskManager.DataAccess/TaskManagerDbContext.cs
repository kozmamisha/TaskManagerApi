using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Configurations;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess
{
    public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
