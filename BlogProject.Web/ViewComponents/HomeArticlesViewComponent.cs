using BlogProject.BLL.Services.Abstract;
using BlogProject.BLL.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.ViewComponents
{
    public class HomeArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public HomeArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = await _articleService.GetAllArticlesNonDeletedTake10();
            return View(articles);
        }
    }
}
