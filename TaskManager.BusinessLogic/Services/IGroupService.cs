using TaskManager.BusinessLogic.DTO;
using TaskManager.DataAccess.Entities;

namespace TaskManager.BusinessLogic.Services
{
    public interface IGroupService
    {
        Task<List<GroupEntity>> GetAllAsync();
        Task<GroupEntity?> GetByIdAsync(Guid id);
        Task CreateAsync(string name);
        Task UpdateAsync(Guid id, UpdateGroupDto dto);
        Task DeleteAsync(Guid id);
    }
}
