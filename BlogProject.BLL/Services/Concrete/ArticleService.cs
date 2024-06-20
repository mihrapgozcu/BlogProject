using AutoMapper;
using BlogProject.BLL.Helpers.Images;
using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Abstract;
using BlogProject.DAL.Entities;
using BlogProject.DAL.Enums;
using BlogProject.DAL.UnitOfWorks;
using BlogProject.DAL.ViewModels.Articles;
using BlogProject.DAL.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ClaimsPrincipal _user;     
        private readonly IImageHelper _imageHelper;
        private readonly IImageRepository _imageRepo;

       public ArticleService(IArticleRepository articleRepo, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper, IImageRepository imageRepo)
        {
            _articleRepo = articleRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _user = httpContextAccessor.HttpContext.User;       
            _imageHelper = imageHelper;
            _imageRepo = imageRepo;
        }

        public async Task<List<ArticleVM>> GetAllArticlesWithCategoryNonDeleted()
        {
            var articles = await _articleRepo.GetAll(x => x.IsDeleted == false, x => x.Category);
            var map = _mapper.Map<List<ArticleVM>>(articles);
            return map;
        }

        public async Task CreateArticle(ArticleCreateVM articleCreateVM)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var imageUpload = await _imageHelper.Upload(articleCreateVM.Title, articleCreateVM.Photo, ImageType.Post);

            var image = new Image() 
            { 
                FileName = imageUpload.FullName,
                FileType = articleCreateVM.Photo.ContentType,
                CreatedBy = userEmail
            };

            await _imageRepo.Create(image);
            await _unitOfWork.SaveAsync();      

            var article = new Article() 
            { 
                Title = articleCreateVM.Title,
                Content = articleCreateVM.Content,
                CategoryId = articleCreateVM.CategoryId,
                CreatedBy = userEmail,
                UserId = userId,
                ImageId = image.Id
            };

            await _articleRepo.Create(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ArticleVM> GetArticleWithCategoryNonDeleted(int id)
        {
            var article = await _articleRepo.GetAsync(x => x.IsDeleted == false && x.Id == id, x => x.Category, i => i.Image);
            var map = _mapper.Map<ArticleVM>(article);
            return map;
        }

        public async Task UpdateArticle(ArticleUpdateVM articleUpdateVM) 
        {
            var userEmail = _user.GetLoggedInEmail();

            var article = await _articleRepo.GetAsync(x => x.IsDeleted == false && x.Id == articleUpdateVM.Id, x => x.Category, i => i.Image);

            if (articleUpdateVM.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);

                var imageUpload = await _imageHelper.Upload(articleUpdateVM.Title, articleUpdateVM.Photo, ImageType.Post);

                Image image = new Image() 
                { 
                    FileName = imageUpload.FullName,
                    FileType = articleUpdateVM.Photo.ContentType,
                    CreatedBy = userEmail
                };

                await _imageRepo.Create(image);
                await _unitOfWork.SaveAsync();

                article.ImageId = image.Id;
            }

            article.Title = articleUpdateVM.Title;
            article.Content = articleUpdateVM.Content;
            article.CategoryId = articleUpdateVM.CategoryId;
            article.UpdatedDate = DateTime.Now;
            article.UpdatedBy = userEmail;

            await _articleRepo.Update(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteArticle(int id) 
        {
            var userEmail = _user.GetLoggedInEmail();

            var article = await _articleRepo.FindById(id);
            
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await _articleRepo.Update(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleVM>> GetAllArticlesWithCategoryDeleted()    //Silinmiş makaleleri listeler.
        {
            var articles = await _articleRepo.GetAll(x => x.IsDeleted == true, x => x.Category);
            var map = _mapper.Map<List<ArticleVM>>(articles);
            return map;
        }

        public async Task UndoDeleteArticle(int id)        //Silinen makaleleri geri getirir.
        {
            var article = await _articleRepo.FindById(id);

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await _articleRepo.Update(article);
            await _unitOfWork.SaveAsync();
        }


        public async Task<ArticleListVM> GetAllByPaging(int categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false) 
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == 0
                ? await _articleRepo.GetAll(x => x.IsDeleted == false, x => x.Category, x => x.Image)
                : await _articleRepo.GetAll(x => x.IsDeleted == false && x.CategoryId == categoryId, x => x.Category, x => x.Image);

            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            //Take = pageSize kadarını al. Skip = Atla (2. sayfadayız. (2-1)*3=3 3'ü atla sonrasını göster)

            return new ArticleListVM 
            { 
                Articles = sortedArticles,
                CategoryId = categoryId,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<ArticleListVM> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            //silinmemiş olacak VE (keyword başlıkta VEYA içerikte VEYA kategori adında) olanlar, kategori ve image tablolarını INCLUDE et.
            var articles = await _articleRepo.GetAll(x => x.IsDeleted == false && 
                  (x.Title.Contains(keyword) || x.Content.Contains(keyword) || x.Category.Name.Contains(keyword)), 
                  x => x.Category, x => x.Image);

            var sortedArticles = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            //Take = pageSize kadarını al. Skip = Atla (2. sayfadayız. (2-1)*3=3 3'ü atla sonrasını göster)

            return new ArticleListVM
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }


        public async Task<List<ArticleTake10VM>> GetAllArticlesNonDeletedTake10()
        {
            var articles = await _articleRepo.GetAll(x => x.IsDeleted == false);
            var map = _mapper.Map<List<ArticleTake10VM>>(articles);
            return map.OrderByDescending(x => x.ViewCount).Take(10).ToList();
        }
    }
}
