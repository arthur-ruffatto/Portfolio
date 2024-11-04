using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(Guid id);
        Task<List<Project>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Guid projectId);
    }
}
