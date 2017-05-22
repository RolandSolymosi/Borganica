using System;
using System.Collections.Generic;

namespace Borganica.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public State State { get; set; } = State.Lead;
        public string Creator { get; set; }
        public GeoLocation Location { get; set; }
        public Decimal Profit { get; set; } = 0;

        public ICollection<ProjectTask> Tasks { get; set; } = new HashSet<ProjectTask>();
    }
}
