using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Enums;

namespace TaskManager.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        Task Add(UserEntity user);
        Task<UserEntity> GetByEmail(string email);
        Task<HashSet<PermissionEnum>> GetUserPermissions(Guid userId);
    }
}
