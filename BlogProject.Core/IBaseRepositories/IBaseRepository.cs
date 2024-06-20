using BlogProject.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.IBaseRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);    
        
        Task Delete(TEntity entity);
        
        Task<TEntity> FindById(int id);
    }
}
