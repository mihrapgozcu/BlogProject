using AutoMapper;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()    //Index'e karşılık gelen => InvokeAsync
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            var map = _mapper.Map<UserVM>(loggedInUser);

           
            var role = string.Join("", await _userManager.GetRolesAsync(loggedInUser));
            map.Role = role;

            return View(map);
        }
    }
}
