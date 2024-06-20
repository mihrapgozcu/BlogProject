using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var admin = new AppUser
            {
                Id = 1,
                UserName = "admin@deneme.com",
                NormalizedUserName = "ADMIN@DENEME.COM",
                Email = "admin@deneme.com",
                NormalizedEmail = "ADMIN@DENEME.COM",
                PhoneNumber = "+905555555555555",
                FirstName = "Cevdet",
                LastName = "Herodot",
                About = "Super Admin",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "article-images/cevdet_heredot.png"

            };
            admin.PasswordHash = CreatePasswordHash(admin, "Aa123456*");

            var author1 = new AppUser
            {
                Id = 2,
                UserName = "mihrapgozcu@gmail.com",
                NormalizedUserName = "MIHRAPGOZCU@GMAIL.COM",
                Email = "mihrapgozcu@gmail.com",
                NormalizedEmail = "MIHRAPGOZCU@GMAIL.COM",
                PhoneNumber = "+905512444546",
                FirstName = "Mihrap",
                LastName = "Gözcü",
                About = "Yazmak onun işi.....",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "article-images/mihrap_gozcu.png"
            };
            author1.PasswordHash = CreatePasswordHash(author1, "Mm123456");

            var author2 = new AppUser
            {
                Id = 3,
                UserName = "akin@gmail.com",
                NormalizedUserName = "AKIN@GMAIL.COM",
                Email = "akin@gmail.com",
                NormalizedEmail = "AKIN@GMAIL.COM",
                PhoneNumber = "+9055358585858",
                FirstName = "Akın",
                LastName = "Gür",
                About = "Yazmaya çalışıyor diyelim..",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "article-images/resimsizler.png"
            };
            author2.PasswordHash = CreatePasswordHash(author2, "Ag123456");

            var author3 = new AppUser
            {
                Id = 4,
                UserName = "yilmaz@gmail.com",
                NormalizedUserName = "YILMAZ@GMAIL.COM",
                Email = "yilmaz@gmail.com",
                NormalizedEmail = "YILMAZ@GMAIL.COM",
                PhoneNumber = "+905556667788",
                FirstName = "Yılmaz",
                LastName = "Uslu",
                About = "Sitenin kıdemli yazar kadrosuna dahil.",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Path = "article-images/resimsizler.png"
            };
            author3.PasswordHash = CreatePasswordHash(author3, "123456*y");

            builder.HasData(admin, author1, author2, author3);
        }

        private string CreatePasswordHash(AppUser appUser, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(appUser, password);
        }
    }
}
