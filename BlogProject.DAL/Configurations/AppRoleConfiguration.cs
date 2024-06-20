using BlogProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData
                (
                    //ConcurrencyStamp = Farklı kişiler aynı işlemi aynı anda yaparsa işlemlerin çakışmasını önler.
                    new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                    new AppRole { Id = 2, Name = "Author", NormalizedName = "AUTHOR", ConcurrencyStamp = Guid.NewGuid().ToString() }
                );
        }
    }
}
