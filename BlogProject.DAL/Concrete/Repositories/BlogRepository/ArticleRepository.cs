using BlogProject.Core.IBaseRepositories;
using BlogProject.DAL.Abstract;
using BlogProject.DAL.Base;
using BlogProject.DAL.Concrete.Context;
using BlogProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.Repositories.BlogRepository
{
    public class ArticleRepository : BaseBlogContextRepository<Article, BlogContext>, IArticleRepository
    {
        public ArticleRepository(BlogContext context) : base(context)
        {
        }
    }
}
