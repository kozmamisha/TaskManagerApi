using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DataAccess.Entities
{
    public class GroupEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<AssignmentEntity> Tasks { get; set; } = [];
    }
}
