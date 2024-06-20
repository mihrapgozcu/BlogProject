using BlogProject.DAL.ViewModels.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Articles
{
    public class ArticleCreateVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Photo { get; set; }
        public ICollection<CategoryVM> CategoryVMs { get; set; }
        public ArticleCreateVM()
        {
            CategoryVMs = new HashSet<CategoryVM>();
        }
    }
}
