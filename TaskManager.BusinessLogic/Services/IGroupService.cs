using TaskManager.BusinessLogic.DTO;
using TaskManager.DataAccess.Entities;

namespace TaskManager.BusinessLogic.Services
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllAsync();
        Task<Group?> GetByIdAsync(Guid id);
        Task CreateAsync(string name);
        Task UpdateAsync(Guid id, UpdateGroupDto dto);
        Task DeleteAsync(Guid id);
    }
}
