using AutoMapper;
using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Abstract;
using BlogProject.DAL.Entities;
using BlogProject.DAL.UnitOfWorks;
using BlogProject.DAL.ViewModels.Articles;
using BlogProject.DAL.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _user;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _user = httpContextAccessor.HttpContext.User;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryVM>> GetAllCategoriesNonDeleted()
        {
            var categories = await _categoryRepo.GetAll(x => x.IsDeleted == false);
            var map = _mapper.Map<List<CategoryVM>>(categories);
            return map;
        }

        public async Task CreatedCategory(CategoryCreateVM categoryCreateVM) 
        {
            var userEmail = _user.GetLoggedInEmail();

            var category = new Category() 
            { 
                Name = categoryCreateVM.Name,
                CreatedBy = userEmail
            };

            await _categoryRepo.Create(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _categoryRepo.FindById(id);
            return category;
        }

        public async Task UpdatedCategory(CategoryUpdateVM categoryUpdateVM)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await _categoryRepo.GetAsync(x => x.IsDeleted == false && x.Id == categoryUpdateVM.Id);

            category.Name = categoryUpdateVM.Name;
            category.UpdatedDate = DateTime.Now;
            category.UpdatedBy = userEmail;

            await _categoryRepo.Update(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteCategory(int id)
        {
            var userEmail = _user.GetLoggedInEmail();

            var category = await _categoryRepo.FindById(id);

            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await _categoryRepo.Update(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<CategoryVM>> GetAllCategoriesDeleted()
        {
            var categories = await _categoryRepo.GetAll(x => x.IsDeleted == true);
            var map = _mapper.Map<List<CategoryVM>>(categories);
            return map;
        }

        public async Task UndoDeleteArticle(int id)
        {
            var category = await _categoryRepo.FindById(id);

            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;

            await _categoryRepo.Update(category);
            await _unitOfWork.SaveAsync();
        }


        public async Task<List<CategoryVM>> GetAllCategoriesNonDeletedTake23()
        {
            var categories = await _categoryRepo.GetAll(x => x.IsDeleted == false);
            var map = _mapper.Map<List<CategoryVM>>(categories);
            return map.Take(23).ToList();
        }
    }
}
