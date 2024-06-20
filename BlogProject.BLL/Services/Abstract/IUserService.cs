using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserVM>> GetAllUsersWithRole();

        Task<List<AppRole>> GetAllRoles();

        Task<IdentityResult> CreateUser(UserCreateVM userCreateVM);

        Task<AppUser> GetAppUserById(int id);

        Task<IdentityResult> UpdateUser(UserUpdateVM userUpdateVM);

        Task<string> GetUserRole(AppUser appUser);

        Task<IdentityResult> DeleteUser(int id);

        Task<UserProfileVM> GetUserProfile();

        Task<bool> UserProfileUpdate(UserProfileVM userProfileVM);
    }
}
