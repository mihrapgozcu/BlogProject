using BlogProject.DAL.Entities;
using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.FluentValidations
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(90)
                .WithName("Başlık");

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(70)
                .WithName("İçerik");
        }
    }
}
