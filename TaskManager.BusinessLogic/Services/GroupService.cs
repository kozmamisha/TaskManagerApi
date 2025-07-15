using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.DTO;
using TaskManager.BusinessLogic.Exceptions;
using TaskManager.BusinessLogic.Interfaces;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Interfaces;

namespace TaskManager.BusinessLogic.Services
{
    public class GroupService(IGroupRepository groupRepository) : IGroupService
    {
        public async Task CreateAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Name cannot be empty");
            }

            var group = new GroupEntity
            {
                Name = name
            };

            await groupRepository.CreateGroup(group);
        }

        public async Task DeleteAsync(Guid id)
        {
            var group = await groupRepository.GetGroupById(id)
                ?? throw new NotFoundException("This group not found");

            await groupRepository.DeleteGroup(group);
        }

        public async Task<List<GroupEntity>> GetAllAsync()
        {
            var groups = await groupRepository.GetAllGroups();

            return groups;
        }

        public async Task<GroupEntity?> GetByIdAsync(Guid id)
        {
            var group = await groupRepository.GetGroupById(id)
                ?? throw new NotFoundException("This group not found");

            return group;
        }

        public async Task UpdateAsync(Guid id, UpdateGroupDto dto)
        {
            var group = await groupRepository.GetGroupById(id)
                ?? throw new NotFoundException("This group not found");

            group.Name = dto.Name;

            if(group.Name == string.Empty)
            {
                throw new BadRequestException("Name cannot be empty");
            }

            await groupRepository.UpdateGroup(group);
        }
    }
}
