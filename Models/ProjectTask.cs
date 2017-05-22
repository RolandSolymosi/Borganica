using System;
using System.Collections.Generic;
using System.Text;

namespace Borganica.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTimeOffset Started { get; set; }
        
        public int? OwnerTaskId { get; set; }
        public ProjectTask OwnerTask { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public string Creator { get; set; }

        public ICollection<ProjectTask> SubTasks { get; set; } = new HashSet<ProjectTask>();
    }
}
