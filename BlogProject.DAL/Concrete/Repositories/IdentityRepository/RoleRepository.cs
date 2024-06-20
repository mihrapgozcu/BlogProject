using BlogProject.DAL.Abstract;
using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.Repositories.IdentityRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleRepository(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Create(AppRole entity)
        {
            await _roleManager.CreateAsync(entity);
        }

        public async Task Delete(AppRole entity)
        {
            await _roleManager.DeleteAsync(entity);
        }

        public async Task<AppRole> FindById(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<AppRole>> GetAll()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<AppRole> GetByIdAsync(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task Update(AppRole entity)
        {
            await _roleManager.UpdateAsync(entity);
        }
    }
}
