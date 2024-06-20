using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Entities;
using BlogProject.Web.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Admin}")]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IDashboardService _dashboardService;

        public HomeController(IArticleService articleService, IDashboardService dashboardService)
        {
            _articleService = articleService;
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeleted();
            
            return View(articles);
        }

        public async Task<IActionResult> YearlyArticleCounts() 
        {
            var count = await _dashboardService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));    //js'ye dizi olarak yolluyoruz.
        }

        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await _dashboardService.GetTotalArticleCount();
            return Json(count);    //liste kullanmadığımız için SerializeObject yapmadık.
        }

        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await _dashboardService.GetTotalCategoryCount();
            return Json(count);    //liste kullanmadığımız için SerializeObject yapmadık.
        }
    }
}
