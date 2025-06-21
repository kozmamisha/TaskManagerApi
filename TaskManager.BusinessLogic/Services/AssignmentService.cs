using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.DTO;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.BusinessLogic.Services
{
    public class AssignmentService(IAssignmentRepository assignmentRepository) : IAssignmentService
    {
        public async Task CreateAsync(string title, string description, Guid groupId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty");
            }            
            
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty");
            }

            var assignment = new AssignmentEntity
            {
                Title = title,
                Description = description
            };

            await assignmentRepository.CreateAssignment(groupId, assignment);
        }

        public async Task<List<AssignmentEntity>> GetAllAsync()
        {
            var assignments = await assignmentRepository.GetAllAssignments();

            if (assignments is null)
            {
                throw new Exception("Tasks not found");
            }

            return assignments;
        }

        public async Task<AssignmentEntity?> GetByIdAsync(Guid id)
        {
            var assignment = await assignmentRepository.GetAssignmentById(id);

            if (assignment is null)
            {
                throw new Exception("This task not found");
            }

            return assignment;
        }

        public async Task UpdateAsync(Guid id, UpdateAssignmentDto dto)
        {
            var currentAssignment = await assignmentRepository.GetAssignmentById(id);

            if (currentAssignment is null)
            {
                throw new Exception("This task not found");
            }

            currentAssignment.Title = dto.Title;
            currentAssignment.Description = dto.Description;

            await assignmentRepository.UpdateAssignment(currentAssignment);
        }

        public async Task DeleteAsync(Guid id)
        {
            var assignment = await assignmentRepository.GetAssignmentById(id);

            if (assignment is null)
            {
                throw new Exception("Task is not found");
            }

            await assignmentRepository.DeleteAssignment(assignment);
        }
    }
}
