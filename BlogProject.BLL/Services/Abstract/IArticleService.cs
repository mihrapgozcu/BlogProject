using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ArticleVM>> GetAllArticlesWithCategoryNonDeleted();

        Task CreateArticle(ArticleCreateVM articleCreateVM);

        Task<ArticleVM> GetArticleWithCategoryNonDeleted(int id);

        Task UpdateArticle(ArticleUpdateVM articleUpdateVM);

        Task SafeDeleteArticle(int id);

        Task<List<ArticleVM>> GetAllArticlesWithCategoryDeleted();  //Silinmiş makaleleri listelemek için

        Task UndoDeleteArticle(int id);     //Silinen makaleleri geri getirmek için

        Task<ArticleListVM> GetAllByPaging(int categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);    //Anasayfa makale getirmek için.

        Task<ArticleListVM> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);    //Search çubuğunda arama yapmak için.

        Task<List<ArticleTake10VM>> GetAllArticlesNonDeletedTake10();
    }
}
