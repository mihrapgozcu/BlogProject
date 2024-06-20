using AutoMapper;
using BlogProject.BLL.Services.Abstract;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Articles;
using BlogProject.DAL.ViewModels.Categories;
using BlogProject.DAL.ViewModels.Users;
using BlogProject.Web.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Controllers
{
    [Authorize(Roles = $"{RoleConsts.Admin}, {RoleConsts.Author}")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;
        private readonly IValidator<Category> _cValidator;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IValidator<Category> cValidator)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
            _cValidator = cValidator;
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleCreateVM { CategoryVMs = categories });
        }


        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateVM articleCreateVM)
        {
            if (articleCreateVM.Photo == null)
            {
                ModelState.AddModelError("", "Resim yüklemeden makale yayımlayamazsınız.");
                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleCreateVM { CategoryVMs = categories });
            }

            var map = _mapper.Map<Article>(articleCreateVM);  
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                
                var categories = await _categoryService.GetAllCategoriesNonDeleted();
                return View(new ArticleCreateVM { CategoryVMs = categories });
            }

            await _articleService.CreateArticle(articleCreateVM);
            return RedirectToAction("Index", "Home", new { Area = "" });
        }


        public async Task<IActionResult> AddWithAjax([FromBody] CategoryCreateVM categoryCreateVM)
        {
            var map = _mapper.Map<Category>(categoryCreateVM);
            var result = await _cValidator.ValidateAsync(map);

            if (!result.IsValid)
            {
                return Json(result.Errors.First().ErrorMessage);
            }

            await _categoryService.CreatedCategory(categoryCreateVM);
            string categoryName = categoryCreateVM.Name;
            return Json(categoryName);
        }
    }
}
