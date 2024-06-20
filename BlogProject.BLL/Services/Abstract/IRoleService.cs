using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Roles;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleVM>> GetAllRoles();

        Task<IdentityResult> CreateRole(RoleCreateVM roleCreateVM);

        Task<AppRole> GetAppRoleById(int id);

        Task<IdentityResult> UpdateRole(RoleUpdateVM roleUpdateVM);

        Task<IdentityResult> DeleteRole(int id);
    }
}
