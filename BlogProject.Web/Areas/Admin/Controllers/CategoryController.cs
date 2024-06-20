using AutoMapper;
using BlogProject.BLL.Services.Abstract;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Articles;
using BlogProject.DAL.ViewModels.Categories;
using BlogProject.Web.Consts;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Admin}")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper)
        {
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            return View(categories);
        }


        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await _categoryService.GetAllCategoriesDeleted();

            return View(categories);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVM)
        {
            var map = _mapper.Map<Category>(categoryCreateVM);
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(categoryCreateVM);
            }

            await _categoryService.CreatedCategory(categoryCreateVM);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryCreateVM categoryCreateVM)
        {
            var map = _mapper.Map<Category>(categoryCreateVM);
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                return Json(result.Errors.First().ErrorMessage);
            }

            await _categoryService.CreatedCategory(categoryCreateVM);
            string categoryName = categoryCreateVM.Name;
            return Json(categoryName);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            var map = _mapper.Map<Category, CategoryUpdateVM>(category);    //Category, CategoryUpdateVM'e dönüştü

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateVM categoryUpdateVM)
        {
            var map = _mapper.Map<Category>(categoryUpdateVM);
            var result = await _validator.ValidateAsync(map);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(categoryUpdateVM);
            }

            await _categoryService.UpdatedCategory(categoryUpdateVM);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.SafeDeleteCategory(id);

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


        public async Task<IActionResult> UndoDeleted(int id)
        {
            await _categoryService.UndoDeleteArticle(id);

            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
