﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.Services;
using TaskManager.Infrastructure;

namespace TaskManager.BusinessLogic.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAssignmentService, AssignmentService>();
            serviceCollection.AddScoped<IGroupService, GroupService>();
            serviceCollection.AddScoped<IUsersService, UsersService>();

            serviceCollection.AddScoped<IJwtProvider, JwtProvider>();
            serviceCollection.AddScoped<IPasswordHasher, PasswordHasher>();

            return serviceCollection;
        }
    }
}
