using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface INoteRepository
    {
        Task<Note> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Note entity);
        Task<IQueryable<Note>> GetAllAsync();
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Note entity);
        Task<IQueryable<Note>> GetAsync(Expression<Func<Note, bool>> predicate);
    }
}
