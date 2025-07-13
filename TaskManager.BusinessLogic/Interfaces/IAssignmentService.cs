using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.DTO;
using TaskManager.DataAccess.Entities;

namespace TaskManager.BusinessLogic.Interfaces
{
    public interface IAssignmentService
    {
        Task<List<AssignmentEntity>> GetAllAsync();
        Task<AssignmentEntity?> GetByIdAsync(Guid id);
        Task CreateAsync(string title, string description, Guid groupId);
        Task UpdateAsync(Guid id, UpdateAssignmentDto dto);
        Task DeleteAsync(Guid id);
    }
}
