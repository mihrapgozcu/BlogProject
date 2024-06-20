using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            @ViewBag.UserEmail = value;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserConfirmMailVM userConfirmMailVM)
        {
            var user = await _userManager.FindByEmailAsync(userConfirmMailVM.Email);
            if (user.ConfirmCode == userConfirmMailVM.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                return RedirectToAction("Login", "Authorize", new { Area = "Admin" });
            }

            return View();
        }
    }
}
