using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReviewsAPI.Data;
using ReviewsAPI.Models;
using ReviewsAPI.Repositories;
using ReviewsAPI.Repositories.Interfaces;

namespace ReviewsAPI.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ReviewsContext _context;

        public GenericRepository(ReviewsContext contexts)
        {
            _context = contexts;
        }

        public async Task<long> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id; 
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return await  _context.Set<TEntity>()
                .AsNoTracking()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<TEntity> GetByConditionSingleAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .Where(expression)
                .FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
