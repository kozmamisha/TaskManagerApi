using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.DTO;
using TaskManager.DataAccess.Entities;

namespace TaskManager.BusinessLogic.Services
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAllAsync();
        Task<Assignment?> GetByIdAsync(Guid id);
        Task CreateAsync(string title, string description, Guid groupId);
        Task UpdateAsync(Guid id, UpdateAssignmentDto dto);
        Task DeleteAsync(Guid id);
    }
}
