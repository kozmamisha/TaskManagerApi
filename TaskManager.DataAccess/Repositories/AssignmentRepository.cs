using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Interfaces;

namespace TaskManager.DataAccess.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        public AssignmentRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAssignment(AssignmentEntity assignment)
        {
            assignment.CreatedAt = DateTime.UtcNow;

            await _dbContext.Assignments.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AssignmentEntity>> GetAllAssignments()
        {
            return await _dbContext.Assignments
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<AssignmentEntity?> GetAssignmentById(Guid id)
        {
            return await _dbContext.Assignments
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAssignment(AssignmentEntity assignment)
        {
            _dbContext.Assignments.Update(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAssignment(AssignmentEntity assignment)
        {
            _dbContext.Assignments.Remove(assignment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
