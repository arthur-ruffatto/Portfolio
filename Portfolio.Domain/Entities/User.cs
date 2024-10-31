using Portfolio.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public FullName Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
