using BlogProject.Core.BaseEntities;
using BlogProject.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Entities
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
        public string FileType { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public Image()
        {
            Articles = new HashSet<Article>();
        }
    }
}
