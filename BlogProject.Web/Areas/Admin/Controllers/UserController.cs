using AutoMapper;
using BlogProject.BLL.Helpers.Images;
using BlogProject.BLL.Services.Abstract;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Users;
using BlogProject.Web.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Admin}")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUser> _validator;

        public UserController(IUserService userService, IMapper mapper, IValidator<AppUser> validator)
        {
            _userService = userService;
            _mapper = mapper;
            _validator = validator;
        }

        
        //kullanılan metotlar Identity sınıfının kendi metotları.
        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAllUsersWithRole();
            return View(result);   //bilgileriyle birlikte UserVM listesini geri döndürmüş oluruz.
        }


        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            var roles = await _userService.GetAllRoles();
            return View( new UserCreateVM { Roles = roles } );
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateVM userCreateVM)
        {
            var map = _mapper.Map<AppUser>(userCreateVM);
            var roles = await _userService.GetAllRoles();
            var validation = await _validator.ValidateAsync(map);

            if (!ModelState.IsValid)
            {
                return View(new UserCreateVM { Roles = roles });
            }

            var result = await _userService.CreateUser(userCreateVM);  
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
               
                result.AddToIdentityModelState(this.ModelState);    
                validation.AddToModelState(this.ModelState);        
                return View(new UserCreateVM { Roles = roles });
            }
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id) 
        {
            var user = await _userService.GetAppUserById(id);
            var roles = await _userService.GetAllRoles();
            var map = _mapper.Map<UserUpdateVM>(user);
            map.Roles = roles;
            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateVM userUpdateVM ) 
        {
            var user = await _userService.GetAppUserById(userUpdateVM.Id);

            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userService.GetAllRoles();

            if (!ModelState.IsValid)
            {
                return View(new UserCreateVM { Roles = roles });
            }

            var map = _mapper.Map(userUpdateVM, user);
            var validation = await _validator.ValidateAsync(map);

            if (!validation.IsValid)    //Bizim yazdığımız validation kontrolü.
            {
                validation.AddToModelState(this.ModelState);
                return View(new UserUpdateVM { Roles = roles });
            }

            user.UserName = userUpdateVM.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            var result = await _userService.UpdateUser(userUpdateVM);

            if (result.Succeeded)       //Identity kendi kontrolü.
            {
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
                return View(new UserUpdateVM { Roles = roles });
            }
        }


        public async Task<IActionResult> Delete(int id) 
        {
            var result = await _userService.DeleteUser(id);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await _userService.GetUserProfile();
            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileVM userProfileVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (userProfileVM.CurrentPassword == null)
            {
                ModelState.AddModelError("", "Profilinizi güncellemek için mevcut şifrenizi girmek zorundasınız.");
                var profile = await _userService.GetUserProfile();
                return View(profile);
            }

            var result = await _userService.UserProfileUpdate(userProfileVM);
            if (result)
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            else
            {
                var profile = await _userService.GetUserProfile();
                return View(profile);
            }
        }
    }
}
