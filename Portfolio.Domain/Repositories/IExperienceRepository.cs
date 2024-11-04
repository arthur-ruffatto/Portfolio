using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Repositories
{
    public interface IExperienceRepository
    {
        Task<Experience> GetByIdAsync(Guid id);
        Task<List<Experience>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Experience experience);
        Task UpdateAsync(Experience experience);
        Task DeleteAsync(Experience experienceId);
    }
}
