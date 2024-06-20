using BlogProject.DAL.Configurations;
using BlogProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Article>(new ArticleConfigruration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Image>(new ImageConfiguration());
            modelBuilder.ApplyConfiguration<Visitor>(new VisitorConfiguration());
            modelBuilder.ApplyConfiguration<ArticleVisitor>(new ArticleVisitorConfiguration());
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<ArticleVisitor> ArticleVisitors { get; set; }
    }
}
