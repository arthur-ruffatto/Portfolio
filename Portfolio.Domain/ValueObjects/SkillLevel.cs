using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.ValueObjects
{
    public class SkillLevel : IEquatable<SkillLevel>
    {
        public string Level { get; }

        private static readonly HashSet<string> ValidLevels = new HashSet<string>
        {
            "Beginner",
            "Intermediate",
            "Advanced"
        };

        public SkillLevel(string level) 
        {
            if (!ValidLevels.Contains(level))
                throw new ArgumentException($"Invalid skill level: {level}");

            Level = level;
        }

        public override bool Equals(object obj) => obj is SkillLevel other && Equals(other);
        public bool Equals(SkillLevel other) => Level == other.Level;

        public override int GetHashCode() => Level.GetHashCode();
    }
}
