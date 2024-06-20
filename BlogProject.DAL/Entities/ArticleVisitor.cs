using BlogProject.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Entities
{
    public class ArticleVisitor :BaseEntity
    {
        public virtual Article Article { get; set; }
        public virtual int ArticleId { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual int VisitorId { get; set; }
    }
}
