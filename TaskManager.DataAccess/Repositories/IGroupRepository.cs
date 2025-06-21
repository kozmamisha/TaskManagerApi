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
        Task<List<GroupEntity>> GetAllGroups();
        Task<GroupEntity?> GetGroupById(Guid id);
        Task CreateGroup(GroupEntity group);
        Task UpdateGroup(GroupEntity group);
        Task DeleteGroup(GroupEntity group);
    }
}
