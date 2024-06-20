using BlogProject.Core.IBaseRepositories;
using BlogProject.DAL.Abstract;
using BlogProject.DAL.Concrete.Context;
using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.Repositories.IdentityRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppIdentityContext _db;

        public UserRepository(UserManager<AppUser> userManager, AppIdentityContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task Create(AppUser entity)
        {
            await _userManager.CreateAsync(entity);
        }

        public async Task Delete(AppUser entity)
        {
            await _userManager.DeleteAsync(entity);
        }

        public Task<AppUser> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return _userManager.Users.ToList();
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task Update(AppUser entity)
        {
            await _userManager.UpdateAsync(entity);
        }

        public async Task<AppUser> GetUserAsync(Expression<Func<AppUser, bool>> predicate,
                                            params Expression<Func<AppUser, object>>[] includeProperties)
        {
            IQueryable<AppUser> query = _db.Set<AppUser>();
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
    }
}
