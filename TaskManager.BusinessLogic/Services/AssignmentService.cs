using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.BusinessLogic.Services
{
    public class AssignmentService(IAssignmentRepository assignmentRepository) : IAssignmentService
    {
        public async Task CreateAsync(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty");
            }            
            
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty");
            }

            var assignment = new Assignment
            {
                Title = title,
                Description = description
            };

            await assignmentRepository.CreateAssignment(assignment);
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            var assignments = await assignmentRepository.GetAllAssignments();

            if (assignments is null)
            {
                throw new Exception("Tasks not found");
            }

            return assignments;
        }
    }
}
