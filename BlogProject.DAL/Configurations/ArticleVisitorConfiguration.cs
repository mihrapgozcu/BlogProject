using BlogProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Configurations
{
    public class ArticleVisitorConfiguration : IEntityTypeConfiguration<ArticleVisitor>
    {
        public void Configure(EntityTypeBuilder<ArticleVisitor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);

            builder.HasOne<Article>(x => x.Article)
                .WithMany(x => x.ArticleVisitors)
                .HasForeignKey(x => x.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Visitor>(x => x.Visitor)
                .WithMany(x => x.ArticleVisitors)
                .HasForeignKey(x => x.VisitorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
