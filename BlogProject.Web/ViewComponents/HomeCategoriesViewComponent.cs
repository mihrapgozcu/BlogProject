using BlogProject.BLL.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.ViewComponents
{
    public class HomeCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var categories = await _categoryService.GetAllCategoriesNonDeletedTake23();
            return View(categories);
        }
    }
}
