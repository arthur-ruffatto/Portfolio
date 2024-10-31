using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        //TODO: Create Enumerable for level
        public string Level { get; set; } //Beginner, Intermediate, etc...

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
