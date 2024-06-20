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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
                new Category { Id = 1, Name = "Teknoloji", CreatedBy = "Yılmaz Uslu", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 2, Name = "Ekonomi", CreatedBy = "Cevdet Heredot", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 3, Name = "Psikoloji", CreatedBy = "Akın Gür", CreatedDate = DateTime.Now, IsDeleted = false },

                new Category { Id = 4, Name = "Egitim", CreatedBy = "Mihrap Gözcü", CreatedDate = DateTime.Now, IsDeleted = false },
                new Category { Id = 5, Name = "Saglık", CreatedBy = "Mihrap Gözcü", CreatedDate = DateTime.Now, IsDeleted = false }
                );
        }
    }
}
