using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly TaskManagerDbContext _dbContext;
        public GroupRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateGroup(GroupEntity group)
        {
            await _dbContext.Groups.AddAsync(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGroup(GroupEntity group)
        {
            _dbContext.Groups.Remove(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GroupEntity>> GetAllGroups()
        {
            return await _dbContext.Groups
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<GroupEntity?> GetGroupById(Guid id)
        {
            return await _dbContext.Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateGroup(GroupEntity group)
        {
            _dbContext.Groups.Update(group);
            await _dbContext.SaveChangesAsync();
        }
    }
}
