using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.DataAccess.Extensions
{
    public static class TaskManagerExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagerDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("TaskManagerDbContext"));
            });

            services.AddScoped<IAssignmentRepository, AssignmentRepository>();

            return services;
        }
    }
}
