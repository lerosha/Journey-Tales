using Domain.DTO;
using Infrastructure.Exceptions;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace EF.Repositories
{
    public sealed class NoteRepository : INoteRepository
    {
        public readonly ProjectContext _context;
        public readonly DbSet<Note> _dbSet;

        public NoteRepository(ProjectContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<Note>();
        }

        public async Task<Guid> CreateAsync(Note entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IQueryable<Note>> GetAllAsync()
        {
            var models = await Task.FromResult(_dbSet.AsNoTracking());

            return models;
        }

        public async Task<IQueryable<Note>> GetAsync(Expression<Func<Note, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Note> GetByIdAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Note)}' with id '{id}' not found.");
            }

            return existEntity;
        }

        public async Task RemoveAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                return;
            }

            _dbSet.Remove(existEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note entity)
        {
            var existEntity = await _dbSet.FindAsync(entity.Id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Note)}' with id '{entity.Id}' not found.");
            }
            _context.Entry(existEntity).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
