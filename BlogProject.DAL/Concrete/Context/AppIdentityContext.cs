using BlogProject.DAL.Configurations;
using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.Context
{
    public class AppIdentityContext : IdentityDbContext<AppUser, AppRole, int>  //burada yazdığımız için aşağıda dbset olarak tanımlamaya gerek yok.
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        
    }
}
