using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Articles
{
    public class ArticleUpdateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }  
        public ICollection<CategoryVM> CategoryVMs { get; set; }
        public ArticleUpdateVM()
        {
            CategoryVMs = new HashSet<CategoryVM>();
        }
    }
}
