using BlogProject.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.IBaseRepositories
{
    public interface IBaseBlogContextRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Update(TEntity entity);

        //Liste döndürür.
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null,
                                   params Expression<Func<TEntity, object>>[] includeProperties);

        //Tek değer döndürür.
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
                                          params Expression<Func<TEntity, object>>[] includeProperties);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        //Seçili tabloda ne kadar eleman var?
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
