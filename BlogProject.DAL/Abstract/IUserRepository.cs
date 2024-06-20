using BlogProject.Core.IBaseRepositories;
using BlogProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Abstract
{
    public interface IUserRepository : IIdentityRepository<AppUser>
    {
        Task<AppUser> GetByIdAsync(int id);

        Task<AppUser> GetUserAsync(Expression<Func<AppUser, bool>> predicate,
                                   params Expression<Func<AppUser, object>>[] includeProperties);
    }
}
