using AutoMapper;
using BlogProject.BLL.AutoMapper;
using BlogProject.BLL.FluentValidations;
using BlogProject.BLL.Helpers.Images;
using BlogProject.BLL.Services.Abstract;
using BlogProject.DAL.Abstract;
using BlogProject.DAL.Concrete;
using BlogProject.DAL.Concrete.Context;
using BlogProject.DAL.Concrete.Repositories.BlogRepository;
using BlogProject.DAL.Concrete.Repositories.IdentityRepository;
using BlogProject.DAL.Entities;
using BlogProject.DAL.UnitOfWorks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Concrete
{
    public static class EFContextBLL
    {
        public static IServiceCollection AddScopedBLL(this IServiceCollection services)
        {
            services.AddScopedDAL()
                .AddScoped<IArticleService, ArticleService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IImageHelper, ImageHelper>()
                .AddScoped<IDashboardService, DashboardService>()
                .AddScoped<IRoleService, RoleService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();    //Login olan kullanıyıcı bulmak için(LoggedInUserExtension)

            services.AddControllersWithViews()
                .AddFluentValidation(options => 
                {
                    options.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                    options.DisableDataAnnotationsValidation = true;
                    options.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                });

            var mapp = new MapperConfiguration(mpp => 
            {
                mpp.AddProfile(new Mapping());
            });

            IMapper mapper = mapp.CreateMapper();
            services.AddSingleton(mapper).BuildServiceProvider();

            return services;
        }
    }
}
