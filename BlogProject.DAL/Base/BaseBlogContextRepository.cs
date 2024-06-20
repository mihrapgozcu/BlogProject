using BlogProject.Core.BaseEntities;
using BlogProject.Core.IBaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Base
{
    public class BaseBlogContextRepository<TEntity, TContext> : IBaseBlogContextRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        protected readonly TContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseBlogContextRepository(TContext context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _dbSet.CountAsync(predicate);
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, 
                                                params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, 
                                            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return await query.SingleAsync();
        }

        //Update metodu async olarak yok. O yüzden bu şekil yazdık. 
        public async Task<TEntity> Update(TEntity entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            return entity;
        }
    }
}
