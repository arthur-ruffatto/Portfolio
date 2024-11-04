using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<Skill> GetByIdAsync(Guid id);
        Task<List<Skill>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Guid skillId);
    }
}
