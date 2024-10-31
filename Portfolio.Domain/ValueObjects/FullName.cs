using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.ValueObjects
{
    public class FullName : IEquatable<FullName>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("First and last names cannot be empty");

            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName() => $"{FirstName} {LastName}";

        public override bool Equals(object obj) => obj is FullName other && Equals(other);
        public bool Equals(FullName other) => FirstName == other.FirstName && LastName == other.LastName;

        public override int GetHashCode() => HashCode.Combine(FirstName, LastName);
    }
}
