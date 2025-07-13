using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Enums;

namespace TaskManager.BusinessLogic.Interfaces
{
    public interface IPermissionService
    {
        Task<HashSet<PermissionEnum>> GetPermissionAsync(Guid userId);
    }
}
