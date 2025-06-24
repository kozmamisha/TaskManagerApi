using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Enums;

namespace TaskManager.Infrastructure
{
    public class PermissionRequirements(PermissionEnum[] permissions) : IAuthorizationRequirement
    {
        public PermissionEnum[] Permissions { get; set; } = permissions;
    }
}
