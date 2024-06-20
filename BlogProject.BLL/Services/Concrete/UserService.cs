using AutoMapper;
using BlogProject.BLL.Helpers.Images;
using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Abstract;
using BlogProject.DAL.Entities;
using BlogProject.DAL.Enums;
using BlogProject.DAL.UnitOfWorks;
using BlogProject.DAL.ViewModels.Users;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ClaimsPrincipal _user;
        private readonly IUserRepository _userRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IImageHelper _imageHelper;
        private readonly IImageRepository _imageRepo;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IUserRepository userRepo, SignInManager<AppUser> signInManager, IImageHelper imageHelper, IImageRepository imageRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _user = httpContextAccessor.HttpContext.User;
            _userRepo = userRepo;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
            _imageRepo = imageRepo;
        }


        public async Task<List<UserVM>> GetAllUsersWithRole()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserVM>>(users);     //users listesi, UserVM listesine dönüştürüldü.

            //amaç GetRolesAsync metoduyla kullanıcının rolu bulunarak UserVM içindeki string Role prop'una bu değeri atamaktır.
            foreach (var item in map)
            {
                var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser));
                item.Role = role;
            }

            return map;
        }


        public async Task<List<AppRole>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }


        public async Task<IdentityResult> CreateUser(UserCreateVM userCreateVM)
        {
            var map = _mapper.Map<AppUser>(userCreateVM);
            map.UserName = userCreateVM.Email;
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userCreateVM.Password) ? "" : userCreateVM.Password);    //2. parametre olarak şifreyi yazma nedenimiz password hassing olayı. string.IsNullOrEmpty kullanmazsak şifre boş olunca hata döndürmek yerine sayfa hataya düşüyor.
            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userCreateVM.RoleId.ToString());
                await _userManager.AddToRoleAsync(map, findRole.ToString());
                return result; 
            }
            else
            {
                return result; 
            }
        }


        public async Task<AppUser> GetAppUserById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user;
        }


        public async Task<IdentityResult> UpdateUser(UserUpdateVM userUpdateVM)
        {
            var user = await GetAppUserById(userUpdateVM.Id);
            var userRole = await GetUserRole(user);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)      
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await _roleManager.FindByIdAsync(userUpdateVM.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
            {
                return result;
            }
        }


        public async Task<string> GetUserRole(AppUser appUser)
        {
            var userRole = string.Join("", await _userManager.GetRolesAsync(appUser));
            return userRole;
        }


        public async Task<IdentityResult> DeleteUser(int id)
        {
            var user = await GetAppUserById(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return result;
            }
            else
            {
                return result;
            }
        }


        public async Task<UserProfileVM> GetUserProfile()
        {
            var userId = _user.GetLoggedInUserId();
            var user = await _userRepo.GetUserAsync(x => x.Id == userId);
            var map = _mapper.Map<UserProfileVM>(user);

            return map;
        }


        public async Task<bool> UserProfileUpdate(UserProfileVM userProfileVM) 
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserById(userId);

            var isVerified = await _userManager.CheckPasswordAsync(user, userProfileVM.CurrentPassword);  //user şifre doğrulanır
            if (isVerified && userProfileVM.NewPassword != null)    //user doğrulanmış ve şifre değiştiriyorsa***
            {
                var result = await _userManager.ChangePasswordAsync(user, userProfileVM.CurrentPassword, userProfileVM.NewPassword);    //şifreyi değiştir
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();    //user'ı sign out yapıldı
                    await _signInManager.PasswordSignInAsync(user, userProfileVM.NewPassword, true, false);
                   

                    user.FirstName = userProfileVM.FirstName;
                    user.LastName = userProfileVM.LastName;
                    user.PhoneNumber = userProfileVM.PhoneNumber;
                    user.About = userProfileVM.About;
                    //_mapper.Map(userProfileVM, user);

                    //resim null değilse değiştir, null ise devam eder.
                    if (userProfileVM.Photo != null)
                    {
                        var imageUpload = await _imageHelper.Upload($"{userProfileVM.FirstName}{userProfileVM.LastName}", userProfileVM.Photo, ImageType.User);
                        user.Path = imageUpload.FullName;
                    }

                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (isVerified)    //user doğrulanmış fakat şifre değiştirmiyor***
            {
                await _userManager.UpdateSecurityStampAsync(user);

                user.FirstName = userProfileVM.FirstName;
                user.LastName = userProfileVM.LastName;
                user.PhoneNumber = userProfileVM.PhoneNumber;
                user.About = userProfileVM.About;
               

                if (userProfileVM.Photo != null)
                {
                    var imageUpload = await _imageHelper.Upload($"{userProfileVM.FirstName}{userProfileVM.LastName}", userProfileVM.Photo, ImageType.User);
                    user.Path = imageUpload.FullName;
                }

                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
