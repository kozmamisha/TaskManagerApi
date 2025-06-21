using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.DTO;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.BusinessLogic.Services
{
    public class GroupService(IGroupRepository groupRepository) : IGroupService
    {
        public async Task CreateAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name cannot be empty");
            }

            var group = new GroupEntity
            {
                Name = name
            };

            await groupRepository.CreateGroup(group);
        }

        public async Task DeleteAsync(Guid id)
        {
            var group = await groupRepository.GetGroupById(id);

            if (group is null)
            {
                throw new Exception("Group is not found");
            }

            await groupRepository.DeleteGroup(group);
        }

        public async Task<List<GroupEntity>> GetAllAsync()
        {
            var groups = await groupRepository.GetAllGroups();

            if (groups is null)
            {
                throw new Exception("Groups not found");
            }

            return groups;
        }

        public async Task<GroupEntity?> GetByIdAsync(Guid id)
        {
            var group = await groupRepository.GetGroupById(id);

            if (group is null)
            {
                throw new Exception("Group is not found");
            }

            return group;
        }

        public async Task UpdateAsync(Guid id, UpdateGroupDto dto)
        {
            var group = await groupRepository.GetGroupById(id);

            if (group is null)
            {
                throw new Exception("This task not found");
            }

            group.Name = dto.Name;

            await groupRepository.UpdateGroup(group);
        }
    }
}
