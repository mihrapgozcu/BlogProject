using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.IBaseRepositories
{
    public interface IIdentityRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        Task Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();
    }
}
