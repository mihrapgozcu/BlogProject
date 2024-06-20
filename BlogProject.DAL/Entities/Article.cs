using BlogProject.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BlogProject.DAL.Entities
{
    public class Article : BaseEntity 
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        
        public virtual Category Category { get; set; }
        public virtual int CategoryId { get; set; }
        
        public virtual Image Image { get; set; }
        public virtual int ImageId { get; set; }

        public virtual int UserId { get; set; }

        
        public virtual ICollection<ArticleVisitor> ArticleVisitors { get; set; }
        public Article()
        {
            ArticleVisitors = new HashSet<ArticleVisitor>();
        }
    }
}
