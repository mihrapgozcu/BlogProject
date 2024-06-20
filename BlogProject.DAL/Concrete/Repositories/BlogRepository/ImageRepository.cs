using BlogProject.DAL.Abstract;
using BlogProject.DAL.Base;
using BlogProject.DAL.Concrete.Context;
using BlogProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.Repositories.BlogRepository
{
    public class ImageRepository : BaseBlogContextRepository<Image, BlogContext>, IImageRepository
    {
        public ImageRepository(BlogContext context) : base(context)
        {
        }
    }
}
