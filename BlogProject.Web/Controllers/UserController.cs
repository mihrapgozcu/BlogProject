using BlogProject.BLL.Services.Abstract;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.ViewModels.Users;
using BlogProject.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Controllers
{
    [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Author}")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
            else
            {
                var profile = await _userService.GetUserProfile();
                return View(profile);
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (result.Succeeded)
            {
                return RedirectToAction("About", "Home", new { Area = "" });
            }
            else
            {
                result.AddToIdentityModelState(this.ModelState);
            }

            return NotFound();
        }
    }
}
