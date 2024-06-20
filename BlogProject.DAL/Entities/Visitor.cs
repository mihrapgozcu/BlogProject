using BlogProject.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Entities
{
    public class Visitor : BaseEntity
    {
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }

       
        public virtual ICollection<ArticleVisitor> ArticleVisitors { get; set; } 
        
        public Visitor()
        {
            ArticleVisitors = new HashSet<ArticleVisitor>();
        }
    }
}
