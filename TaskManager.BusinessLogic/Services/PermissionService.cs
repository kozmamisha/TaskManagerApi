using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Enums;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.BusinessLogic.Services
{
    public class PermissionService(IUsersRepository usersRepository) : IPermissionService
    {
        public Task<HashSet<PermissionEnum>> GetPermissionAsync(Guid userId)
        {
            return usersRepository.GetUserPermissions(userId);
        }
    }
}
