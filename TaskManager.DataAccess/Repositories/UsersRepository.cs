using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Enums;

namespace TaskManager.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TaskManagerDbContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(TaskManagerDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(UserEntity user)
        {
            var roleEntity = await _context.Roles
                .SingleOrDefaultAsync(r => r.Id == (int)RoleEnum.User)
                ?? throw new InvalidOperationException();

            var newUser = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                Roles = [roleEntity]
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            // generally throw exception is not good
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception($"User with email {email} not found.");
        }

        public async Task<HashSet<PermissionEnum>> GetUserPermissions(Guid userId)
        {
            var roles = await _context.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ThenInclude(u => u.Permissions)
                .Where(u => u.Id == userId)
                .Select(u => u.Roles)
                .ToArrayAsync();

            return roles
                .SelectMany(r => r)
                .SelectMany(r => r.Permissions)
                .Select(p => (PermissionEnum)p.Id)
                .ToHashSet();
        }
    }
}
