using BlogProject.DAL.Entities;
using BlogProject.DAL.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Articles
{
   
    public class ArticleVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryVM Category { get; set; }
        public Image Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
    }
}
