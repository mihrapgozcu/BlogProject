using AutoMapper;
using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Articles;
using BlogProject.DAL.ViewModels.Authors;
using BlogProject.DAL.ViewModels.Categories;
using BlogProject.DAL.ViewModels.Roles;
using BlogProject.DAL.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Article, ArticleVM>().ReverseMap();
            CreateMap<AppUser, UserLoginVM>().ReverseMap();
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Article, ArticleCreateVM>().ReverseMap();
            CreateMap<Article, ArticleUpdateVM>().ReverseMap();
            CreateMap<ArticleVM, ArticleUpdateVM>().ReverseMap();
            CreateMap<Category, CategoryCreateVM>().ReverseMap();
            CreateMap<Category, CategoryUpdateVM>().ReverseMap();
            CreateMap<AppUser, UserVM>().ReverseMap();
            CreateMap<AppUser, UserCreateVM>().ReverseMap();
            CreateMap<AppUser, UserUpdateVM>().ReverseMap();
            CreateMap<AppUser, UserProfileVM>().ReverseMap();
            CreateMap<AppUser, UserRegisterVM>().ReverseMap();
            CreateMap<AppRole, RoleVM>().ReverseMap();
            CreateMap<AppRole, RoleCreateVM>().ReverseMap();
            CreateMap<AppRole, RoleUpdateVM>().ReverseMap();
            CreateMap<AppUser, AuthorDetailVM>().ReverseMap();
            CreateMap<Article, ArticleTake10VM>().ReverseMap();
        }
    }
}
