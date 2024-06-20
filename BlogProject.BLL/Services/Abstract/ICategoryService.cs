using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllCategoriesNonDeleted();

        Task CreatedCategory(CategoryCreateVM categoryCreateVM);

        Task<Category> GetCategoryById(int id);

        Task UpdatedCategory(CategoryUpdateVM categoryUpdateVM);

        Task SafeDeleteCategory(int id);

        Task<List<CategoryVM>> GetAllCategoriesDeleted();

        Task UndoDeleteArticle(int id);

        Task<List<CategoryVM>> GetAllCategoriesNonDeletedTake23();
    }
}
