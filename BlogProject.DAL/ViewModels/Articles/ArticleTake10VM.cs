using BlogProject.DAL.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.ViewModels.Articles
{
    public class ArticleTake10VM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
