using BlogProject.DAL.Abstract;
using BlogProject.DAL.Concrete.Context;
using BlogProject.DAL.Concrete.Repositories.BlogRepository;
using BlogProject.DAL.Concrete.Repositories.IdentityRepository;
using BlogProject.DAL.Entities;
using BlogProject.DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete
{
    public static class EFContextDAL
    {
        public static IServiceCollection AddScopedDAL(this IServiceCollection services) 
        {
            services.AddDbContext<BlogContext>(options =>
            {
                string blogConnection = @"Data source=MIHRAP-PC\SQLEXPRESS;Initial catalog=BLOGDB_Mihrap;Integrated security=true; trustServerCertificate=true";
                options.UseSqlServer(blogConnection);
                options.UseLazyLoadingProxies();
            })
                .AddDbContext<AppIdentityContext>(options =>
                {
                    string identityConnection = @"Data source=MIHRAP-PC\SQLEXPRESS;Initial catalog=IDENTITYDB_Mihrap;Integrated security=true; trustServerCertificate=true;";
                    options.UseSqlServer(identityConnection);
                    options.UseLazyLoadingProxies();
                })
                .AddScoped<IArticleRepository, ArticleRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IImageRepository, ImageRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IArticleVisitorRepository, ArticleVisitorRepository>()
                .AddScoped<IVisitorRepository, VisitorRepository >();

            services.AddIdentityCore<AppUser>().AddRoles<AppRole>().AddEntityFrameworkStores<AppIdentityContext>();

            return services;
        }
    }
}
