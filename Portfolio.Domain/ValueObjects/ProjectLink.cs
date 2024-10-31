using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.ValueObjects
{
    public class ProjectLink : IEquatable<ProjectLink>
    {
        public string Url { get; }

        public ProjectLink(string url) 
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new ArgumentException("Invalid URL format");

            Url = url; 
        }

        public override bool Equals(object obj) => obj is ProjectLink other && Equals(other);
        public bool Equals(ProjectLink other) => Url == other.Url;

        public override int GetHashCode() => Url.GetHashCode();
    }
}
