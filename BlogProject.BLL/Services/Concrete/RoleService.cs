using AutoMapper;
using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Roles;
using BlogProject.DAL.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }


        public async Task<List<RoleVM>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var map = _mapper.Map<List<RoleVM>>(roles);
            foreach (var item in map)
            {
                var role = await _roleManager.FindByIdAsync(item.Id.ToString());
                item.RoleName = role.ToString();
            }

            return map;
        }


        public async Task<IdentityResult> CreateRole(RoleCreateVM roleCreateVM)
        {
            var map = _mapper.Map<AppRole>(roleCreateVM);
            map.Name = roleCreateVM.RoleName;
            
            var result = await _roleManager.CreateAsync(map);
            if (result.Succeeded)
            {
                return result;  //result kontrolü başarılı ise succeeded olarak dönüş yapar.
            }
            else
            {
                return result;  //result kontrolü başarısız ise hatasını döndürür.
            }
        }


        public async Task<AppRole> GetAppRoleById(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return role;
        }


        public async Task<IdentityResult> UpdateRole(RoleUpdateVM roleUpdateVM)
        {
            var role = await GetAppRoleById(roleUpdateVM.Id);
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)       //Identity kendi kontrolü.
            {
                return result;
            }
            else
            {
                return result;
            }
        }


        public async Task<IdentityResult> DeleteRole(int id)
        {
            var role = await GetAppRoleById(id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
