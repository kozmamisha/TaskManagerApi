using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Repositories
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAllAssignments();
        Task<Assignment?> GetAssignmentById(Guid id);
        Task CreateAssignment(Guid groupId, Assignment assignment);
        Task UpdateAssignment(Assignment assignment);
        Task DeleteAssignment(Assignment assignment);
    }
}
