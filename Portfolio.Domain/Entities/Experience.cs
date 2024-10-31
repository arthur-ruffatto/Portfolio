using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Experience
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Company { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
