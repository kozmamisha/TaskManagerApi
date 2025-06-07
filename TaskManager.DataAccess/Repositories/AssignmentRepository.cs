using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        public AssignmentRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAssignment(Assignment assignment)
        {
            assignment.CreatedAt = DateTime.UtcNow;
            await _dbContext.Assignments.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Assignment>> GetAllAssignments()
        {
            return await _dbContext.Assignments
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }
    }
}
