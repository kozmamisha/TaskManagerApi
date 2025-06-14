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

        public async Task CreateAssignment(Guid groupId, Assignment assignment)
        {
            assignment.CreatedAt = DateTime.UtcNow;
            assignment.GroupId = groupId;

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

        public async Task<Assignment?> GetAssignmentById(Guid id)
        {
            return await _dbContext.Assignments
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAssignment(Assignment assignment)
        {
            _dbContext.Assignments.Update(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAssignment(Assignment assignment)
        {
            _dbContext.Assignments.Remove(assignment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
