using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.BusinessLogic.Services
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAllAsync();
        Task CreateAsync(string title, string description);
    }
}
