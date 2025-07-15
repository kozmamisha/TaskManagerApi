using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.BusinessLogic.DTO;
using TaskManager.BusinessLogic.Exceptions;
using TaskManager.BusinessLogic.Interfaces;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.Interfaces;

namespace TaskManager.BusinessLogic.Services
{
    public class AssignmentService(IAssignmentRepository assignmentRepository, IGroupRepository groupRepository) : IAssignmentService
    {
        public async Task CreateAsync(string title, string? description, Guid groupId)
        {
            var currentGroup = await groupRepository.GetGroupById(groupId)
                ?? throw new NotFoundException("Group not found");

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new BadRequestException("Title cannot be empty");
            }

            var assignment = new AssignmentEntity
            {
                Title = title,
                Description = description ?? "",
                GroupId = groupId
            };

            await assignmentRepository.CreateAssignment(assignment);
        }

        public async Task<List<AssignmentEntity>> GetAllAsync()
        {
            var assignments = await assignmentRepository.GetAllAssignments();

            return assignments;
        }

        public async Task<AssignmentEntity?> GetByIdAsync(Guid id)
        {
            var assignment = await assignmentRepository.GetAssignmentById(id)
                ?? throw new NotFoundException("This task not found");

            return assignment;
        }

        public async Task UpdateAsync(Guid id, UpdateAssignmentDto dto)
        {
            var currentAssignment = await assignmentRepository.GetAssignmentById(id) 
                ?? throw new NotFoundException("This task not found");

            currentAssignment.Title = dto.Title;
            currentAssignment.Description = dto.Description;

            if (currentAssignment.Title == string.Empty)
            {
                throw new BadRequestException("Title can not be empty");
            }

            await assignmentRepository.UpdateAssignment(currentAssignment);
        }

        public async Task DeleteAsync(Guid id)
        {
            var assignment = await assignmentRepository.GetAssignmentById(id)
                ?? throw new NotFoundException("This task not found");

            await assignmentRepository.DeleteAssignment(assignment);
        }
    }
}
