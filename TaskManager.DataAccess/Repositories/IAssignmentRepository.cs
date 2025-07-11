﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Repositories
{
    public interface IAssignmentRepository
    {
        Task<List<AssignmentEntity>> GetAllAssignments();
        Task<AssignmentEntity?> GetAssignmentById(Guid id);
        Task CreateAssignment(Guid groupId, AssignmentEntity assignment);
        Task UpdateAssignment(AssignmentEntity assignment);
        Task DeleteAssignment(AssignmentEntity assignment);
    }
}
