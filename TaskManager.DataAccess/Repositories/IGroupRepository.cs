using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Repositories
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllGroups();
        Task<Group?> GetGroupById(Guid id);
        Task CreateGroup(Group group);
        Task UpdateGroup(Group group);
        Task DeleteGroup(Group group);
    }
}
